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
using Domain.RepositoryInterfaces;
using Microsoft.Extensions.Configuration;

namespace Application.Services.classes
{

    public class IdentityService : IIdentityService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<User> _SignInManager;
        private readonly IUserRepository _userRepository;
        private IConfiguration Configuration;
        private readonly IUserRepository2 _iuserRepository2;

        private static readonly HttpClient client = new HttpClient();

        public IdentityService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager
            , IUserRepository userRepository, SignInManager<User> signInManager
            , IConfiguration configuration,IUserRepository2 iuserRepository2)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _SignInManager = signInManager;
            _userRepository = userRepository;
            Configuration = configuration;
            _iuserRepository2 = iuserRepository2;

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
        public async Task LoginAsync(UserLoginCommand command)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(f => f.PhoneNumber == command.PhoneNumber);

            if (user == null)
                throw new Exception("شماره وارد شده صحیح نمی باشد");

            var result = await _userManager.VerifyChangePhoneNumberTokenAsync(user, command.VerifyCode, command.PhoneNumber);

            if (result == false)
                throw new Exception("کد وارد شده صحیح نمی باشد ");
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


        public async Task DeleteUser(string id)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(f => f.Id ==id);

            _iuserRepository2.DeleteUser(user);
        }
    }

}

