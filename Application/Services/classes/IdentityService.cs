using Application.Commands.User;
using Application.Exceptions;
using Application.Mappers;
using Application.Services.interfaces;
using Domain.Enums;
using Domain.Models;
using Infrastructure.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.classes
{

    public class IdentityService : IIdentityService
    {
        private readonly UserManager<User> _userManager;
        private readonly JwtToken _jwtToken;
        private readonly ILogger _logger;

        private static readonly HttpClient client = new HttpClient();

        public IdentityService(UserManager<User> userManager, IOptions<JwtToken> jwtToken, ILogger<IdentityService> logger)
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
        public async Task<bool> SendVerifyCodeAgain(RegisterUserCommand command)
        {
            try
            {
                var user = await _userManager.Users.SingleOrDefaultAsync(x => x.PhoneNumber.Equals(command.PhoneNumber));
                if (user != null)
                {
                    var code = await _userManager.GenerateChangePhoneNumberTokenAsync(user, user.PhoneNumber);
                    await SendSms(user.PhoneNumber, code);
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} sendverifycode method error", typeof(IdentityService));
                return false;
            }
        }
        public  async Task SendSms(string phoneNumber, string code)
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
                throw new NotFoundExeption(nameof(User), command.PhoneNumber, command.PhoneNumber);

            var result = await _userManager.VerifyChangePhoneNumberTokenAsync(user, command.VerifyCode, command.PhoneNumber);

            if (result == false)
                throw new Exception("کد وارد شده صحیح نمی باشد ");
            var token = await GenerateToken(user.Id, command);
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
        private async Task<string> GenerateToken(string id, UserLoginCommand command)
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
            return tokenString;
        }
        #endregion


        public async Task<bool> DeleteUser(Guid id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id.ToString());
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
        public  async Task<bool> SendVerifyCodeAdmin(RegisterUserCommand admin)
        {

            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.PhoneNumber == admin.PhoneNumber && u.RoleType ==0);
            if (user != null)
            {
                var code = await _userManager.GenerateChangePhoneNumberTokenAsync(user, admin.PhoneNumber);
                await SendSms(admin.PhoneNumber, code);
                return true;
            }
            if (user == null)
            {
                throw new NotFoundExeption(nameof(user),admin.PhoneNumber,admin.PhoneNumber);
            }

            return false;
        }
        public async Task<bool> ConfirmAdminPhoneNumber(string phoneNumber, string verifyCode)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(f => f.PhoneNumber == phoneNumber&&f.RoleType==0);

            if (user == null)
                throw new NotFoundExeption(nameof(User), phoneNumber, phoneNumber);

            var result = await _userManager.VerifyChangePhoneNumberTokenAsync(user, verifyCode,phoneNumber);
            return result;

        }
        public async Task<bool> RestoreAdminPassword(ForgetPasswordCommand command)
        {
            var result = await ConfirmAdminPhoneNumber(command.PhoneNumber,command.VerifyCode);
            if (result)
            {
                var user =await  _userManager.Users.SingleOrDefaultAsync(x=>x.PhoneNumber == command.PhoneNumber &&x.RoleType==0);
                var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
                var updateResult = await _userManager.ResetPasswordAsync(user,resetToken,command.NewPassword);
                return updateResult.Succeeded;
            }
            return false; 
        }

    }

}

