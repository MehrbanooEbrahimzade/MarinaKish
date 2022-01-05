using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Commands;
using Application.Commands.Ticket;
using Application.Dtos;

namespace Application.Services.interfaces
{
    public interface ITicketService
    {
        /// <summary>
        /// اضافه کردن بلیط خریده شده در سایت - به سبد خرید
        /// </summary>
        Task<Guid?> AddTicketToSite(AddTicketToBasketCommand command);

        /// <summary> 
        /// پاک کردن بلیط  
        /// </summary>
        Task<bool> DeleteTicket(Guid id);


        /// <summary>
        /// گرفتن همه بلیط های یک سانس
        /// </summary>
        Task<List<TicketDto>> GetAllScheduleTickets(Guid id);

        ///// <summary>
        ///// گرفتن همه بلیط های فعال یک سانس
        ///// </summary>
        //Task<List<TicketDto>> GetAllScheduleActiveTickets(Guid id);

        /// <summary>
        /// گرفتن یک بلیط با شماره بلیط
        /// </summary>
        Task<TicketDto> GetOneTicket(Guid id);

        /// <summary>
        /// عوض کزدن وضعیت یک بلیط
        /// </summary>
        Task<bool> ChangeTicketCondition(EditTicketConditionCommand command);

        ///<summary>
        /// برگردوندن تمام بلیط ها با وضعیت ها و محل های متفاوت 
        /// </summary>
        Task<List<TicketDto>> GetAll(GetAllTicketByAllModesCommand Command);

        ///<summary>
        ///برکردوندن اطلاعات بلیط با توجه مکان فروش
        /// </summary>
        //Task<List<TicketDto>> GetAllbyPlaceOfSale(GetAllTicketByAllModesCommand Command);

        ///// <summary>
        ///// ثبت خرید و فعال کردن(رزرو) بلیط
        ///// </summary>
        //Task<TicketDto> EntryBuyTicket(Guid id);

        ///// <summary>
        ///// لغو بلیط
        ///// </summary>
        //Task<decimal?> CancelTicket(Guid id);

        /// <summary>
        /// دریافت مقدار پول کل بلیط های فروخته شده
        /// </summary>
        Task<decimal> ScheduleTicketsPrice(Guid schedulId);

        ///// <summary>
        ///// جست و جوی بلیط فعال با یک تاریخ
        ///// </summary>
        //Task<List<TicketDto>> SearchReservedTicketsByDate(DateTime firstMiadiParse);

        ///// <summary>
        ///// جست و جوی بلیط فعال با دو تاریخ
        ///// </summary>
        //Task<List<TicketDto>> SearchReservedTicketsByDate(DateTime firstMiadiParse, DateTime secondMiladiParse);

        /// <summary>
        ///  جست و جوی یک تاریخه برای جمع مبلغ بلیط های فعال
        /// </summary>
        Task<decimal> SearchReservedTicketsPriceByDateSum(DateTime firstMiadiParse);

        ///// <summary>
        /////  جست و جوی دو تاریخه برای جمع مبلغ بلیط های فعال
        ///// </summary>
        //Task<decimal> SearchReservedTicketsPriceByDateSum(DateTime firstMiadiParse, DateTime secondMiladiParse);

        ///// <summary>
        ///// جست و جوی بلیط غیرفعال با یک تاریخ
        ///// </summary>
        //Task<List<TicketDto>> SearchInActivedTicketsByDate(DateTime firstMiadiParse);

        ///// <summary>
        ///// جست و جوی بلیط غیرفعال با دو تاریخ
        ///// </summary>
        //Task<List<TicketDto>> SearchInActivedTicketsByDate(DateTime firstMiadiParse, DateTime secondMiladiParse);

        ///// <summary>
        ///// جست و جوی بلیط لغو شده با یک تاریخ
        ///// </summary>
        //Task<List<TicketDto>> SearchCanceledTicketsByDate(DateTime firstMiadiParse);

