using Application.Commands.User;
using Application.Mappers;
using Application.Services.interfaces;
using Domain.Models;
using Infrastructure.Extensions;
using Infrastructure.Repository;
using Infrastructure.Repository.interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.classes
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<User> _SignInManager;
        private readonly IUserRepository _userRepository;
        private readonly IUserRepository2 _userRepository2;
        public IdentityService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager
            ,IUserRepository2 userRepository2, IUserRepository userRepository, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _SignInManager = signInManager;
            _userRepository2 = userRepository2;
            _userRepository = userRepository;

        }



        public async Task<List<string>> GetPhoneAndSetVerifyCode(GetPhoneAndSetVerifyCodeCommand command)
        {
            var isPhoneExist = await _userRepository.IsPhoneExist(command.PhoneNumber);
            List<string> ResultList = new List<string>();
            if (!isPhoneExist)
            {
                var newUser = command.ToModel();
                await _userRepository.UserSignUpAsync(newUser);

                ResultList.Add("Register");
                ResultList.Add(newUser.Id.ToString());
                ResultList.Add(newUser.VerifyCode);

                return ResultList;
            }

            var user = await _userRepository.GetUserByPhone(command.PhoneNumber);
            var randomVerify = new Random().Next(1000, 9999).ToString();
            user.SetVerifycode(randomVerify);

            ResultList.Add("Login");
            ResultList.Add(user.Id.ToString());
            ResultList.Add(user.VerifyCode);

            await _userRepository.UpdateUserAsync();
            return ResultList;
        }



        public async Task<Result<string>> RegisterAsync(RegisterUserCommand command)
        {
            
            var user = new User
            {
                UserName = command.UserName,
                PhoneNumber = command.PhoneNumber,
                Email = command.Email
            };
            var result = await _userManager.CreateAsync(user, command.Password);
            if (result.Succeeded)
            {
                return result.ToApplicationResult("", user.Id);
            }
            return result.ToApplicationResult("", user.Id);
        }
        public async Task<Result<string>> LoginAsync()
        {
            var result = await _SignInManager.PasswordSignInAsync(phoneNumber,userName);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
