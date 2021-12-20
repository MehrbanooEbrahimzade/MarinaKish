using Application.Commands.User;
using Domain.Models;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.interfaces
{
    public interface IIdentityService
    {
        Task RegisterAsync(RegisterUserCommand command);
        Task CompleteProfile(CompleteProfileCommand command);
        Task<User> UpdateProfileAsync(UpdateUserCommand command);
    }
}