        ///// <summary>
        ///// جست و جوی بلیط لغو شده با دو تاریخ
        ///// </summary>
        //Task<List<TicketDto>> SearchCanceledTicketsByDate(DateTime firstMiadiParse, DateTime secondMiladiParse);


        ///// <summary>
        ///// اضافه کردن بلیط خریده شده بصورت حضوری
        ///// </summary>
        //Task<TicketDto> AddTicketFromPresence(AddTicketFromPresenceCommand command);

        ///// <summary>
        ///// دریافت همه بلیط های لغو شده یک سانس
        ///// </summary>
        //Task<List<TicketDto>> GetAllScheduleCanceledTickets(Guid id);

        ///// <summary>
        ///// دریافت همه بلیط های یک تفریح با آیدی تفریح
        ///// </summary>
        //Task<List<TicketDto>> GetAllFunTicketsWithFunID(Guid id);

        /// <summary>
        /// دریافت همه بلیط های رزرو شده یک تفریح با نام تفریح
        /// </summary>
        Task<List<TicketDto>> GetAllFunActiveTicketsWithFunName(string funName);

        ///// <summary>
        ///// دریافت همه بلیط های لغو شده یک تفریح با آیدی تفریح
        ///// </summary>
        //Task<List<TicketDto>> GetAllFunCanceledTicketsWithFunID(Guid id);

        ///// <summary>
        ///// دریافت همه بلیط های یک کاربر با آیدی کاربر
        ///// </summary>
        //Task<List<TicketDto>> GetAllUserTikcetsWithUserID(Guid id);

        ///// <summary>
        ///// دریافت همه بلیط های رزرو یک کاربر با آیدی کاربر
        ///// </summary>
        //Task<List<TicketDto>> GetAllUserActiveTikcetsWithUserID(Guid id);

        ///// <summary>
        ///// دریافت همه بلیط های لغو شده یک کاربر با آیدی کاربر
        ///// </summary>
        //Task<List<TicketDto>> GetAllUserCanceledTikcetsWithUserID(Guid id);

        ///// <summary>
        ///// دریافت همه بلیط های رزروی خریده شده بصورت حضوری
        ///// </summary>
        //Task<List<TicketDto>> AllPresenceReservationTickets();

        ///// <summary>
        ///// دریافت همه بلیط های رزروی خریده شده از سایت
        ///// </summary>
        //Task<List<TicketDto>> AllSiteReservationTickets();

        ///// <summary>
        ///// دریافت همه بلیط ها
        ///// </summary>
        //Task<List<TicketDto>> AllTickets();

        ///// <summary>
        ///// دریافت همه بلیط های لغو شده
        ///// </summary>
        //Task<List<TicketDto>> AllCanceledTickets();

        ///// <summary>
        ///// دریافت همه بلیط های رزرو شده
        ///// </summary>
        //Task<List<TicketDto>> AllReservationTickets();

        /// <summary>
        /// دریافت کل بلیط های غیرفعال یک سانس
        /// </summary>
        Task<List<TicketDto>> AllInActiveScheduleTickets(Guid id);

        ///// <summary>
        ///// دریافت کل بلیط های غیرفعال یک تفریح با آیدی تفریح
        ///// </summary>
        //Task<List<TicketDto>> AllFunInActiveTickets(Guid id);

        ///// <summary>
        ///// دریافت کل بلیط های غیرفعال یک کاربر - سبد خرید
        ///// </summary>
        //Task<List<TicketDto>> AllUserInActiveTickets(Guid id);

        ///// <summary>
        ///// تغییر وضعیت بلیط های انجام شده به بازی شده
        ///// </summary>
        //Task<int> SetPerformedTicketsToPlayed();

        /// <summary>
        /// حذف بلیط از سبد خرید
        /// </summary>
        Task<List<Guid?>> DeleteTicketsFromBasketBuy(IdListCommand command);
    }
}