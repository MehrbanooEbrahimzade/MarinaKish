using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Models.enums;

namespace Infrastructure.Repository.interfaces
{
    public interface ITicketRepository
    {
    ///// <summary>
    ////    /// چک کننده وجود داشتن یوزر
    ////    /// </summary>
    ////    Task<bool> AnyUserExist(string cellPhone);

    //    /// <summary>
    //    /// دریافت سانس با آیدی
    //    /// </summary>
    //    Task<Schedule> GetScheduleByIdAsync(Guid id);

    //    ///// <summary>
    //    ///// دریافت تفریح با اسم تفریح
    //    ///// </summary>
    //    //Task<Fun> GetFunByFunType(EFunType eFun);
        
    //    /// <summary>
    //    /// دریافت کاربر با شماره تلفن همراه
    //    /// </summary>
    //    Task<User> GetUserByPhone(string phone);

    //    /// <summary>
    //    /// اضافه کردن بلیط 
    //    /// </summary>
    //    Task<bool> AddTicketAsync(Ticket ticket);

    //    /// <summary>
    //    /// دریافت همه بلیط های یک سانس
    //    /// </summary>
    //    Task<List<Ticket>> GetAllScheduleTickets(Guid id);

    //    /// <summary>
    //    /// گرفتن همه بلیط های فعال یک سانس
    //    /// </summary>
    //    Task<List<Ticket>> GetAllScheduleActiveTickets(Guid id);

    //    ///// <summary>
    //    ///// گرفتن همه بلیط های یک تفریح
    //    ///// </summary>
    //    //Task<List<Ticket>> GetAllFunTickets(EFunType eFun);

    //    ///// <summary>
    //    ///// گرفتن همه بلیط های یک کاربر با شماره تلفن
    //    ///// </summary>
    //    //Task<List<Ticket>> GetAllUserTikcets(string phone);

    //    ///// <summary>
    //    ///// گرفتن بلیط با شماره بلیط
    //    ///// </summary>
    //    //Task<Ticket> GetTicketbyTicketNumber(string ticketnumber);

    //    /// <summary>
    //    /// گرفتن بلیط با آیدی
    //    /// </summary>
    //    Task<Ticket> GetTicketById(Guid id);

    //    ///// <summary>
    //    ///// گرفتن بلیط ثبت نشده با آیدی
    //    ///// </summary>
    //    //Task<Ticket> GetNotReservedTicketById(Guid id);

    //    ///// <summary>
    //    ///// گرفتن بلیط لغو نشده با آیدی
    //    ///// </summary>
    //    //Task<Ticket> GetNotCanceledTicketById(Guid id);


    //    /// <summary>
    //    /// ثبت تغییرات
    //    /// </summary>
    //    Task<bool> SaveChangesAsync();

    //    ///// <summary>
    //    ///// دریافت تعداد بلیط های فروخته شده برای یک تفریح
    //    ///// </summary>
    //    //Task<int> ScheduleTicketsCount(Guid id);

    //    ///// <summary>
    //    ///// دریافت مقدار پول کل بلیط های فروخته شده
    //    /////// </summary>
    //    //Task<decimal> ScheduleTicketsPrice(Guid id);
        
    //    /// <summary>
    //    ///  جست و جوی دو تاریخه برای بلیط های غیر فعال
    //    /// </summary>
    //    Task<List<Ticket>> TwoDateInActivedTicketsSearch(DateTime firstDate, DateTime secondDate);

    //    /// <summary>
    //    ///  جست و جوی دو تاریخه برای بلیط های فعال
    //    /// </summary>
    //    Task<List<Ticket>> TwoDateReservedTicketsSearch(DateTime firstDate, DateTime secondDate);

    //    /// <summary>
    //    ///  جست و جوی دو تاریخه برای بلیط های لغو شده
    //    /// </summary>
    //    Task<List<Ticket>> TwoDateCanceledTicketsSearch(DateTime firstDate, DateTime secondDate);

    //    /// <summary>
    //    ///  جست و جوی دو تاریخه برای جمع مبلغ بلیط های فعال
    //    /// </summary>
    //    Task<decimal> TwoDateReservedTicketsPriceSearchSum(DateTime firstDate, DateTime secondDate);

