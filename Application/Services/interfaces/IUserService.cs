using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Commands.User;
using Application.Dtos;
using Domain.RepasitoryInterfaces;

namespace Application.Services.interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// دریافت کاربر با ایدی
        /// </summary>
        Task<UserDto> SearchUserById(Guid id);


        Task<bool> DeleteAsync(Guid id);


        Task<List<UserDto>> GetAllUser();

        Task<UserDto> GetUser(Guid id);

        ////IncreaseUserWallet
        ///// <summary>
        ///// ثبت نام کاربر :
        ///// </summary>
        ////Task<bool> UserSignUpAsync(UserSignUpCommand command);
        ///// <summary>
        ///// وارد شدن کاربر :
        ///// </summary>
        //Task<UserDto> UserLoginAsync(UserLoginCommand command);

        ///// <summary>
        ///// وارد شدن اعضای جدید
        ///// </summary>
        //Task<UserDto> NewMemberLogin(NewMemberLoginCommand command);

        ///// <summary>
        ///// وارد کردن شماره تلفن و ارسال کد تایید جدید :
        ///// </summary>
        //Task<List<string>> GetPhoneAndSetVerifyCode(GetPhoneAndSetVerifyCodeCommand command);

        ///// <summary>
        ///// عملیات فراموشی رمز عبور :
        ///// </summary>
        //Task<bool> ForgetPasswordAction(ForgetPasswordCommand command);

        ///// <summary>
        ///// ویرایش پروفایل
        ///// </summary>
        //Task<UserDto> UpdateProfileAsync(UpdateUserCommand command);

        ///// <summary>
        ///// جستجوی کاربر
        ///// </summary>
        //Task<List<UserDto>> SearchUser(FindUserCommand command);


        ///// <summary>
        ///// ارتقا دادن کاربر به ادمین
        ///// </summary>
        //Task<UserDto> PromoteToAdmin(Guid id);

        ///// <summary>
        ///// ارتقا دادن کاربر به فروشنده
        ///// </summary>
        //Task<UserDto> PromoteToSeller(Guid id);

        ///// <summary>
        ///// تنزل رتبه کاربر فروشنده/ادمین به خریدار
        ///// </summary>
        //Task<UserDto> DemoteToUser(Guid id);


        ///// <summary>
        ///// دریافت تعداد تفریح کردن کاربر
        ///// </summary>
        //Task<int> UserPlayingFunCount(Guid id);
    }
}
