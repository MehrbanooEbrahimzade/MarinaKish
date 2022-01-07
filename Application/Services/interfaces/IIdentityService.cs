using Application.Commands.User;
using Domain.Models;
using System;
using System.Threading.Tasks;

namespace Application.Services.interfaces
{
    public interface IIdentityService
    {
        Task RegisterAsync(RegisterUserCommand command);
        Task<string> LoginAsync(UserLoginCommand command);
        Task CompleteProfile(CompleteProfileCommand command);
        Task<User> UpdateProfileAsync(UpdateUserCommand command);
        Task<bool> DeleteUser(Guid id);
    }
}
