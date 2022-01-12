using Application.Commands.Admin;
using Application.Commands.User;
using Application.Exceptions;
using Application.Services.interfaces;
using Domain.Models;
using Infrastructure.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.classes
{
    public class AdminService : IAdminService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly HttpClient client = new HttpClient();
        private readonly JwtToken _jwtToken;

        public AdminService(UserManager<User> userManager, SignInManager<User> signInManager
            , IOptions<JwtToken> jwtToken)
        {
            _userManager = userManager;
            _jwtToken = jwtToken.Value;
            _signInManager = signInManager;
        }


        public async Task<string> LoginAsync(AdminLoginCommand command)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(a => a.Email == command.Email);

            if (user == null)
                throw new NotFoundExeption(nameof(User), command.Email, "Email");
            var result1 = _userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, command.Password);
            var result = await _signInManager.PasswordSignInAsync(user, command.Password, false, false);

            if (!result.Succeeded)
            {
                throw new Exception("Login failed");
            }
            var token = await GenerateToken(user.Id, command.Email);
            return token;

        }
        private async Task<string> GenerateToken(string id, string email)
        {
            var secretkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtToken.Key));
            var credentials = new SigningCredentials(secretkey, SecurityAlgorithms.HmacSha256);
            var tokenOption = new JwtSecurityToken(
                issuer: _jwtToken.Issuer,
                claims: new List<Claim>
                {
                    new Claim(ClaimTypes.Email,email),
                    new Claim("id",id)
                },
                expires: DateTime.Now.AddDays(15),
                signingCredentials: credentials
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOption);
            return tokenString;
        }


        public async Task<bool> SendVerifyCodeAdmin(RegisterUserCommand admin)
        {

            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.PhoneNumber == admin.PhoneNumber && u.RoleType == 0);
            if (user != null)
            {
                var code = await _userManager.GenerateChangePhoneNumberTokenAsync(user, admin.PhoneNumber);
                await SendSms(admin.PhoneNumber, code);
                return true;
            }
            if (user == null)
            {
                throw new NotFoundExeption(nameof(user), admin.PhoneNumber, admin.PhoneNumber);
            }

            return false;
        }
        public async Task<bool> ConfirmAdminPhoneNumber(string phoneNumber, string verifyCode)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(f => f.PhoneNumber == phoneNumber && f.RoleType == 0);

            if (user == null)
                throw new NotFoundExeption(nameof(User), phoneNumber, phoneNumber);

            var result = await _userManager.VerifyChangePhoneNumberTokenAsync(user, verifyCode, phoneNumber);
            return result;

        }

        public async Task SendSms(string phoneNumber, string code)
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

        public async Task<bool> RestoreAdminPassword(ForgetPasswordCommand command)
        {
            var result = await ConfirmAdminPhoneNumber(command.PhoneNumber, command.VerifyCode);
            if (result)
            {
                var user = await _userManager.Users.SingleOrDefaultAsync(x => x.PhoneNumber == command.PhoneNumber && x.RoleType == 0);
                var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
                var updateResult = await _userManager.ResetPasswordAsync(user, resetToken, command.NewPassword);
                return updateResult.Succeeded;
            }
            return false;
        }




        public async Task<bool> UpdateAdminCredintials(AdminUpdateCommand command)
        {
            var admin = await _userManager.FindByEmailAsync(command.Email);
            if (admin == null)
                throw new NotFoundExeption(nameof(User), command.Email, "Email");
            admin.Email = command.Email;
            admin.PhoneNumber = command.PhoneNumber;
            var result = await _userManager.UpdateAsync(admin);
            return result.Succeeded;
        }
    }
}