using System;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.RepasitoryInterfaces
{
    public interface IUserRepository
    {
        Task<User> SearchAsync(Guid id);

        //        /// <summary>
        //        /// چک کردن unique بودن نام کاربری
        //        /// </summary>
        //        Task<bool> IsUserNameExist(string username);

        //        /// <summary>
        //        /// چک کردن unique بودن کد ملی
        //        /// </summary>
        //        Task<bool> IsNCExist(string nationalCode);

        //        /// <summary>
        //        /// چک کردن unique بودن شاره تلفن
        //        /// </summary>
        //        Task<bool> IsPhoneExist(string phone);

        //        /// <summary>
        //        /// عملیات ثبت نام کاربر :
        //        /// </summary>
        //        Task<bool> UserSignUpAsync(User user);

        //        /// <summary>
        //        /// عملیات وارد شدن کاربر :
        //        /// </summary>
        //        Task<User> UserLoginAsync(string UserName);

        //        /// <summary>
        //        /// گرفتن کاربر با شماره تلفن :
        //        /// </summary>
        //        Task<User> GetUserByPhone(string phone);

        //        /// <summary>
        //        /// ذخیره کردن عملیات انجام شده :
        //        /// </summary>
        //        Task<bool> SaveChanges();

        //        /// <summary>
        //        /// گرفتن کاربر با کد تایید :
        //        /// </summary>
        //        Task<User> GetUserByVerifyCode(string verifyCode);

        /// <summary>
        /// دریافت کاربر با آیدی
        /// </summary>
         Task<User> GetUserById(string id);


        //        /// <summary>
        //        /// پیدا کردن کاربر با نام کاربری
        //        /// </summary>
        //        Task<List<User>> SearchUserByNameOrUsername(string username);

        //        /// <summary>
        //        /// گرفتن کل فروشندگان
        //        /// </summary>
        //        Task<List<User>> GetAllSeller();

        //        /// <summary>
        //        /// گرفتن فایل با آیدی
        //        /// </summary>
        //        Task<MyFile> GetFileById(Guid id);

        //        /// <summary>
        //        /// دریافت همه بلیط های خریده شده یا لغو شده کاربر
        //        /// </summary>
        //        Task<List<Ticket>> AllBuyedOrCanceledUserTickets(Guid id);
    }
    public class QuerySearch
    {
        public string PhoneNumber { get; set; }
    }
}
