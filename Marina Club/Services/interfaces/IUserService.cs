using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Marina_Club.Commands.User;
using Marina_Club.Dtos;


namespace Marina_Club.Services.interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// ثبت نام کاربر :
        /// </summary>
        //Task<bool> UserSignUpAsync(UserSignUpCommand command);

        /// <summary>
        /// وارد شدن کاربر :
        /// </summary>
        Task<UserDto> UserLoginAsync(UserLoginCommand command);

        /// <summary>
        /// وارد شدن اعضای جدید
        /// </summary>
        Task<UserDto> NewMemberLogin(NewMemberLoginCommand command);

        /// <summary>
        /// وارد کردن شماره تلفن و ارسال کد تایید جدید :
        /// </summary>
        Task<List<string>> GetPhoneAndSetVerifyCode(GetPhoneAndSetVerifyCodeCommand command);

        /// <summary>
        /// عملیات فراموشی رمز عبور :
        /// </summary>
        Task<bool> ForgetPasswordAction(ForgetPasswordCommand command);

        /// <summary>
        /// ویرایش پروفایل
        /// </summary>
        Task<UserDto> UpdateProfileAsync(UpdateUserCommand command);

        /// <summary>
        /// جستجوی کاربر
        /// </summary>
        Task<List<UserDto>> SearchUser(FindUserCommand command);

        /// <summary>
        /// بلاک کردن کاربر :
        /// </summary>
        Task<bool> BlockUserAsync(Guid id);

        /// <summary>
        /// فعال کردن کاربر :
        /// </summary>
        Task<bool> UnBlockUserAsync(Guid id);

        /// <summary>
        /// ارتقا دادن کاربر به ادمین
        /// </summary>
        Task<UserDto> PromoteToAdmin(Guid id);

        /// <summary>
        /// ارتقا دادن کاربر به فروشنده
        /// </summary>
        Task<UserDto> PromoteToSeller(Guid id);

        /// <summary>
        /// تنزل رتبه کاربر فروشنده/ادمین به خریدار
        /// </summary>
        Task<UserDto> DemoteToUser(Guid id);

        /// <summary>
        /// اضافه کردن پول به کیف پول کاربر
        /// </summary>
        Task<string> IncreaseUserWallet(Guid userid, IncreaseUserWalletCommand command);

        /// <summary>
        /// همه کاربر های فعال
        /// </summary>
        Task<List<UserDto>> AllActiveUsers();

        /// <summary>
        /// تعداد همه کاربر های فعال
        /// </summary>
        Task<int> AllActiveUsersCount();

        /// <summary>
        ///  همه کاربر های بلاک شده
        /// </summary>
        Task<List<UserDto>> AllBlockedUsers();

        /// <summary>
        /// تعداد همه کاربر های بلاک شده
        /// </summary>
        Task<int> AllBlockedUsersCount();

        /// <summary>
        /// ریست کردن کد تایید همه کاربران فعال
        /// </summary>
        Task<bool> RestartAllActiveUsersVerifyCode();

        /// <summary>
        /// آنبلاک کردن همه کاربر های بلاک شده
        /// </summary>
        Task<bool> UnBlockAllBlockedUsers();

        /// <summary>
        /// دریافت تعداد تفریح کردن کاربر
        /// </summary>
        Task<int> UserPlayingFunCount(Guid id);
    }
}
