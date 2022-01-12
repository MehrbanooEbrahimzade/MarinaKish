using Application.Commands.Admin;
using Application.Commands.User;
using Application.Services.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marina_Club.Controllers
{
    [Route("api/[controller]")]
    public class AdminController : ApiController
    {
        private readonly IAdminService _adminService; 
        public AdminController(IIdentityService identity,IAdminService adminService)
        {
            _adminService = adminService; 
        }


        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> LoginAdminAsync([FromBody]AdminLoginCommand command)
        {
           
            var token =await  _adminService.LoginAsync(command);
            return OkResult(ApiMessage.UserLoggedIn, token);
        }



        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> SendConfirmationCode([FromBody]RegisterUserCommand command)
        {
            command.Validate();
            var result = await _adminService.SendVerifyCodeAdmin(command);
            if (result)
                return OkResult(ApiMessage.verifyCodeSent);
            return BadReq(ApiMessage.BadRequest);

        }
        [AllowAnonymous]
        [HttpPost("reset")]
        public async Task<IActionResult> ResetAdminPassword([FromBody]ForgetPasswordCommand command)
        {
            command.Validate();
            var result = await _adminService.RestoreAdminPassword(command);
            if (result)
                return OkResult(ApiMessage.UserPasswordChanged);
            return BadReq(ApiMessage.BadRequest);
        }
        
    }
}
