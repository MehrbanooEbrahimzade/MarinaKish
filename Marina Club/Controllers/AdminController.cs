using Application.Commands.Admin;
using Application.Commands.User;
using Application.Services.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Marina_Club.Controllers
{
    [Route("api/[controller]")]
    public class AdminController : ApiController
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }


        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> LoginAdminAsync([FromBody] AdminLoginCommand command)
        {

            var token = await _adminService.LoginAsync(command);
            return OkResult(ApiMessage.UserLoggedIn, token);
        }



        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> SendConfirmationCode([FromBody] RegisterUserCommand command)
        {
            command.Validate();
            var result = await _adminService.SendVerifyCodeAdmin(command);
            if (result)
                return OkResult(ApiMessage.verifyCodeSent);
            return BadReq(ApiMessage.BadRequest);

        }
        [AllowAnonymous]
        [HttpPost("reset")]
        public async Task<IActionResult> ResetAdminPassword([FromBody] ForgetPasswordCommand command)
        {
            command.Validate();
            var result = await _adminService.RestoreAdminPassword(command);
            if (result)
                return OkResult(ApiMessage.UserPasswordChanged);
            return BadReq(ApiMessage.BadRequest);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAdminCredintials(AdminUpdateCommand command)
        {
            var result = await _adminService.UpdateAdminCredintials(command);
            if (!result)
                return BadReq(ApiMessage.BadRequest);
            return OkResult(ApiMessage.Ok);
        }


    }
}
