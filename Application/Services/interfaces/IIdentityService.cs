using Application.Commands.User;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.interfaces
{
    public interface IIdentityService
    {
        Task<Result<string>> RegisterAsync(RegisterUserCommand command);
    }
}
