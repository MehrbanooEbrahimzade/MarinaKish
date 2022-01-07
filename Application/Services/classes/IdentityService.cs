using Application.Commands.User;
using Application.Services.interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Formatting;
using System.Net.Http;
using System.Linq;
using Application.Mappers;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Domain.RepasitoryInterfaces;
using Infrastructure.Helper;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;

namespace Application.Services.classes
{

    public class IdentityService : IIdentityService
    {
        private readonly UserManager<User> _userManager;
        private readonly JwtToken _jwtToken;
        private readonly ILogger _logger;

        private static readonly HttpClient client = new HttpClient();

        public IdentityService(UserManager<User> userManager, IOptions<JwtToken> jwtToken,ILogger<IdentityService> logger)
        {
            _userManager = userManager;
            _jwtToken = jwtToken.Value;
            _logger = logger;
        }

        public async Task RegisterAsync(RegisterUserCommand command)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.PhoneNumber == command.PhoneNumber);
            if (user == null)
            {
                user = new User(command.PhoneNumber);
                var result = _userManager.CreateAsync(user, user.PhoneNumber);
            }

            var code = await _userManager.GenerateChangePhoneNumberTokenAsync(user, user.PhoneNumber);

            await SendSms(user.PhoneNumber, code);
            return;
        }

        private async Task SendSms(string phoneNumber, string code)
        {
            try
            {

                var values = new Dictionary<string, string> { { "PhoneNumber", phoneNumber }, { "Message", code } };

                var response = await client.PostAsync("http://194.36.174.133:5002/api/Notification/add", values, new JsonMediaTypeFormatter());

                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public async Task<string> LoginAsync(UserLoginCommand command)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(f => f.PhoneNumber == command.PhoneNumber);

            if (user == null)
                throw new Exception("شماره وارد شده صحیح نمی باشد");

            var result = await _userManager.VerifyChangePhoneNumberTokenAsync(user, command.VerifyCode, command.PhoneNumber);

            if (result == false)
                throw new Exception("کد وارد شده صحیح نمی باشد ");
            var token =  await GenerateToken(user.Id,command);
            return token; 

        }

        public async Task CompleteProfile(CompleteProfileCommand command)
        {
            var user = await _userManager.Users
                .SingleOrDefaultAsync(item => item.PhoneNumber == command.PhoneNumber);
            if (user.FullName == null)
            {
                user.CompleteInformation(command.FirstName, command.LastName, command.NationalCode);
                await _userManager.UpdateAsync(user);
            }
            return;
        }

        public async Task<User> UpdateProfileAsync(UpdateUserCommand command)
        {
            var user = _userManager.Users.SingleOrDefault(item => item.Id == command.Id.ToString());

            user.UpdateProfile(command.FirstName, command.LastName
                             , command.NationalCode, command.BirthDay, command.CreditCardCommand.ToModel());
            await _userManager.UpdateAsync(user);
            return user;

        }

        #region GenerateToken
        private async Task<string> GenerateToken(string id , UserLoginCommand command)
        {
            var secretkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtToken.Key));
            var credentials = new SigningCredentials(secretkey, SecurityAlgorithms.HmacSha256);
            var tokenOption = new JwtSecurityToken(
                issuer: _jwtToken.Issuer,
                claims: new List<Claim>
                {
                    new Claim(ClaimTypes.MobilePhone,command.PhoneNumber),
                    new Claim("id",id)
                },
                expires: DateTime.Now.AddDays(15),
                signingCredentials: credentials
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOption);
            return  tokenString; 
        }
        #endregion


        public async Task<bool> DeleteUser(Guid id)
        {
            try
            {
                var user =await  _userManager.FindByIdAsync(id.ToString());
                if (user != null)
                {
                    await _userManager.DeleteAsync(user);
                    return true; 
                }
                return false; 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} DeleteAsync  method error", typeof(IdentityService));
                return false;
            }

            
        }
    }

}

