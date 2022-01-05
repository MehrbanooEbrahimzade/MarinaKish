using Domain.Enums;
using Domain.Models;
using Domain.RepasitoryInterfaces;
using Infrastructure.Persist;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Classes
{
    public class TicketRepository : GenericRepository<Ticket>, ITicketRepository
    {
        #region new changes 

        public TicketRepository(DatabaseContext context, ILogger logger) : base(context, logger)
        {

        }

        public override async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var ticket = await dbSet.SingleOrDefaultAsync(x => x.Id == id);

                if (ticket != null)
                {
                    dbSet.Remove(ticket);
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Delete method error", typeof(TicketRepository));
                return false;
            }
        }


        public override async Task<IEnumerable<Ticket>> AllAsync()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All method error", typeof(TicketRepository));
                return new List<Ticket>();
            }
        }

        public override async Task<bool> AddAsync(Ticket ticket)
        {
            try
            {
                await dbSet.AddAsync(ticket);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Add method error", typeof(TicketRepository));
                return false;
            }
        }

        public override async Task<Ticket> GetByIdAsync(Guid id)
        {
            try
            {
                var ticket = await dbSet.Include(x => x.Schedule).Include(x => x.User)
                    .SingleOrDefaultAsync(x => x.Id == id);

                if (ticket == null)
                    throw new NullReferenceException("کاربر شناسایی نشد!");

                return ticket;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} GetById method error", typeof(TicketRepository));
                return null;
            }
        }



        #endregion

        /// <summary>
        /// دریافت بلیط غیرفعال با آیدی
        /// </summary>
        public async Task<Ticket> GetInActiveTicketById(Guid id)
        {
            return await dbSet.FirstOrDefaultAsync(x => x.Id == id && x.Condition == Condition.InActive);
        }

        

        /// <summary>
        /// دریافت همه بلیط های یک سانس
        /// </summary>
        public async Task<List<Ticket>> GetAllScheduleTickets(Guid scheduleId)
        {
            return await IncludeForTicket()
                .Where(x => x.Schedule.Id == scheduleId)
                .OrderByDescending(x => x.SubmitDate)
                .ToListAsync();
        }

        /// <summary>
        /// دریافت همه بلیط های یک تفریح با حالات متفاوت
        /// </summary>
        public async Task<List<Ticket>> GetAllTicketbyAllScenarios(string funtype, Condition condition, WhereBuy whereBuy)

        {
            return await IncludeForTicket()
                         .Where(x => x.FunType == funtype && x.Condition == condition && x.WhereBuy == whereBuy)
                         .OrderByDescending(x => x.SubmitDate)
                         .ToListAsync();
        }



        /// <summary>
        ///  این کلود برای دیتیو 
        /// </summary>
        public IQueryable<Ticket> IncludeForTicket()
        {
            return _context.Tickets
                         .Include(x => x.User)
                         .Include(x => x.Schedule);
        }
        /// <summary>
        ///  جست و جوی یک تاریخه برای جمع مبلغ بلیط های فعال
        /// </summary>
        public async Task<decimal> OneDateReservedTicketsPriceSearchSum(DateTime firstDate)
        {
            return await dbSet
            .Where(x => x.SubmitDate.Year == firstDate.Year && x.SubmitDate.Month == firstDate.Month && x.SubmitDate.Day == firstDate.Day && x.Condition == Condition.Reservation)
            .SumAsync(x => x.Schedule.Price);
        }

        /// <summary>
        /// دریافت همه بلیط های رزرو شده یک تفریح با نام تفریح
        /// </summary>
        public async Task<List<Ticket>> GetAllFunActiveTicketsWithFunName(string funName)
        {
            return await dbSet
                .Where(x => x.FunType == funName && x.Condition == Condition.Reservation)
                .OrderByDescending(x => x.SubmitDate)
                .ToListAsync();
        }

        /// <summary>
        /// دریافت کل بلیط های غیرفعال یک سانس
        /// </summary>
        public async Task<List<Ticket>> AllInActiveScheduleTickets(Guid id)
        {
            return await dbSet
                .Include(x => x.User)
                .Where(x => x.Schedule.Id == id && x.Condition == Condition.InActive)
                .OrderByDescending(x => x.SubmitDate)
                .ToListAsync();
        }
        /// <summary>
        /// دریافت بلیط در سبد خرید با آیدی
        /// </summary>
        public async Task<Ticket> GetTicketInBasketBuyById(Guid id)
        {
            return await dbSet.FirstOrDefaultAsync(x => x.Id == id && x.Condition == Condition.InActive);
        }


        /// /// <summary>
        /// گرفتن همه بلیط های فعال یک سانس
        /// </summary>
        //public async Task<List<Ticket>> GetAllScheduleActiveTickets(Guid id)
        //{
        //    return await _context.Tickets.Where(x => x.Schedule.Id == id && x.Condition == Condition.Reservation)
        //        .OrderByDescending(x => x.SubmitDate)
        //        .ToListAsync();
        //} 

        /// <summary>
        /// دریافت تمام بلیط های یک تفریح
        /// </summary>
        //public async Task<List<Ticket>> GetAllFunTickets(FunType eFun)
        //{
        //    return await _context.Tickets
        //        .Where(x => x.FunType == eFun && x.Condition == Condition.Reservation && x.ScheduleTime >= DateTime.Now /* && x.ExecuteDate <= DateTime.Now.AddDays(7)*/)
        //        .OrderByDescending(x => x.SubmitDate)
        //        .ToListAsync();
        //}

        /// <summary>
        /// گرفتن همه بلیط های رزروی یک کاربر
        /// </summary>
        //public async Task<List<Ticket>> GetAllUserTikcets(string phone)
        //{
        //    return await _context.Tickets
        //        .Where(x => x.PhoneNumber == phone && x.Condition == Condition.Reservation)

        //        .ToListAsync();
        //}

        ///// <summary>
        ///// گرفتن بلیط با شماره بلیط
        ///// </summary>
        //public async Task<Ticket> GetTicketbyTicketNumber(string ticketnumber)
        //{
        //    return await _context.Tickets
        //        .FirstOrDefaultAsync(x => x.TicketNumber == ticketnumber && x.Condition == Condition.Reservation);
        //}



        /// <summary>
        /// دریافت تعداد بلیط های فروخته شده برای یک تفریح
        /// </summary>
        //public async Task<int> ScheduleTicketsCount(Guid id)
        //{
        //    return await _context.Tickets
        //        .CountAsync(x => x.ScheduleId == id && x.Condition == Condition.Reservation);
        //}

        /// <summary>
        /// دریافت مقدار پول کل بلیط های فروخته شده یک سانس با ایدی سانس 
        /// </summary>
        public async Task<decimal> ScheduleTicketsPrice(Guid id)
        {
            return await _context.Tickets
                .Where(x => x.Schedule.Id == id && x.Condition == Condition.Reservation)
                .SumAsync(x => x.Schedule.Price);
        }

        //#region Search Options

        /// <summary>
        ///  جست و جوی دو تاریخه برای بلیط های فعال
        /// </summary>
        //public async Task<List<Ticket>> TwoDateReservedTicketsSearch(DateTime firstDate, DateTime secondDate)
        //{
        //    return await _context.Tickets
        //        .FromSql("Select * from dbo.Tickets as t Where t.SubmitDate Between {0} And {1}", firstDate, secondDate)
        //        .Where(x => x.Condition == Condition.Reservation)
        //        .OrderByDescending(x => x.SubmitDate)
        //        .ToListAsync();
        //}

        /// <summary>
        ///  جست و جوی یک تاریخه برای بلیط های فعال
        /// </summary>
        //public async Task<List<Ticket>> OneDateReservedTicketSearch(DateTime firstDate)
        //{
        //    return await _context.Tickets
        //        .Where(x => x.SubmitDate.Year == firstDate.Year && x.SubmitDate.Month == firstDate.Month && x.SubmitDate.Day == firstDate.Day && x.Condition == Condition.Reservation)
        //        .OrderByDescending(x => x.SubmitDate)
        //        .ToListAsync();
        //}

        /// <summary>
        ///  جست و جوی دو تاریخه برای جمع مبلغ بلیط های فعال
        /// </summary>
        //public async Task<decimal> TwoDateReservedTicketsPriceSearchSum(DateTime firstDate, DateTime secondDate)
        //{
        //    return await _context.Tickets
        //    .FromSql("Select * from dbo.Tickets as t Where t.SubmitDate Between {0} And {1}", firstDate, secondDate)
        //    .Where(x => x.Condition == Condition.Reservation)
        //    .SumAsync(x => x.Price);
        //}



        /// <summary>
        ///  جست و جوی دو تاریخه برای بلیط های غیرفعال
        /// </summary>
        //public async Task<List<Ticket>> TwoDateInActivedTicketsSearch(DateTime firstDate, DateTime secondDate)
        //{
        //    return await _context.Tickets
        //    .FromSql("Select * from dbo.Tickets as t Where t.SubmitDate Between {0} And {1}", firstDate, secondDate)
        //    .Where(x => x.Condition == Condition.InActive)
        //    .OrderByDescending(x => x.SubmitDate)
        //    .ToListAsync();
        //}

        /// <summary>
        ///  جست و جوی دو تاریخه برای بلیط های لغو شده
        /// </summary>
        //public async Task<List<Ticket>> TwoDateCanceledTicketsSearch(DateTime firstDate, DateTime secondDate)
        //{
        //    return await _context.Tickets
        //    .FromSql("Select * from dbo.Tickets as t Where t.SubmitDate Between {0} And {1}", firstDate, secondDate)
        //    .Where(x => x.Condition == Condition.Cancel)
        //    .OrderByDescending(x => x.SubmitDate)
        //    .ToListAsync();
        //}

        /// <summary>
        ///  جست و جوی یک تاریخه برای بلیط های غیرفعال
        /// </summary>
        //public async Task<List<Ticket>> OneDateInActivedTicketSearch(DateTime firstDate)
        //{
        //    return await _context.Tickets
        //    .Where(x => x.SubmitDate.Year == firstDate.Year && x.SubmitDate.Month == firstDate.Month && x.SubmitDate.Day == firstDate.Day && x.Condition == Condition.InActive)
        //    .OrderByDescending(x => x.SubmitDate)
        //    .ToListAsync();
        //}

        /// <summary>
        ///  جست و جوی یک تاریخه برای بلیط های لغو شده
        /// </summary>
        //public async Task<List<Ticket>> OneDateCanceledTicketSearch(DateTime firstDate)
        //{
        //    return await _context.Tickets
        //    .Where(x => x.SubmitDate.Year == firstDate.Year && x.SubmitDate.Month == firstDate.Month && x.SubmitDate.Day == firstDate.Day && x.Condition == Condition.Cancel)
        //    .OrderByDescending(x => x.SubmitDate)
        //    .ToListAsync();
        //}

        //#endregion




        /// <summary>
        /// دریافت همه بلیط های لغو شده یک سانس
        /// </summary>
        //public async Task<List<Ticket>> GetAllScheduleCanceledTickets(Guid id)
        //{
        //    return await _context.Tickets
        //        .Where(x => x.ScheduleId == id && x.Condition == Condition.Cancel)
        //        .OrderByDescending(x => x.SubmitDate)
        //        .ToListAsync();
        //}

        /// <summary>
        /// دریافت همه بلیط های یک تفریح با آیدی تفریح
        /// </summary>
        //public async Task<List<Ticket>> GetAllFunTicketsWithFunID(Guid id)
        //{
        //    return await _context.Tickets
        //        .Where(x => x.FunId == id)
        //        .OrderByDescending(x => x.SubmitDate)
        //        .ToListAsync();
        //}


        /// <summary>
        /// دریافت همه بلیط های لغو شده یک تفریح با آیدی تفریح
        /// </summary>
        //public async Task<List<Ticket>> GetAllFunCanceledTicketsWithFunID(Guid id)
        //{
        //    return await _context.Tickets
        //        .Where(x => x.FunId == id && x.Condition == Condition.Cancel)
        //        .OrderByDescending(x => x.SubmitDate)
        //        .ToListAsync();
        //}

        ///// <summary>
        ///// دریافت همه بلیط های یک کاربر با آیدی کاربر
        ///// </summary>
        //public async Task<List<Ticket>> GetAllUserTikcetsWithUserID(Guid id)
        //{
        //    return await _context.Tickets
        //        .Where(x => x.UserId == id)
        //        .OrderByDescending(x => x.SubmitDate)
        //        .ToListAsync();
        //}

        ///// <summary>
        ///// دریافت همه بلیط های رزرو یک کاربر با آیدی کاربر
        ///// </summary>
        //public async Task<List<Ticket>> GetAllUserActiveTikcetsWithUserID(Guid id)
        //{
        //    return await _context.Tickets
        //        .Where(x => x.UserId == id && x.Condition == Condition.Reservation)
        //        .OrderByDescending(x => x.SubmitDate)
        //        .ToListAsync();
        //}

        ///// <summary>
        ///// دریافت همه بلیط های لغو شده یک کاربر با آیدی کاربر
        ///// </summary>
        //public async Task<List<Ticket>> GetAllUserCanceledTikcetsWithUserID(Guid id)
        //{
        //    return await _context.Tickets
        //        .Where(x => x.UserId == id && x.Condition == Condition.Cancel)
        //        .OrderByDescending(x => x.SubmitDate)
        //        .ToListAsync();
        //}

        /// <summary>
        /// دریافت همه بلیط های رزروی خریده شده بصورت حضوری
        /// </summary>
        //public async Task<List<Ticket>> AllPresenceReservationTickets()
        //{
        //    return await _context.Tickets
        //        .Where(x => x.WhereBuy == WhereBuy.Presence)
        //        .OrderByDescending(x => x.SubmitDate)
        //        .ToListAsync();
        //}

        /// <summary>
        /// دریافت همه بلیط های رزروی خریده شده از سایت
        /// </summary>
        //public async Task<List<Ticket>> AllSiteReservationTickets()
        //{
        //    return await _context.Tickets
        //        .Where(x => x.WhereBuy == WhereBuy.Site)
        //        .OrderByDescending(x => x.SubmitDate)
        //        .ToListAsync();
        //}

        /// <summary>
        /// دریافت همه بلیط ها
        /// </summary>
        //public async Task<List<Ticket>> AllTickets()
        //{
        //    return await _context.Tickets
        //        .OrderByDescending(x => x.SubmitDate)
        //        .ToListAsync();
        //}

        /// <summary>
        /// دریافت همه بلیط های لغو شده
        /// </summary>
        //public async Task<List<Ticket>> AllCanceledTickets()
        //{
        //    return await _context.Tickets
        //        .Where(x => x.Condition == Condition.Cancel)
        //        .OrderByDescending(x => x.SubmitDate)
        //        .ToListAsync();
        //}

        /// <summary>
        /// دریافت همه بلیط های رزرو شده
        /// </summary>
        //public async Task<List<Ticket>> AllReservationTickets()
        //{
        //    return await _context.Tickets
        //        .Where(x => x.Condition == Condition.Reservation)
        //        .OrderByDescending(x => x.SubmitDate)
        //        .ToListAsync();
        //}

        /// <summary>
        /// دریافت تعداد کل بلیط ها
        /// </summary>
        //public async Task<int> AllTicketsCount()
        //{
        //    return await _context.Tickets
        //        .CountAsync();
        //}

        /// <summary>
        /// دریافت تعداد کل بلیط های لغو شده
        /// </summary>
        //public async Task<int> AllCanceledTicketsCount()
        //{
        //    return await _context.Tickets
        //        .CountAsync(x => x.Condition == Condition.Cancel);
        //}

        /// <summary>
        /// دریافت تعداد کل بلیط های رزرو شده
        /// </summary>
        //public async Task<int> AllReservationTicketsCount()
        //{
        //    return await _context.Tickets
        //        .CountAsync(x => x.Condition == Condition.Reservation);
        //}

        /// <summary>
        /// دریافت تعداد کل بلیط های رزرو شده یک سانس
        /// </summary>
        //public async Task<int> ReservationScheduleTicketsCount(Guid id)
        //{
        //    return await _context.Tickets
        //        .CountAsync(x => x.ScheduleId == id && x.Condition == Condition.Reservation);
        //}
        /// <summary>
        /// دریافت تعداد کل بلیط های لغو شده یک سانس
        /// </summary>
        //public async Task<int> CanceledScheduleTicketsCount(Guid id)
        //{
        //    return await _context.Tickets
        //        .CountAsync(x => x.ScheduleId == id && x.Condition == Condition.Cancel);
        //}

        /// <summary>
        /// دریافت تعداد کل بلیط های غیرفعال یک سانس
        /// </summary>
        //public async Task<int> InActiveScheduleTicketsCount(Guid id)
        //{
        //    return await _context.Tickets
        //        .CountAsync(x => x.ScheduleId == id && x.Condition == Condition.InActive);
        //}

        /// <summary>
        /// دریافت تعداد کل بلیط های رزرو شده یک تفریح
        /// </summary>
        //public async Task<int> ReservationFunTicketsCount(Guid id)
        //{
        //    return await _context.Tickets
        //        .CountAsync(x => x.FunId == id && x.Condition == Condition.Reservation);
        //}


        /// <summary>
        /// دریافت کل بلیط های غیرفعال یک تفریح با آیدی تفریح
        /// </summary>
        //public async Task<List<Ticket>> AllFunInActiveTickets(Guid id)
        //{
        //    return await _context.Tickets
        //        .Where(x => x.FunId == id && x.Condition == Condition.InActive)
        //        .OrderByDescending(x => x.SubmitDate)
        //        .ToListAsync();
        //}

        /// <summary>
        /// دریافت تعداد کل بلیط های غیرفعال یک تفریح با آیدی تفریح
        /// </summary>
        //public async Task<int> AllFunInActiveTicketsCount(Guid id)
        //{
        //    return await _context.Tickets
        //        .CountAsync(x => x.FunId == id && x.Condition == Condition.InActive);
        //}

        /// <summary>
        /// دریافت تعداد کل بلیط های لغو شده یک تفریح با آیدی تفریح
        /// </summary>
        //public async Task<int> CanceledFunTicketsCount(Guid id)
        //{
        //    return await _context.Tickets
        //        .CountAsync(x => x.FunId == id && x.Condition == Condition.Cancel);
        //}

        ///// <summary>
        ///// دریافت کل بلیط های غیرفعال یک کاربر - سبد خرید
        ///// </summary>
        //public async Task<List<Ticket>> AllUserInActiveTickets(Guid id)
        //{
        //    return await _context.Tickets
        //        .Where(x => x.UserId == id && x.Condition == Condition.InActive)
        //        .OrderByDescending(x => x.SubmitDate)
        //        .ToListAsync();
        //}

        ///// <summary>
        ///// دریافت تعداد کل بلیط های غیرفعال یک کاربر
        ///// </summary>
        //public async Task<int> InActiveUserTicketsCount(Guid id)
        //{
        //    return await _context.Tickets
        //        .CountAsync(x => x.UserId == id && x.Condition == Condition.InActive);
        //}

        ///// <summary>
        ///// دریافت تعداد کل بلیط های رزرو یک کاربر
        ///// </summary>
        //public async Task<int> ReservationUserTicketsCount(Guid id)
        //{
        //    return await _context.Tickets
        //        .CountAsync(x => x.UserId == id && x.Condition == Condition.Reservation);
        //}

        ///// <summary>
        ///// دریافت تعداد کل بلیط های لغو شده یک کاربر
        ///// </summary>
        //public async Task<int> CanceledUserTicketsCount(Guid id)
        //{
        //    return await _context.Tickets
        //        .CountAsync(x => x.UserId == id && x.Condition == Condition.Cancel);
        //}

        /// <summary>
        /// گرفتن بلیط ثبت نشده با آیدی
        /// </summary>
        //public async Task<Ticket> GetNotReservedTicketById(Guid id)
        //{
        //    return await _context.Tickets
        //        .FirstOrDefaultAsync(x => x.Id == id && x.Condition != Condition.Reservation);
        //}

        /// <summary>
        /// گرفتن بلیط لغو نشده با آیدی
        /// </summary>
        //public async Task<Ticket> GetNotCanceledTicketById(Guid id)
        //{
        //    return await _context.Tickets
        //        .FirstOrDefaultAsync(x => x.Id == id && x.Condition != Condition.Cancel);
        //}


        /// <summary>
        /// دریافت بلیط فعال با آیدی
        /// </summary>
        //public async Task<Ticket> GetReservedTicketById(Guid id)
        //{
        //    return await _context.Tickets.FirstOrDefaultAsync(x => x.Id == id && x.Condition == Condition.Reservation);
        //}

        /// <summary>
        /// دریافت همه بلیط های سانس های انجام شده
        /// </summary>
        //public async Task<List<Ticket>> GetAllPerformedTickets()
        //{
        //    return await _context.Tickets
        //        .Where(x => x.ScheduleTime <= DateTime.Now && x.Condition == Condition.Reservation)
        //        .OrderByDescending(x => x.ScheduleTime)
        //        .ToListAsync();
        //}



    }
}
