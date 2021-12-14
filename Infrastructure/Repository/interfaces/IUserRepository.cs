using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

namespace Infrastructure.Repository.interfaces
{
    public interface IUserRepository
    {
        /// <summary>
        /// چک کردن unique بودن نام کاربری
        /// </summary>
        Task<bool> IsUserNameExist(string username);

        /// <summary>
        /// چک کردن unique بودن کد ملی
        /// </summary>
        Task<bool> IsNCExist(string nationalCode);

        /// <summary>
        /// چک کردن unique بودن شاره تلفن
        /// </summary>
        Task<bool> IsPhoneExist(string phone);

        /// <summary>
        /// عملیات ثبت نام کاربر :
        /// </summary>
        Task<bool> UserSignUpAsync(User user);

        /// <summary>
        /// عملیات وارد شدن کاربر :
        /// </summary>
        Task<User> UserLoginAsync(string UserName);

        /// <summary>
        /// گرفتن کاربر با شماره تلفن :
        /// </summary>
        Task<User> GetUserByPhone(string phone);

        /// <summary>
        /// ذخیره کردن عملیات انجام شده :
        /// </summary>
        Task<bool> UpdateUserAsync();

        /// <summary>
        /// گرفتن کاربر با کد تایید :
        /// </summary>
        Task<User> GetUserByVerifyCode(string verifyCode);

        /// <summary>
        /// دریافت کاربر با آیدی
        /// </summary>
        Task<User> GetUserById(Guid id);

        /// <summary>
        /// دریافت کاربر فعال با آیدی
        /// </summary>
        Task<User> GetActiveUserById(Guid id);

        /// <summary>
        /// دریافت کاربری که فروشنده نیست با آیدی
        /// </summary>
        Task<User> GetNotSellerUserById(Guid id);

        /// <summary>
        /// دریافت کاربری که ادمین نیست با آیدی
        /// </summary>
        Task<User> GetNotAdminUserById(Guid id);

        /// <summary>
        /// دریافت کاربری که ادمین یا فروشنده است با آیدی
        /// </summary>
        Task<User> GetAdminOrSellerUserById(Guid id);

        /// <summary>
        /// پیدا کردن کاربر با نام کاربری
        /// </summary>
        Task<List<User>> SearchUserByNameOrUsername(string username);

        /// <summary>
        /// گرفتن کل فروشندگان
        /// </summary>
        Task<List<User>> GetAllSeller();

        /// <summary>
        /// گرفتن فایل با آیدی
        /// </summary>
        Task<File> GetFileById(Guid id);

        /// <summary>
        /// دریافت کاربر بلاک شده
        /// </summary>
        Task<User> GetBlockedUser(Guid userid);

        /// <summary>
        /// همه کاربر های فعال
        /// </summary>
        Task<List<User>> AllActiveUsers();

        /// <summary>
        /// تعداد همه کاربر های فعال
        /// </summary>
        Task<int> AllActiveUsersCount();

        /// <summary>
        ///  همه کاربر های بلاک شده
        /// </summary>
        Task<List<User>> AllBlockedUsers();

        /// <summary>
        /// تعداد همه کاربر های بلاک شده
        /// </summary>
        Task<int> AllBlockedUsersCount();

        /// <summary>
        /// دریافت همه بلیط های خریده شده یا لغو شده کاربر
        /// </summary>
        Task<List<Ticket>> AllBuyedOrCanceledUserTickets(Guid id);
    }
}
