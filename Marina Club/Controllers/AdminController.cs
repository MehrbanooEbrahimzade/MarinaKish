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
        private readonly IIdentityService _identity; 
        public AdminController(IIdentityService identity)
        {
            _identity = identity; 
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> SendConfirmationCode([FromBody]RegisterUserCommand command)
        {
            var result = await _identity.SendVerifyCodeAdmin(command);
            if (result)
                return OkResult(ApiMessage.verifyCodeSent);
            return BadReq(ApiMessage.BadRequest);

        }
        [AllowAnonymous]
        [HttpPost("reset")]
        public async Task<IActionResult> ResetAdminPassword([FromBody]ForgetPasswordCommand command)
        {
            var result = await _identity.RestoreAdminPassword(command);
            if (result)
                return OkResult(ApiMessage.UserPasswordChanged);
            return BadReq(ApiMessage.BadRequest);
        }
        
    }
}
