using Marina_Club.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Marina_Club.Repository.interfaces
{
    public interface ISellerRepository
    {
        /// <summary>
        /// دریافت همه فروشندگان
        /// </summary>
        Task<List<User>> GetAllSellers();

        /// <summary>
        /// دریافت تعداد همه فروشندگان
        /// </summary>
        Task<int> GetAllSellersCount();

        /// <summary>
        /// دریافت بلیط های خریده شده توسط فروشنده
        /// </summary>
        Task<List<Ticket>> GetAllSellerTickets(Guid id);

        /// <summary>
        /// دریافت تعداد بلیط های خریده شده توسط فروشنده
        /// </summary>
        Task<int> GetAllSellerTicketsCount(Guid id);

        /// <summary>
        /// چک کردن درست بودن ایدی برای فروشنده
        /// </summary>
        Task<bool> CheckUserIdForSeller(Guid id);

        /// <summary>
        /// دریافت تمامی بلیط های اخیر
        /// </summary>
        Task<List<Ticket>> GetAllRecentlyTickets();

        /// <summary>
        /// دریافت سانس فعال
        /// </summary>
        Task<Schedule> GetActiveScheduleById(Guid id);

        /// <summary>
        /// دریافت تفریح
        /// </summary>
        Task<Fun> GetFunById(Guid id);

        /// <summary>
        /// دریافت فروشنده فعال
        /// </summary>
        Task<User> GetActiveSellerById(Guid id);

        /// <summary>
        /// اضافه کردن بلیط
        /// </summary>
        Task<bool> AddTicketAsync(Ticket ticketModel);

        /// <summary>
        /// ذخیره اعمال انجام شده
        /// </summary>
        Task<bool> SaveChanges();

        /// <summary>
        /// چک کننده وجود داشتن کد ملی
        /// </summary>
        Task<bool> AnyNationalCodeAsync(string nationalCode);
    }
}
