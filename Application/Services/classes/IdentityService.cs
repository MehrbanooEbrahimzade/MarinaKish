using Application.Commands.User;
using Application.Services.interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using Infrastructure.Repository.interfaces;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Formatting;
using System.Net.Http;
using System.Linq;
using Application.Mappers;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Net;

namespace Application.Services.classes
{

    public class IdentityService : IIdentityService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<User> _SignInManager;
        private readonly IUserRepository _userRepository;
        private IConfiguration Configuration;

        private static readonly HttpClient client = new HttpClient();

        public IdentityService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager
            , IUserRepository userRepository, SignInManager<User> signInManager
            , IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _SignInManager = signInManager;
            _userRepository = userRepository;
            Configuration = configuration;

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
            var result = await _userManager.VerifyChangePhoneNumberTokenAsync(user, command.VerifyCode, command.PhoneNumber);
            if (result != true)
            {
                return "User Not Found ";
            }
            var secretkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]));
            var signInCredintials = new SigningCredentials(secretkey, SecurityAlgorithms.HmacSha256);
            var tokenOption = new JwtSecurityToken(
                issuer: "http://localhost:5005/",
                claims: new List<Claim>
                {
                    new Claim(ClaimTypes.Name,command.PhoneNumber),

                },
                expires: DateTime.Now.AddMinutes(150),
                signingCredentials: signInCredintials

                );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOption);
            return (tokenString);


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

            user.UpdateProfile(command.FirstName, command.FirstName
                             , command.NationalCode, command.BirthDay, command.CreditCard.ToModel());
            await _userManager.UpdateAsync(user);
            return user;

        }

    }

}

