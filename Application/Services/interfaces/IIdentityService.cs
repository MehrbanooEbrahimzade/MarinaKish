using Application.Commands.User;
using Domain.Models;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Services.classes;
using Microsoft.AspNetCore.Mvc;

namespace Application.Services.interfaces
{
    public interface IIdentityService 
    {
        Task RegisterAsync(RegisterUserCommand command);
        Task<bool> LoginAsync(UserLoginCommand command);
        Task CompleteProfile(CompleteProfileCommand command);
        Task<User> UpdateProfileAsync(UpdateUserCommand command);
        Task DeleteUser(UserLoginCommand command);
        Task ChangePhoneNumberAsync(); 

    }
}
