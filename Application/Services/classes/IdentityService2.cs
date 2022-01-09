using Application.Commands.User;
using Application.Mappers;
using Application.Services.interfaces;
using Domain.Models;
using Infrastructure.Extensions;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Application.Dtos;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Application.Services.classes
{
    public class IdentityService2 
    {
        //private readonly UserManager<User> _userManager;
        //private readonly RoleManager<IdentityRole> _roleManager;
        //private readonly SignInManager<User> _SignInManager;
        //private readonly IUserRepository _userRepository;
        //private readonly IUserRepository2 _userRepository2;
        //public IdentityService2(UserManager<User> userManager, RoleManager<IdentityRole> roleManager
        //    , IUserRepository2 userRepository2, IUserRepository userRepository, SignInManager<User> signInManager)
        //{
        //    _userManager = userManager;
        //    _roleManager = roleManager;
        //    _SignInManager = signInManager;
        //    _userRepository2 = userRepository2;
        //    _userRepository = userRepository;

        //}



        //public async Task<List<string>> GetPhoneAndSetVerifyCode(GetPhoneAndSetVerifyCodeCommand command)
        //{
        //    var isPhoneExist = await _userRepository.IsPhoneExist(command.PhoneNumber);
        //    List<string> ResultList = new List<string>();
        //    if (!isPhoneExist)
        //    {
        //        var newUser = command.ToModeluser();
        //        await _userRepository.UserSignUpAsync(newUser);

        //        ResultList.Add("Register");
        //        ResultList.Add(newUser.commentId.ToString());
        //        ResultList.Add(newUser.VerifyCode);

        //        return ResultList;
        //    }

        //    var user = await _userRepository.GetUserByPhone(command.PhoneNumber);
        //    var randomVerify = new Random().Next(1000, 9999).ToString();
        //    user.SetVerifycode(randomVerify);

        //    ResultList.Add("Login");
        //    ResultList.Add(user.commentId.ToString());
        //    ResultList.Add(user.VerifyCode);

        //    await _userRepository.UpdateUserAsync();
        //    return ResultList;
        //}



        //public async Task<Result<string>> RegisterAsync(RegisterUserCommand command)
        //{

        //    var user = new User
        //    {
        //        UserName = command.UserName,
        //        PhoneNumber = command.PhoneNumber,
        //        Email = command.Email
        //    };
        //    var result = await _userManager.CreateAsync(user, command.Password);
        //    if (result.Succeeded)
        //    {
        //        return result.ToApplicationResult("", user.commentId);
        //    }
        //    return result.ToApplicationResult("", user.commentId);
        //}



        //public async Task<UserDto> LoginAsync(UserLoginCommand command)
        //{
        //    var user = await _userRepository2.GetUserByPhone(command.CellPhone);

        //    if (user == null)
        //    {
        //        for (int i = 1; i <= 4; i++)
        //        {
        //            if (user != null && command.Password == user.Password)
        //            {
        //                return user.ToDto();
        //                break;
        //            }
        //            return throw new Exception("شماره تلفن یا رمز عبور اشتباه است ");

        //        }
        //    }






            //{
            //    //break;
            //}



        //}
    }
}
