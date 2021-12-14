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
                var values = new Dictionary<string, string> { { "PhoneNumber", phoneNumber }, { "Message", code } };

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
        /// بلاک کردن کاربر :
        /// </summary>
        [HttpPut("Block/{id}")]
        public async Task<IActionResult> BlockUserAsync(Guid id)
        {
            var result = await _userService.BlockUserAsync(id);
            if (!result)
                return BadReq(ApiMessage.UserNotBlocked, new { Reasons = $"1-user not found, 2-user already blocked" });
            return OkResult(ApiMessage.UserBlocked, new { Result = $"{result} / Blocked" });
        }

        /// <summary>
        /// فعال کردن کاربر - آنبلاک
        /// </summary>
        [HttpPut("UnBlock/{id}")]
        public async Task<IActionResult> UnBlockUserAsync(Guid id)
        {
            var result = await _userService.UnBlockUserAsync(id);
            if (!result)
                return BadReq(ApiMessage.UserNotUnBlocked, new { Reasons = $"1-user not found, 2-user already unblocked(actived)" });
            return OkResult(ApiMessage.UserUnBlocked, new { Result = $"{result} / UnBlocked" });
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
                return BadReq(ApiMessage.NotPromoteSeller, new { Reasons = $"1-user already seller, 2-user not found" });
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

        /// <summary>
        /// اضافه کردن پول به کیف پول کاربر
        /// </summary>
        [HttpPut("IncreaseWallet/{id}")] // dont in Postman
        public async Task<IActionResult> IncreaseUserWallet(Guid id, IncreaseUserWalletCommand command)
        {
            var result = await _userService.IncreaseUserWallet(id, command);
            if (result == null)
                return BadReq(ApiMessage.WalletNotIncreased, new { Reason = $"user not found" });
            return OkResult(ApiMessage.WalletIncreased, new { Cash = result });
        }
        #endregion

        #region GET

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

        /// <summary>
        /// همه کاربر های فعال
        /// </summary>
        [HttpGet("AllActiveUsers")]
        public async Task<IActionResult> AllActiveUsers()
        {
            var result = await _userService.AllActiveUsers();
            if (result == null)
                return BadReq(ApiMessage.AnyActiveUserNotFount, new { UserFoundedCount = $"0" });
            return OkResult(ApiMessage.UsersActiveFound, new { ActiveUsers = result });
        }

        /// <summary>
        /// تعداد همه کاربر های فعال
        /// </summary>
        [HttpGet("AllActiveUsers-Count")]
        public async Task<IActionResult> AllActiveUsersCount()
        {
            var result = await _userService.AllActiveUsersCount();
            if (result == 0)
                return BadReq(ApiMessage.AnyActiveUserNotFount, new { UserFoundedCount = result });
            return OkResult(ApiMessage.UsersActiveFound, new { ActiveUsersCount = result });
        }

        /// <summary>
        ///  همه کاربر های بلاک شده
        /// </summary>
        [HttpGet("AllBlockedUsers")]
        public async Task<IActionResult> AllBlockedUsers()
        {
            var result = await _userService.AllBlockedUsers();
            if (result == null)
                return BadReq(ApiMessage.AnyBlockedUserNotFound, new { UserFoundedCount = $"0" });
            return OkResult(ApiMessage.UsersBlockedFound, new { BlockedUsers = result });
        }

        /// <summary>
        /// تعداد همه کاربر های بلاک شده
        /// </summary>
        [HttpGet("AllBlockedUsers-Count")]
        public async Task<IActionResult> AllBlockedUsersCount()
        {
            var result = await _userService.AllBlockedUsersCount();
            if (result == 0)
                return BadReq(ApiMessage.AnyBlockedUserNotFound, new { UserFoundedCount = result });
            return OkResult(ApiMessage.UsersBlockedFound, new { BlockedUsersCount = result });
        }

        #endregion

        #region Specials

        /// <summary>
        /// ریست کردن کد تایید همه کاربران فعال
        /// </summary>
        [HttpPut("RestartVerifyCode")]
        public async Task<IActionResult> RestartAllActiveUsersVerifyCode()
        {
            var result = await _userService.RestartAllActiveUsersVerifyCode();
            if (!result)
                return BadReq(ApiMessage.AllActiveUsersVerifyCodeNotRestarted, new { Reason = $"any active users not found" });
            return OkResult(ApiMessage.AllActiveUsersVerifyCodeRestarted, new { Message = $"All active users verify code restarted" });
        }

        /// <summary>
        /// آنبلاک کردن همه کاربر های بلاک شده
        /// </summary>
        [HttpPut("UnBlockAllBlocked")]
        public async Task<IActionResult> UnBlockAllBlockedUsers()
        {
            var result = await _userService.UnBlockAllBlockedUsers();
            if (!result)
                return BadReq(ApiMessage.AnyBlockedUserNotFound, new { Reason = $"any active users not found" });
            return OkResult(ApiMessage.AllBlockedUsersUnBlocked, new { Message = $"All blocked users are now active" });
        }

        /// <summary>
        /// دریافت تعداد تفریح کردن کاربر
        /// </summary>
        [HttpGet("UserPlayingFun-Count/{id}")]
        public async Task<IActionResult> UserPlayingFunCount(Guid id)
        {
            var result = await _userService.UserPlayingFunCount(id);
            if (result == 0)
                return BadReq(ApiMessage.UserNotHavePlayAnyFunYet, new { Reason = $"1-user not have play any fun, 2-user id is wrong" });
            return OkResult(ApiMessage.AllUserPlayingFunCount, new { UserPlayingFunCount = result });
        }
        #endregion

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
        //        return BadRequest(new { Message = "یوزر نیم مورد نظر وجود دارد." });
        //}
        #endregion

    }
}
