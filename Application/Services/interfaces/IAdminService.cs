using Application.Commands.User;
using System.Threading.Tasks;

namespace Application.Services.interfaces
{
    public interface IAdminService
    {
        Task<bool> SendVerifyCodeAdmin(RegisterUserCommand admin);
        Task<bool> RestoreAdminPassword(ForgetPasswordCommand command);
    }
}
