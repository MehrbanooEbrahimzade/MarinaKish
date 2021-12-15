using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using Application.Commands.User;
using Application.Services.interfaces;

namespace Marina_Club.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ApiController
    {
        private readonly IUserService _userService;
        private static readonly HttpClient client = new HttpClient();

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// وارد کردن شماره تلفن و ارسال کد تایید جدید :
        /// </summary>
        [HttpPost("VerifyPhone")]
        public async Task<IActionResult> GetPhoneAndSetVerifyCode(GetPhoneAndSetVerifyCodeCommand command)
        {
            if (!command.Validate())
                return BadReq(ApiMessage.WrongCellPhone, new { Reason = "cellphone must have 11 charachter (example : 09123456789)" });

            var result = await _userService.GetPhoneAndSetVerifyCode(command);

            await SendSms(result[2], command.PhoneNumber);

            if (result[0] == "Register")
                return OkResult(ApiMessage.userRegisterAndVerifyCodeSent, new { NewUserObj = $"id : {result[1]}, verifyCode : {result[2]}" });

            return OkResult(ApiMessage.userLoggedInAndVerifyCodeSent, new { UserObj = $"id : {result[1]}, verifyCode : {result[2]}" });
        }

        private static async Task SendSms(string code, string phoneNumber)
        {
            try
            {
                var values = new Dictionary<string, string> { { "PhoneNumber", phoneNumber }, { "Text", code } };

                var response = await client.PostAsync("http://localhost:5002/api/Notification/add", values, new JsonMediaTypeFormatter());

                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// وارد شدن کاربر :
        /// </summary>
        [HttpGet("Login/{cellPhone}")]
        public async Task<IActionResult> UserLoginAsync(string cellPhone, UserLoginCommand command)
        {
            command.CellPhone = cellPhone;
            if (!command.Validate())
                return BadReq(ApiMessage.WrongVerifyCode, new { Reason = "1-verify code must have 4 charachter, 2-cellphone must have 11 charachter (example : 09123456789)" });

            var result = await _userService.UserLoginAsync(command);
            if (result == null)
                return BadReq(ApiMessage.WrongVerifyCode, new { Reasons = $"1-user verify code is wrong, 2-wrong user cellPhone" });
            return OkResult(ApiMessage.UserLoggedIn, new { User = result });
        }

        /// <summary>
        /// عملیات فراموش کردن رمز
        /// </summary>
        [HttpPut("Forget-Password/{cellphone}")]
        public async Task<IActionResult> ForgetPasswordAction(string cellphone, ForgetPasswordCommand command)
        {
            command.CellPhone = cellphone;
            if (!command.Validate())
                return BadReq(ApiMessage.WrongInformation, new { Reasons = "1- password must have least 8 charachter, 2-verify code must have 4 charachter, 3-cellphone must have 11 charachter (example : 09123456789)" });

            var result = await _userService.ForgetPasswordAction(command);
            if (!result)
                return BadReq(ApiMessage.UserPasswordChangeFail, new { Reasons = $"1-new password and repeat new password are diffrent, 2-verify code is wrong" });
            return OkResult(ApiMessage.UserPasswordChanged, new { IsPasswordChanged = result });
        }
        #region PUT

        /// <summary>
        /// ورود کاربران جدید
        /// </summary>
        [HttpPut("SetUsernameForNewMembers/{cellPhone}")]
        public async Task<IActionResult> NewMemberLogin(string cellPhone, NewMemberLoginCommand command)
        {
            command.CellPhone = cellPhone;
            if (!command.Validate())
                return BadReq(ApiMessage.WrongInformation, new { Reasons = "1-cellphone must have 11 charachter, 2-firstname can't be null(max : 70 charachter), 3-password must have least 8 charachter, 4-user name can null(min:5 && max:50)" });

            var result = await _userService.NewMemberLogin(command);
            if (result == null)
                return BadReq(ApiMessage.UsernameIsExistOrNotNewUser, new { Reasons = $"1-username is already exist, 2-user not found" });
            return OkResult(ApiMessage.NewUserLoggedIn, new { NewUser = result });
        }

        /// <summary>
        /// ویرایش پروفایل :
        /// </summary>
        [HttpPut("Update-profile/{id}")]
        public async Task<IActionResult> UpdateProfileAsync(Guid id, UpdateUserCommand command)
        {
            command.ID = id;
            if (!command.Validate())
                return BadReq(ApiMessage.WrongInformation, new { Reasons = "1-Id is wrong, 2-firstname can't be null(max : 70 charachter), 3-Gender can't be null(1:man 2:woman 3:other), 4-username can null(min:5 && max:50), 5-email can null ( but maybe you entered wrong email )" });

            var result = await _userService.UpdateProfileAsync(command);
            if (result == null)
                return BadReq(ApiMessage.ProfileNotUpdated, new { Reasons = $"1-username already exist, 2-user not found" });
            return OkResult(ApiMessage.ProfileUpdated, new { UserInfo = result });
        }


        /// <summary>
        /// ارتقا دادن کاربر به ادمین :
        /// </summary>
        [HttpPut("Promote-Admin/{id}")]
        public async Task<IActionResult> PromoteToAdmin(Guid id)
        {
            var result = await _userService.PromoteToAdmin(id);
            if (result == null)
                return BadReq(ApiMessage.NotPromoteAdmin, new { Reason = $"1-user already admin, 2-user not found" });
            return OkResult(ApiMessage.PromoteAdmin, new { UserInfo = result });
        }

        /// <summary>
        /// ارتقا دادن کاربر به فروشنده :
        /// </summary>
        [HttpPut("Promote-Seller/{id}")]
        public async Task<IActionResult> PromoteToSeller(Guid id)
        {
            var result = await _userService.PromoteToSeller(id);
            if (result == null)
                return BadReq(ApiMessage.NotPromoteSeller, new { Reasons = "user already seller or user not found" });
            return OkResult(ApiMessage.PromoteSeller, new { UserInfo = result });
        }

        /// <summary>
        /// تنزل رتبه کاربر فروشنده/ادمین به خریدار
        /// </summary>
        [HttpPut("Demote-User/{id}")]
        public async Task<IActionResult> DemoteToUser(Guid id)
        {
            var result = await _userService.DemoteToUser(id);
            if (result == null)
                return BadReq(ApiMessage.NotDemoteUser, new { Reasons = $"1-user is not admin or seller, 2-user not found" });
            return OkResult(ApiMessage.DemoteUser, new { UserInfo = result });
        }

        #endregion


        /// <summary>
        /// جستجوی کاربر :
        /// </summary>
        [HttpGet("FindUser")]
        public async Task<IActionResult> SearchUser(FindUserCommand command)
        {
            if (!command.Validate())
                return BadReq(ApiMessage.EnterUsername, new { Reason = $"username for find required" });

            var result = await _userService.SearchUser(command);
            if (result == null)
                return BadReq(ApiMessage.UserNotFound, new { Reason = $"any user by this search not found" });
            return OkResult(ApiMessage.UserFound, new { FoundedUsers = result });
        }


        #region ForgetPass(newVersion)
        /// <summary>
        /// عملیات فراموشی رمز عبور :
        /// </summary>
        //[HttpPut("Forget-Action")]
        //public async Task<IActionResult> ForgetActionAsync(ForgetPasswordCommand command)
        //{
        //    command.Validate();
        //    var result = await _userService.ForgetActionAsync(command);
        //    if (result)
        //        return OkResult(ApiMessage.Ok);

        //    return BadReq(ApiMessage.BadRequest);
        //}
        #endregion
        #region new version login
        //[HttpGet("Login")]
        //public async Task<IActionResult> UserLoginAsync(UserLoginCommand command)
        //{
        //    var result = await _userService.UserLoginAsync(command);
        //    return Ok(result);
        //}
        #endregion
        #region new version SignUp
        //[HttpPost("Sign-Up")]
        //public async Task<IActionResult> UserSignUpAsync(UserSignUpCommand command)
        //{
        //    command.Validate();
        //    var result = await _userService.UserSignUpAsync(command);

        //    if (result)
        //        return Ok(result);
        //    else
        //        return BadRequest(new { Text = "یوزر نیم مورد نظر وجود دارد." });
        //}
        #endregion

    }
}
