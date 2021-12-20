using Application.Commands.User;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Application.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Application.Services.interfaces
{
    public interface IIdentityService
    {
        Task RegisterAsync(RegisterUserCommand command);

        Task<string> LoginAsync(UserLoginCommand command);
    }
}