    //    /// <summary>
    //    ///  جست و جوی یک تاریخه برای بلیط های غیرفعال
    //    /// </summary>
    //    Task<List<Ticket>> OneDateInActivedTicketSearch(DateTime firstDate);

    //    /// <summary>
    //    ///  جست و جوی یک تاریخه برای بلیط های فعال
    //    /// </summary>
    //    Task<List<Ticket>> OneDateReservedTicketSearch(DateTime firstDate);

    //    /// <summary>
    //    ///  جست و جوی یک تاریخه برای بلیط های لغو شده
    //    /// </summary>
    //    Task<List<Ticket>> OneDateCanceledTicketSearch(DateTime firstDate);

    //    /// <summary>
    //    ///  جست و جوی یک تاریخه برای جمع مبلغ بلیط های فعال
    //    /// </summary>
    //    Task<decimal> OneDateReservedTicketsPriceSearchSum(DateTime firstDate);

    //    /// <summary>
    //    /// پاک کردن بلیط
    //    /// </summary>
    //    Task<bool> DeleteTicket(Ticket ticket);

    //    /// <summary>
    //    /// دریافت کاربر با آیدی
    //    /// </summary>
    //    Task<User> GetUserById(Guid id);

    //    ///// <summary>
    //    ///// دریافت کاربر فعال با آیدی
    //    ///// </summary>
    //    //Task<User> GetActiveUserById(Guid id);


    //    /// <summary>
    //    /// دریافت همه بلیط های لغو شده یک سانس
    //    /// </summary>
    //    Task<List<Ticket>> GetAllScheduleCanceledTickets(Guid id);

    //    /// <summary>
    //    /// دریافت همه بلیط های یک تفریح با آیدی تفریح
    //    /// </summary>
    //    Task<List<Ticket>> GetAllFunTicketsWithFunID(Guid id);

    //    /// <summary>
    //    /// دریافت همه بلیط های فعال یک تفریح با آیدی تفریح
    //    /// </summary>
    //    Task<List<Ticket>> GetAllFunActiveTicketsWithFunID(Guid id);

    //    /// <summary>
    //    /// دریافت همه بلیط های لغو شده یک تفریح با آیدی تفریح
    //    /// </summary>
    //    Task<List<Ticket>> GetAllFunCanceledTicketsWithFunID(Guid id);

    //    ///// <summary>
    //    ///// دریافت همه بلیط های یک کاربر با آیدی کاربر
    //    ///// </summary>
    //    //Task<List<Ticket>> GetAllUserTikcetsWithUserID(Guid id);

    //    /// <summary>
    //    /// دریافت همه بلیط های فعال یک کاربر با آیدی کاربر
    //    /// </summary>
    //    //Task<List<Ticket>> GetAllUserActiveTikcetsWithUserID(Guid id);

    //    /// <summary>
    //    /// دریافت همه بلیط های لغو شده یک کاربر با آیدی کاربر
    //    /// </summary>
    //    //Task<List<Ticket>> GetAllUserCanceledTikcetsWithUserID(Guid id);

    //    /// <summary>
    //    /// دریافت همه بلیط های رزروی خریده شده بصورت حضوری
    //    /// </summary>
    //    Task<List<Ticket>> AllPresenceReservationTickets();

    //    /// <summary>
    //    /// دریافت همه بلیط های رزروی خریده شده از سایت
    //    /// </summary>
    //    Task<List<Ticket>> AllSiteReservationTickets();

    //    /// <summary>
    //    /// دریافت همه بلیط ها
    //    /// </summary>
    //    Task<List<Ticket>> AllTickets();

    //    /// <summary>
    //    /// دریافت همه بلیط های لغو شده
    //    /// </summary>
    //    Task<List<Ticket>> AllCanceledTickets();

    //    /// <summary>
    //    /// دریافت همه بلیط های رزرو شده
    //    /// </summary>
    //    Task<List<Ticket>> AllReservationTickets();

    //    ///// <summary>
    //    ///// دریافت تعداد کل بلیط ها
    //    ///// </summary>
    //    //Task<int> AllTicketsCount();

