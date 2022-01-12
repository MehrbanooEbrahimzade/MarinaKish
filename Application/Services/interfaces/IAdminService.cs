using Application.Commands.Admin;
using Application.Commands.User;
using System.Threading.Tasks;

namespace Application.Services.interfaces
{
    public interface IAdminService
    {
        Task<string> LoginAsync(AdminLoginCommand command);
        Task<bool> SendVerifyCodeAdmin(RegisterUserCommand admin);
        Task<bool> RestoreAdminPassword(ForgetPasswordCommand command);
    }
}
