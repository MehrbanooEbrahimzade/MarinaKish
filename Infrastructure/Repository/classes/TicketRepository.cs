using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Models.enums;
using Infrastructure.Repository.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.classes
{
    public class TicketRepository : BaseRepository, ITicketRepository
    {
        public TicketRepository(DatabaseContext context) : base(context)
        {

        }

        /// <summary>
        /// چک کننده وجود داشتن یوزر
        /// </summary>
        public async Task<bool> AnyUserExist(string cellPhone)
        {
            return await _context.Users
                .AnyAsync(x => x.CellPhone == cellPhone && x.IsActive == true);
        }

        /// <summary>
        /// دریافت سانس با آیدی
        /// </summary>
        public async Task<Schedule> GetScheduleByIdAsync(Guid id)
        {
            return await _context.Schedules
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        /// <summary>
        /// دریافت تفریح با اسم تفریح
        /// </summary>
        public async Task<Fun> GetFunByFunType(FunType fun)
        {
            return await _context.Funs
                .FirstOrDefaultAsync(x => x.FunType == fun);
        }

        /// <summary>
        /// دریافت کاربر با شماره تلفن همراه
        /// </summary>
        public async Task<User> GetUserByPhone(string phone)
        {
            return await _context.Users
                .FirstOrDefaultAsync(x => x.CellPhone == phone && x.IsActive == true);
        }

        /// <summary>
        /// اضافه کردن بلیط
        /// </summary>
        public async Task<bool> AddTicketAsync(Ticket ticket)
        {
            await _context.Tickets.AddAsync(ticket);
            return await _context.SaveChangesAsync() > 0;
        }


        /// /// <summary>
        /// گرفتن همه بلیط های فعال یک سانس
        /// </summary>
        public async Task<List<Ticket>> GetAllScheduleActiveTickets(Guid id)
        {
            return await _context.Tickets
                .Where(x => x.ScheduleId == id && x.Condition == ECondition.Reservation)
                .OrderByDescending(x => x.SubmitDate)
                .ToListAsync();
        }

        /// <summary>
        /// دریافت همه بلیط های یک سانس
        /// </summary>
        public async Task<List<Ticket>> GetAllScheduleTickets(Guid id)
        {
            return await _context.Tickets
                .Where(x => x.ScheduleId == id)
                .OrderByDescending(x => x.SubmitDate)
                .ToListAsync();
        }

        /// <summary>
        /// دریافت تمام بلیط های یک تفریح
        /// </summary>
        public async Task<List<Ticket>> GetAllFunTickets(FunType fun)
        {
            return await _context.Tickets
                .Where(x => x.FunType == fun && x.Condition == ECondition.Reservation && x.ScheduleMiladiTime >= DateTime.Now /* && x.ExecuteDate <= DateTime.Now.AddDays(7)*/)
                .OrderByDescending(x => x.SubmitDate)
                .ToListAsync();
        }

        /// <summary>
        /// گرفتن همه بلیط های رزروی یک کاربر
        /// </summary>
        public async Task<List<Ticket>> GetAllUserTikcets(string phone)
        {
            return await _context.Tickets
                .Where(x => x.CellPhone == phone && x.Condition == ECondition.Reservation)

                .ToListAsync();
        }

        /// <summary>
        /// گرفتن بلیط با شماره بلیط
        /// </summary>
        public async Task<Ticket> GetTicketbyTicketNumber(string ticketnumber)
        {
            return await _context.Tickets
                .FirstOrDefaultAsync(x => x.TicketNumber == ticketnumber && x.Condition == ECondition.Reservation);
        }

        /// <summary>
        /// گرفتن بلیط با آیدی
        /// </summary>
        public async Task<Ticket> GetTicketById(Guid id)
        {
            return await _context.Tickets
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <summary>
        /// ثبت تغییرات
        /// </summary>
        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// دریافت تعداد بلیط های فروخته شده برای یک تفریح
        /// </summary>
        public async Task<int> ScheduleTicketsCount(Guid id)
        {
            return await _context.Tickets
                .CountAsync(x => x.ScheduleId == id && x.Condition == ECondition.Reservation);
        }

        /// <summary>
        /// دریافت مقدار پول کل بلیط های فروخته شده
        /// </summary>
        public async Task<decimal> ScheduleTicketsPrice(Guid id)
        {
            return await _context.Tickets
                .Where(x => x.ScheduleId == id && x.Condition == ECondition.Reservation)
                .SumAsync(x => x.Price);
        }

        #region Search Options

        /// <summary>
        ///  جست و جوی دو تاریخه برای بلیط های فعال
        /// </summary>
        public async Task<List<Ticket>> TwoDateReservedTicketsSearch(DateTime firstDate, DateTime secondDate)
        {
            return await _context.Tickets
                .FromSql("Select * from dbo.Tickets as t Where t.SubmitDate Between {0} And {1}", firstDate, secondDate)
                .Where(x => x.Condition == ECondition.Reservation)
                .OrderByDescending(x => x.SubmitDate)
                .ToListAsync();
        }

        /// <summary>
        ///  جست و جوی یک تاریخه برای بلیط های فعال
        /// </summary>
        public async Task<List<Ticket>> OneDateReservedTicketSearch(DateTime firstDate)
        {
            return await _context.Tickets
                .Where(x => x.SubmitDate.Year == firstDate.Year && x.SubmitDate.Month == firstDate.Month && x.SubmitDate.Day == firstDate.Day && x.Condition == ECondition.Reservation)
                .OrderByDescending(x => x.SubmitDate)
                .ToListAsync();
        }

        /// <summary>
        ///  جست و جوی دو تاریخه برای جمع مبلغ بلیط های فعال
        /// </summary>
        public async Task<decimal> TwoDateReservedTicketsPriceSearchSum(DateTime firstDate, DateTime secondDate)
        {
            return await _context.Tickets
            .FromSql("Select * from dbo.Tickets as t Where t.SubmitDate Between {0} And {1}", firstDate, secondDate)
            .Where(x => x.Condition == ECondition.Reservation)
            .SumAsync(x => x.Price);
        }

        /// <summary>
        ///  جست و جوی یک تاریخه برای جمع مبلغ بلیط های فعال
        /// </summary>
        public async Task<decimal> OneDateReservedTicketsPriceSearchSum(DateTime firstDate)
        {
            return await _context.Tickets
            .Where(x => x.SubmitDate.Year == firstDate.Year && x.SubmitDate.Month == firstDate.Month && x.SubmitDate.Day == firstDate.Day && x.Condition == ECondition.Reservation)
            .SumAsync(x => x.Price);
        }

        /// <summary>
        ///  جست و جوی دو تاریخه برای بلیط های غیرفعال
        /// </summary>
        public async Task<List<Ticket>> TwoDateInActivedTicketsSearch(DateTime firstDate, DateTime secondDate)
        {
            return await _context.Tickets
            .FromSql("Select * from dbo.Tickets as t Where t.SubmitDate Between {0} And {1}", firstDate, secondDate)
            .Where(x => x.Condition == ECondition.InActive)
            .OrderByDescending(x => x.SubmitDate)
            .ToListAsync();
        }

        /// <summary>
        ///  جست و جوی دو تاریخه برای بلیط های لغو شده
        /// </summary>
        public async Task<List<Ticket>> TwoDateCanceledTicketsSearch(DateTime firstDate, DateTime secondDate)
        {
            return await _context.Tickets
            .FromSql("Select * from dbo.Tickets as t Where t.SubmitDate Between {0} And {1}", firstDate, secondDate)
            .Where(x => x.Condition == ECondition.Cancel)
            .OrderByDescending(x => x.SubmitDate)
            .ToListAsync();
        }

        /// <summary>
        ///  جست و جوی یک تاریخه برای بلیط های غیرفعال
        /// </summary>
        public async Task<List<Ticket>> OneDateInActivedTicketSearch(DateTime firstDate)
        {
            return await _context.Tickets
            .Where(x => x.SubmitDate.Year == firstDate.Year && x.SubmitDate.Month == firstDate.Month && x.SubmitDate.Day == firstDate.Day && x.Condition == ECondition.InActive)
            .OrderByDescending(x => x.SubmitDate)
            .ToListAsync();
        }

        /// <summary>
        ///  جست و جوی یک تاریخه برای بلیط های لغو شده
        /// </summary>
        public async Task<List<Ticket>> OneDateCanceledTicketSearch(DateTime firstDate)
        {
            return await _context.Tickets
            .Where(x => x.SubmitDate.Year == firstDate.Year && x.SubmitDate.Month == firstDate.Month && x.SubmitDate.Day == firstDate.Day && x.Condition == ECondition.Cancel)
            .OrderByDescending(x => x.SubmitDate)
            .ToListAsync();
        }

        #endregion

        /// <summary>
        /// پاک کردن بلیط
        /// </summary>
        public async Task<bool> DeleteTicket(Ticket ticket)
        {
            _context.Tickets.Remove(ticket);
            return await _context.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// دریافت کاربر با آیدی
        /// </summary>
        public async Task<User> GetUserById(Guid id)
        {
            return await _context.Users
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        /// <summary>
        /// دریافت همه بلیط های لغو شده یک سانس
        /// </summary>
        public async Task<List<Ticket>> GetAllScheduleCanceledTickets(Guid id)
        {
            return await _context.Tickets
                .Where(x => x.ScheduleId == id && x.Condition == ECondition.Cancel)
                .OrderByDescending(x => x.SubmitDate)
                .ToListAsync();
        }

        /// <summary>
        /// دریافت همه بلیط های یک تفریح با آیدی تفریح
        /// </summary>
        public async Task<List<Ticket>> GetAllFunTicketsWithFunID(Guid id)
        {
            return await _context.Tickets
                .Where(x => x.FunId == id)
                .OrderByDescending(x => x.SubmitDate)
                .ToListAsync();
        }

        /// <summary>
        /// دریافت همه بلیط های رزرو شده یک تفریح با آیدی تفریح
        /// </summary>
        public async Task<List<Ticket>> GetAllFunActiveTicketsWithFunID(Guid id)
        {
            return await _context.Tickets
                .Where(x => x.FunId == id && x.Condition == ECondition.Reservation)
                .OrderByDescending(x => x.SubmitDate)
                .ToListAsync();
        }

        /// <summary>
        /// دریافت همه بلیط های لغو شده یک تفریح با آیدی تفریح
        /// </summary>
        public async Task<List<Ticket>> GetAllFunCanceledTicketsWithFunID(Guid id)
        {
            return await _context.Tickets
                .Where(x => x.FunId == id && x.Condition == ECondition.Cancel)
                .OrderByDescending(x => x.SubmitDate)
                .ToListAsync();
        }

        /// <summary>
        /// دریافت همه بلیط های یک کاربر با آیدی کاربر
        /// </summary>
        public async Task<List<Ticket>> GetAllUserTikcetsWithUserID(Guid id)
        {
            return await _context.Tickets
                .Where(x => x.UserId == id)
                .OrderByDescending(x => x.SubmitDate)
                .ToListAsync();
        }

        /// <summary>
        /// دریافت همه بلیط های رزرو یک کاربر با آیدی کاربر
        /// </summary>
        public async Task<List<Ticket>> GetAllUserActiveTikcetsWithUserID(Guid id)
        {
            return await _context.Tickets
                .Where(x => x.UserId == id && x.Condition == ECondition.Reservation)
                .OrderByDescending(x => x.SubmitDate)
                .ToListAsync();
        }

        /// <summary>
        /// دریافت همه بلیط های لغو شده یک کاربر با آیدی کاربر
        /// </summary>
        public async Task<List<Ticket>> GetAllUserCanceledTikcetsWithUserID(Guid id)
        {
            return await _context.Tickets
                .Where(x => x.UserId == id && x.Condition == ECondition.Cancel)
                .OrderByDescending(x => x.SubmitDate)
                .ToListAsync();
        }

        /// <summary>
        /// دریافت همه بلیط های رزروی خریده شده بصورت حضوری
        /// </summary>
        public async Task<List<Ticket>> AllPresenceReservationTickets()
        {
            return await _context.Tickets
                .Where(x => x.WhereBuy == EWhereBuy.Presence)
                .OrderByDescending(x => x.SubmitDate)
                .ToListAsync();
        }

        /// <summary>
        /// دریافت همه بلیط های رزروی خریده شده از سایت
        /// </summary>
        public async Task<List<Ticket>> AllSiteReservationTickets()
        {
            return await _context.Tickets
                .Where(x => x.WhereBuy == EWhereBuy.Site)
                .OrderByDescending(x => x.SubmitDate)
                .ToListAsync();
        }

        /// <summary>
        /// دریافت همه بلیط ها
        /// </summary>
        public async Task<List<Ticket>> AllTickets()
        {
            return await _context.Tickets
                .OrderByDescending(x => x.SubmitDate)
                .ToListAsync();
        }

        /// <summary>
        /// دریافت همه بلیط های لغو شده
        /// </summary>
        public async Task<List<Ticket>> AllCanceledTickets()
        {
            return await _context.Tickets
                .Where(x => x.Condition == ECondition.Cancel)
                .OrderByDescending(x => x.SubmitDate)
                .ToListAsync();
        }

        /// <summary>
        /// دریافت همه بلیط های رزرو شده
        /// </summary>
        public async Task<List<Ticket>> AllReservationTickets()
        {
            return await _context.Tickets
                .Where(x => x.Condition == ECondition.Reservation)
                .OrderByDescending(x => x.SubmitDate)
                .ToListAsync();
        }

        /// <summary>
        /// دریافت تعداد کل بلیط ها
        /// </summary>
        public async Task<int> AllTicketsCount()
        {
            return await _context.Tickets
                .CountAsync();
        }

        /// <summary>
        /// دریافت تعداد کل بلیط های لغو شده
        /// </summary>
        public async Task<int> AllCanceledTicketsCount()
        {
            return await _context.Tickets
                .CountAsync(x => x.Condition == ECondition.Cancel);
        }

        /// <summary>
        /// دریافت تعداد کل بلیط های رزرو شده
        /// </summary>
        public async Task<int> AllReservationTicketsCount()
        {
            return await _context.Tickets
                .CountAsync(x => x.Condition == ECondition.Reservation);
        }

        /// <summary>
        /// دریافت تعداد کل بلیط های رزرو شده یک سانس
        /// </summary>
        public async Task<int> ReservationScheduleTicketsCount(Guid id)
        {
            return await _context.Tickets
                .CountAsync(x => x.ScheduleId == id && x.Condition == ECondition.Reservation);
        }
        /// <summary>
        /// دریافت تعداد کل بلیط های لغو شده یک سانس
        /// </summary>
        public async Task<int> CanceledScheduleTicketsCount(Guid id)
        {
            return await _context.Tickets
                .CountAsync(x => x.ScheduleId == id && x.Condition == ECondition.Cancel);
        }

        /// <summary>
        /// دریافت تعداد کل بلیط های غیرفعال یک سانس
        /// </summary>
        public async Task<int> InActiveScheduleTicketsCount(Guid id)
        {
            return await _context.Tickets
                .CountAsync(x => x.ScheduleId == id && x.Condition == ECondition.InActive);
        }

        /// <summary>
        /// دریافت کل بلیط های غیرفعال یک سانس
        /// </summary>
        public async Task<List<Ticket>> AllInActiveScheduleTickets(Guid id)
        {
            return await _context.Tickets
                .Where(x => x.ScheduleId == id && x.Condition == ECondition.InActive)
                .OrderByDescending(x => x.SubmitDate)
                .ToListAsync();
        }

        /// <summary>
        /// دریافت تعداد کل بلیط های رزرو شده یک تفریح
        /// </summary>
        public async Task<int> ReservationFunTicketsCount(Guid id)
        {
            return await _context.Tickets
                .CountAsync(x => x.FunId == id && x.Condition == ECondition.Reservation);
        }

        /// <summary>
        /// دریافت تفریح با آیدی
        /// </summary>
        public async Task<Fun> GetFunById(Guid id)
        {
            return await _context.Funs
                .SingleOrDefaultAsync(x => x.Id == id);
        }


        /// <summary>
        /// دریافت کل بلیط های غیرفعال یک تفریح با آیدی تفریح
        /// </summary>
        public async Task<List<Ticket>> AllFunInActiveTickets(Guid id)
        {
            return await _context.Tickets
                .Where(x => x.FunId == id && x.Condition == ECondition.InActive)
                .OrderByDescending(x => x.SubmitDate)
                .ToListAsync();
        }

        /// <summary>
        /// دریافت تعداد کل بلیط های غیرفعال یک تفریح با آیدی تفریح
        /// </summary>
        public async Task<int> AllFunInActiveTicketsCount(Guid id)
        {
            return await _context.Tickets
                .CountAsync(x => x.FunId == id && x.Condition == ECondition.InActive);
        }

        /// <summary>
        /// دریافت تعداد کل بلیط های لغو شده یک تفریح با آیدی تفریح
        /// </summary>
        public async Task<int> CanceledFunTicketsCount(Guid id)
        {
            return await _context.Tickets
                .CountAsync(x => x.FunId == id && x.Condition == ECondition.Cancel);
        }

        /// <summary>
        /// دریافت کل بلیط های غیرفعال یک کاربر - سبد خرید
        /// </summary>
        public async Task<List<Ticket>> AllUserInActiveTickets(Guid id)
        {
            return await _context.Tickets
                .Where(x => x.UserId == id && x.Condition == ECondition.InActive)
                .OrderByDescending(x => x.SubmitDate)
                .ToListAsync();
        }

        /// <summary>
        /// دریافت تعداد کل بلیط های غیرفعال یک کاربر
        /// </summary>
        public async Task<int> InActiveUserTicketsCount(Guid id)
        {
            return await _context.Tickets
                .CountAsync(x => x.UserId == id && x.Condition == ECondition.InActive);
        }

        /// <summary>
        /// دریافت تعداد کل بلیط های رزرو یک کاربر
        /// </summary>
        public async Task<int> ReservationUserTicketsCount(Guid id)
        {
            return await _context.Tickets
                .CountAsync(x => x.UserId == id && x.Condition == ECondition.Reservation);
        }

        /// <summary>
        /// دریافت تعداد کل بلیط های لغو شده یک کاربر
        /// </summary>
        public async Task<int> CanceledUserTicketsCount(Guid id)
        {
            return await _context.Tickets
                .CountAsync(x => x.UserId == id && x.Condition == ECondition.Cancel);
        }

        /// <summary>
        /// دریافت کاربر فعال با آیدی
        /// </summary>
        public async Task<User> GetActiveUserById(Guid id)
        {
            return await _context.Users
                .SingleOrDefaultAsync(x => x.Id == id && x.IsActive == true);
        }

        /// <summary>
        /// دریافت سانس فعال با آیدی
        /// </summary>
        public async Task<Schedule> GetActiveScheduleById(Guid id)
        {
            return await _context.Schedules
                .FirstOrDefaultAsync(x => x.Id == id && x.IsExist == true);
        }

        /// <summary>
        /// گرفتن بلیط ثبت نشده با آیدی
        /// </summary>
        public async Task<Ticket> GetNotReservedTicketById(Guid id)
        {
            return await _context.Tickets
                .FirstOrDefaultAsync(x => x.Id == id && x.Condition != ECondition.Reservation);
        }

        /// <summary>
        /// گرفتن بلیط لغو نشده با آیدی
        /// </summary>
        public async Task<Ticket> GetNotCanceledTicketById(Guid id)
        {
            return await _context.Tickets
                .FirstOrDefaultAsync(x => x.Id == id && x.Condition != ECondition.Cancel);
        }

        /// <summary>
        /// دریافت بلیط غیرفعال با آیدی
        /// </summary>
        public async Task<Ticket> GetInActiveTicketById(Guid id)
        {
            return await _context.Tickets.FirstOrDefaultAsync(x => x.Id == id && x.Condition == ECondition.InActive);
        }

        /// <summary>
        /// دریافت بلیط فعال با آیدی
        /// </summary>
        public async Task<Ticket> GetReservedTicketById(Guid id)
        {
            return await _context.Tickets.FirstOrDefaultAsync(x => x.Id == id && x.Condition == ECondition.Reservation);
        }

        /// <summary>
        /// دریافت همه بلیط های سانس های انجام شده
        /// </summary>
        public async Task<List<Ticket>> GetAllPerformedTickets()
        {
            return await _context.Tickets
                .Where(x => x.ScheduleMiladiTime <= DateTime.Now && x.Condition == ECondition.Reservation)
                .OrderByDescending(x => x.ScheduleMiladiTime)
                .ToListAsync();
        }

        /// <summary>
        /// حذف بلیط از سبد خرید
        /// </summary>
        public async Task<bool> DeleteTicketsFromBasketBuy(Ticket ticket)
        {
            _context.Tickets.Remove(ticket);
            return await _context.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// دریافت بلیط در سبد خرید با آیدی
        /// </summary>
        public async Task<Ticket> GetTicketInBasketBuyById(Guid id)
        {
            return await _context.Tickets.FirstOrDefaultAsync(x => x.Id == id && x.Condition == ECondition.InActive);
        }
    }
}
