﻿using Application.Commands.User;
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
using System.Web.Http;
using System.Web.Http.Results;
using Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.IdentityModel.Tokens;
using BadRequestResult = Microsoft.AspNetCore.Mvc.BadRequestResult;

namespace Application.Services.classes
{

    public class IdentityService : IIdentityService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<User> _SignInManager;
        private readonly IUserRepository _userRepository;
        private static readonly HttpClient client = new HttpClient();

        public IdentityService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager
            , IUserRepository userRepository, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _SignInManager = signInManager;
            _userRepository = userRepository;

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

                var values = new Dictionary<string, string> { { "PhoneNumber", phoneNumber }, { "Text", code } };

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
            var search = await _userManager.Users.FirstOrDefaultAsync(f => f.PhoneNumber == command.PhoneNumber);
            if (search != null)
            {
                var Users = new User(command.PhoneNumber);

                var login = await _userManager
                    .VerifyChangePhoneNumberTokenAsync(Users, command.Verfiycode, Users.PhoneNumber);
                if (login == true)
                {
                    throw new Exception("کد وارد شده صحیح نمیباشد");
                }
                
            }
            else
            {
                throw new Exception("شماره تلفن وارد شده صحیح نمیباشد");
            }

        }

    }

}