    //    ///// <summary>
    //    ///// دریافت تعداد کل بلیط های لغو شده
    //    ///// </summary>
    //    //Task<int> AllCanceledTicketsCount();

    //    ///// <summary>
    //    ///// دریافت تعداد کل بلیط های رزرو شده
    //    ///// </summary>
    //    //Task<int> AllReservationTicketsCount();

    //    ///// <summary>
    //    ///// دریافت تعداد کل بلیط های رزرو شده یک سانس
    //    ///// </summary>
    //    ////Task<int> ReservationScheduleTicketsCount(Guid id);

    //    ///// <summary>
    //    ///// دریافت تعداد کل بلیط های لغو شده یک سانس
    //    ///// </summary>
    //    //Task<int> CanceledScheduleTicketsCount(Guid id);

    //    ///// <summary>
    //    ///// دریافت تعداد کل بلیط های غیرفعال یک سانس
    //    ///// </summary>
    //    //Task<int> InActiveScheduleTicketsCount(Guid id);

    //    /// <summary>
    //    /// دریافت کل بلیط های غیرفعال یک سانس
    //    /// </summary>
    //    Task<List<Ticket>> AllInActiveScheduleTickets(Guid id);
    
    //    ///// <summary>
    //    ///// دریافت تعداد کل بلیط های رزرو شده یک تفریح
    //    ///// </summary>
    //    //Task<int> ReservationFunTicketsCount(Guid id);

    //    /// <summary>
    //    /// دریافت تفریح با آیدی
    //    /// </summary>
    //    Task<Fun> GetFunById(Guid id);

    //    /// <summary>
    //    /// دریافت کل بلیط های غیرفعال یک تفریح با آیدی تفریح
    //    /// </summary>
    //    Task<List<Ticket>> AllFunInActiveTickets(Guid id);

    //    ///// <summary>
    //    ///// دریافت تعداد کل بلیط های غیرفعال یک تفریح با آیدی تفریح
    //    ///// </summary>
    //    //Task<int> AllFunInActiveTicketsCount(Guid id);

    //    ///// <summary>
    //    ///// دریافت تعداد کل بلیط های لغو شده یک تفریح با آیدی تفریح
    //    ///// </summary>
    //    //Task<int> CanceledFunTicketsCount(Guid id);

    //    /// <summary>
    //    /// دریافت کل بلیط های غیرفعال یک کاربر - سبد خرید
    //    ///// </summary>
    //    //Task<List<Ticket>> AllUserInActiveTickets(Guid id);

    //    ///// <summary>
    //    ///// دریافت تعداد کل بلیط های غیرفعال یک کاربر
    //    ///// </summary>
    //    //Task<int> InActiveUserTicketsCount(Guid id);

    //    ///// <summary>
    //    ///// دریافت تعداد کل بلیط های رزرو یک کاربر
    //    ///// </summary>
    //    //Task<int> ReservationUserTicketsCount(Guid id);

    //    ///// <summary>
    //    ///// دریافت تعداد کل بلیط های لغو شده یک کاربر
    //    ///// </summary>
    //    //Task<int> CanceledUserTicketsCount(Guid id);

    //    /// <summary>
    //    /// دریافت سانس فعال با آیدی
    //    /// </summary>
    //    Task<Schedule> GetActiveScheduleById(Guid id);

    //    /// <summary>
    //    /// دریافت بلیط غیرفعال با آیدی
    //    /// </summary>
    //    Task<Ticket> GetInActiveTicketById(Guid id);

    //    /// <summary>
    //    /// دریافت بلیط فعال با آیدی
    //    /// </summary>
    //    Task<Ticket> GetReservedTicketById(Guid id);

    //    /// <summary>
    //    /// دریافت همه بلیط های سانس های انجام شده
    //    /// </summary>
    //    Task<List<Ticket>> GetAllPerformedTickets();

    //    /// <summary>
    //    /// حذف بلیط از سبد خرید
    //    /// </summary>
    //    Task<bool> DeleteTicketsFromBasketBuy(Ticket ticket);

    //    /// <summary>
    //    /// دریافت بلیط در سبد خرید با آیدی
    //    /// </summary>
    //    Task<Ticket> GetTicketInBasketBuyById(Guid id);

    }
}
