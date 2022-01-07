using Application.Commands;
using Application.Commands.Ticket;
using Application.Dtos;
using Application.Mappers;
using Application.Services.interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.RepasitoryInterfaces;
using Domain.Enums;
using Domain.IConfiguration;
using Microsoft.Extensions.Logging;

namespace Application.Services.classes
{
    public class TicketService : ITicketService
    {
       
        private readonly IUnitOfWork _unitOfWork; 
        private readonly ILogger _logger;
         

        public TicketService(ILogger<TicketService> logger, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;

        }
        /// <summary>
        /// اضافه کردن بلیط خریده شده در سایت - به سبد خرید
        /// </summary>
        public async Task<Guid?> AddTicketToSite(AddTicketToBasketCommand command)
        {
            //var fun = await _funRepository.GetFunsByFunNameAsync(command.FunName);
            //if (fun.ScheduleInfo.TotalCapacity.Equals(20))
            //    throw new Exception("ظرفیت سانس تکمیل شده");

            var schedule = await _unitOfWork.Schedules.GetActiveScheduleByIdAsync(command.ScheduleId);
            var user = await _unitOfWork.Users.GetUserById(command.UserId);
            
            if (schedule == null)
                throw new ArgumentNullException("سانس مورد نظر یافت نشد!");

            var ticket = new Ticket(command.FunName, command.BoughtPlace, command.Gender, user, schedule);
            
            var addAndSave = await _unitOfWork.Tickets.AddAsync(ticket);
            if (!addAndSave)
                throw new Exception("بلیط به سبد خرید ادد نشد ");
                

            await _unitOfWork.CompleteAsync();

            return ticket.Id;

        }

        /// <summary>
        /// حذف بلیط از سبد خرید
        /// </summary>
        public async Task<List<Guid?>> DeleteTicketsFromBasketBuy(IdListCommand command)
        {
            List<Guid?> NotDeleted = new List<Guid?>();
            foreach (var id in command.IDs)
            {
                var ticket = await _unitOfWork.Tickets.GetTicketInBasketBuyById(id);
                if (ticket == null)
                    NotDeleted.Add(id);
                else
                    await _unitOfWork.Tickets.DeleteAsync(ticket.Id);
            }
            if (NotDeleted.Count == 0)
                throw new NullReferenceException("بلیط فعال با این ایدی یافت نشد ");
               
            await _unitOfWork.CompleteAsync();

            return NotDeleted;
        }


        /// <summary>
        /// پاک کردن بلیط
        /// </summary>
        public async Task<bool> DeleteTicket(Guid id)
        {
            var ticket = await _unitOfWork.Tickets.GetInActiveTicketById(id);
            if (ticket == null)
                return false;

            await _unitOfWork.Tickets.DeleteAsync(ticket.Id);
            await _unitOfWork.CompleteAsync();
            return true;
        }

        /// <summary>
        /// اضافه کردن بلیط خریده شده بصورت حضوری
        /// </summary>
        //public async Task<TicketDto> AddTicketFromPresence(AddTicketFromPresenceCommand command)
        //{
        //    #region Get Schedule and Fun and User

        //    var schedule = await _scheduleRepository.GetActiveScheduleByIdAsync(command.ScheduleId);
        //    var fun = await _funRepository.GetFunByIdAsynch(command.FunId);
        //    var user = await _userRepository.GetUserById(command.UserId);

        //    #endregion
        //    if (command.NumberOfTicket > fun.ScheduleInfo.TotalCapacity || schedule == null || user == null)
        //        return null;

        //    fun.ScheduleInfo.MinusOnlineCapacity(command.NumberOfTicket);  
        //    fun.PlusSellerCapacity(command.NumberOfTicket);
        //    command.AvailableCapacity -= command.NumberOfTicket;

        //    var ticketModel = new Ticket(fun.Name, WhereBuy.Presence, command.gender, user, schedule);


        //    var addAndSave = await _unitOfWork.Tickets.AddTicketAsync(ticketModel);
        //    if (!addAndSave)
        //        return null;
        //    return ticketModel.ToDto();
        //}

        /// <summary>
        /// گرفتن یک بلیط
        /// </summary>
        public async Task<TicketDto> GetOneTicket(Guid id)
        {
            var ticket = await _unitOfWork.Tickets.GetByIdAsync(id);
            if (ticket == null)
                throw new ArgumentNullException("بلیط با این ایدی یافت نشد ");
            return ticket.ToDto();
        }

        /// <summary>
        /// عوض کردن وضعیت یک بلیط
        /// </summary>
        public async Task<bool> ChangeTicketCondition(EditTicketConditionCommand command)
        {
            var ticket = await _unitOfWork.Tickets.GetByIdAsync(command.TicketId);
            if (ticket == null)
                throw new ArgumentNullException("بلیط با این ایدی یافت نشد");
            ticket.SetCondition(command.ChangeCondition);
            await _unitOfWork.CompleteAsync();
            return true;
        }

        /// <summary>
        ///  جست و جوی یک تاریخه برای جمع مبلغ بلیط های فعال
        /// </summary>
        public async Task<decimal> SearchReservedTicketsPriceByDateSum(DateTime firstMiadiParse)
        {
            return await _unitOfWork.Tickets.OneDateReservedTicketsPriceSearchSum(firstMiadiParse);
        }
        ///<summary>
        /// برگردوندن تمام بلیط ها با وضعیت ها و محل های متفاوت 
        /// </summary>
        public async Task<List<TicketDto>> GetAll(GetAllTicketByAllModesCommand Command)
        {

            var getallticket = await _unitOfWork.Tickets.GetAllTicketbyAllScenarios(Command.FunType,Command.Condition,Command.WhereBuy);
            if (getallticket == null)
                throw new Exception("بلیطی در خصوص این تفریح وجود ندارد");
            return getallticket.ToDto();


        }
        

        //        /// <summary>
        //        ///  جست و جوی دو تاریخه برای جمع مبلغ بلیط های فعال
        //        /// </summary>
        //        public async Task<decimal> SearchReservedTicketsPriceByDateSum(DateTime firstMiadiParse, DateTime secondMiladiParse)
        //        {
        //            return await _unitOfWork.Tickets.TwoDateReservedTicketsPriceSearchSum(firstMiadiParse, secondMiladiParse);
        //        }

        //        /// <summary>
        //        /// جست و جوی تعداد بلیط غیرفعال با یک تاریخ
        //        /// </summary>
        //        public async Task<List<TicketDto>> SearchInActivedTicketsByDate(DateTime firstMiadiParse)
        //        {
        //            var OneDateTickets = await _unitOfWork.Tickets.OneDateInActivedTicketSearch(firstMiadiParse);
        //            if (OneDateTickets.Count == 0)
        //                return null;
        //            return OneDateTickets.ToDto();
        //        }

        //        /// <summary>
        //        /// جست و جوی تعداد بلیط غیرفعال با دو تاریخ
        //        /// </summary>
        //        public async Task<List<TicketDto>> SearchInActivedTicketsByDate(DateTime firstMiadiParse, DateTime secondMiladiParse)
        //        {
        //            var twoDateTickets = await _unitOfWork.Tickets.TwoDateInActivedTicketsSearch(firstMiadiParse, secondMiladiParse);
        //            if (twoDateTickets.Count == 0)
        //                return null;
        //            return twoDateTickets.ToDto();
        //        }

        //        /// <summary>
        //        /// جست و جوی بلیط لغو شده با یک تاریخ
        //        /// </summary>
        //        public async Task<List<TicketDto>> SearchCanceledTicketsByDate(DateTime firstMiadiParse)
        //        {
        //            var OneDateTickets = await _unitOfWork.Tickets.OneDateCanceledTicketSearch(firstMiadiParse);
        //            if (OneDateTickets.Count == 0)
        //                return null;
        //            return OneDateTickets.ToDto();
        //        }

        //        /// <summary>
        //        /// جست و جوی بلیط لغو شده با دو تاریخ
        //        /// </summary>
        //        public async Task<List<TicketDto>> SearchCanceledTicketsByDate(DateTime firstMiadiParse, DateTime secondMiladiParse)
        //        {
        //            var twoDateTickets = await _unitOfWork.Tickets.TwoDateCanceledTicketsSearch(firstMiadiParse, secondMiladiParse);
        //            if (twoDateTickets.Count == 0)
        //                return null;
        //            return twoDateTickets.ToDto();
        //        }

        //        #endregion


        //        /// <summary>
        //        /// ثبت خرید و فعال کردن بلیط
        //        /// </summary>
        //        public async Task<TicketDto> EntryBuyTicket(Guid id)
        //        {
        //            var ticket = await _unitOfWork.Tickets.GetInActiveTicketById(id);
        //            if (ticket == null)
        //                return null;

        //            var schedule = await _unitOfWork.Tickets.GetActiveScheduleById(ticket.ScheduleId);
        //            if (schedule == null)
        //                return null;

        //            var fun = await _unitOfWork.Tickets.GetFunByIdAsynch(schedule.FunId);
        //            var user = await _unitOfWork.Tickets.GetUserById(ticket.UserId);

        //            if (user.RoleType == RoleType.Seller)
        //                fun.PlusSellerCapacity(ticket.NumberOfTicket);
        //            else
        //                fun.MinusRealCapacity(ticket.NumberOfTicket);

        //            fun.MinusOnlineCapacity(ticket.NumberOfTicket);

        //            ticket.ConditionSet(Condition.Reservation);
        //            //schedule.AvailableCapacity -= ticket.NumberOfTicket;

        //            var save = await _unitOfWork.Tickets.SaveChangesAsync();
        //            if (!save)
        //                return null;
        //            return ticket.ToDto();
        //        }

        //        /// <summary>
        //        /// لغو بلیط
        //        /// </summary>
        //        public async Task<decimal?> CancelTicket(Guid id)
        //        {
        //            var ticket = await _unitOfWork.Tickets.GetReservedTicketById(id);
        //            var schedule = await _unitOfWork.Tickets.GetScheduleByIdAsync(ticket.ScheduleId);
        //            var fun = await _unitOfWork.Tickets.GetFunByIdAsynch(schedule.FunId);
        //            var user = await _unitOfWork.Tickets.GetUserById(ticket.UserId);
        //            if (ticket == null)
        //                return null;

        //            if (user.RoleType == RoleType.Seller)
        //            {
        //                fun.MinusSellerCapacity(ticket.NumberOfTicket);
        //                fun.PlusOnlineCapacity(ticket.NumberOfTicket);
        //            }

        //            fun.PlusRealCapacity(ticket.NumberOfTicket);
        //            ticket.ConditionSet(Condition.Cancel);
        //            //schedule.AvailableCapacity += ticket.NumberOfTicket;
        //            //user.Wallet += ticket.Price;

        //            var save = await _unitOfWork.Tickets.SaveChangesAsync();
        //            if (!save)
        //                return null;
        //            return schedule.AvailableCapacity;
        //        }


        //        #region ScheduleOptions

        /// <summary>
        /// گرفتن همه بلیط های یک سانس
        /// </summary>
        public async Task<List<TicketDto>> GetAllScheduleTickets(Guid scheduleId)
        {
            var tickets = await _unitOfWork.Tickets.GetAllScheduleTickets(scheduleId);
            if (tickets == null)
                throw new ArgumentNullException("بلیطی با این ایدی یافت نشد");
            return tickets.ToDto();
        }

        //        /// <summary>
        //        /// گرفتن همه بلیط های فعال یک سانس
        //        /// </summary>
        //        public async Task<List<TicketDto>> GetAllScheduleActiveTickets(Guid id)
        //        {
        //            var tickets = await _unitOfWork.Tickets.GetAllScheduleActiveTickets(id);
        //            if (tickets == null)
        //                return null;
        //            return tickets.ToDto();
        //        }

        /// <summary>
        /// دریافت کل بلیط های غیرفعال یک سانس
        /// </summary>
        public async Task<List<TicketDto>> AllInActiveScheduleTickets(Guid id)
        {
            var tickets = await _unitOfWork.Tickets.AllInActiveScheduleTickets(id);
            if (tickets == null)
                throw new ArgumentNullException("بلیطی غیر فعالی با این ایدی یافت نشد");
            return tickets.ToDto();
        }

        /// <summary>
        /// دریافت مقدار پول کل بلیط های فروخته شده یک سانس با ایدی سانس 
        /// </summary>
        public async Task<decimal> ScheduleTicketsPrice(Guid schedulId)
        {
            var TotalPrice = await _unitOfWork.Tickets.ScheduleTicketsPrice(schedulId);
            if (TotalPrice.Equals(0))
                throw new ArgumentNullException("بلیطی یافت نشد");

            return TotalPrice;
        }

        //        /// <summary>
        //        /// دریافت همه بلیط های لغو شده یک سانس
        //        /// </summary>
        //        public async Task<List<TicketDto>> GetAllScheduleCanceledTickets(Guid id)
        //        {
        //            var tickets = await _unitOfWork.Tickets.GetAllScheduleCanceledTickets(id);
        //            if (tickets == null)
        //                return null;
        //            return tickets.ToDto();
        //        }

        //        #endregion

        //        #region FunOptions

        //        /// <summary>
        //        /// دریافت همه بلیط های یک تفریح با آیدی تفریح
        //        /// </summary>
        //        public async Task<List<TicketDto>> GetAllFunTicketsWithFunID(Guid id)
        //        {
        //            var tickets = await _unitOfWork.Tickets.GetAllFunTicketsWithFunID(id);
        //            if (tickets == null)
        //                return null;
        //            return tickets.ToDto();
        //        }

        /// <summary>
        /// دریافت همه بلیط های رزرو شده یک تفریح با نام تفریح
        /// </summary>
        public async Task<List<TicketDto>> GetAllFunActiveTicketsWithFunName(string funName)
        {
            var tickets = await _unitOfWork.Tickets.GetAllFunActiveTicketsWithFunName(funName);
            if (tickets == null)
                throw new ArgumentNullException("بلیط یا تفریحی یافت نشد");
            return tickets.ToDto();
        }




        //        /// <summary>
        //        /// دریافت همه بلیط های لغو شده یک تفریح با آیدی تفریح
        //        /// </summary>
        //        public async Task<List<TicketDto>> GetAllFunCanceledTicketsWithFunID(Guid id)
        //        {
        //            var tickets = await _unitOfWork.Tickets.GetAllFunCanceledTicketsWithFunID(id);
        //            if (tickets == null)
        //                return null;
        //            return tickets.ToDto();
        //        }

        //        /// <summary>
        //        /// دریافت کل بلیط های غیرفعال یک تفریح با آیدی تفریح
        //        /// </summary>
        //        public async Task<List<TicketDto>> AllFunInActiveTickets(Guid id)
        //        {
        //            var tickets = await _unitOfWork.Tickets.AllFunInActiveTickets(id);
        //            if (tickets == null)
        //                return null;
        //            return tickets.ToDto();
        //        }

        //        #endregion

        //        #region UserOptions
        //        /// <summary>
        //        /// دریافت کل بلیط های غیرفعال یک کاربر - سبد خرید
        //        /// </summary>
        //        public async Task<List<TicketDto>> AllUserInActiveTickets(Guid id)
        //        {
        //            var tickets = await _unitOfWork.Tickets.AllUserInActiveTickets(id);
        //            if (tickets == null)
        //                return null;
        //            return tickets.ToDto();
        //        }

        //        /// <summary>
        //        /// دریافت تعداد کل بلیط های غیرفعال یک کاربر
        //        /// </summary>
        //        public async Task<int> InActiveUserTicketsCount(Guid id)
        //        {
        //            return await _unitOfWork.Tickets.InActiveUserTicketsCount(id);
        //        }

        //        /// <summary>
        //        /// دریافت تعداد کل بلیط های رزرو یک کاربر
        //        /// </summary>
        //        public async Task<int> ReservationUserTicketsCount(Guid id)
        //        {
        //            return await _unitOfWork.Tickets.ReservationUserTicketsCount(id);
        //        }

        //        /// <summary>
        //        /// دریافت تعداد کل بلیط های لغو شده یک کاربر
        //        /// </summary>
        //        public async Task<int> CanceledUserTicketsCount(Guid id)
        //        {
        //            return await _unitOfWork.Tickets.CanceledUserTicketsCount(id);
        //        }

        //        /// <summary>
        //        /// دریافت همه بلیط های یک کاربر با آیدی کاربر
        //        /// </summary>
        //        public async Task<List<TicketDto>> GetAllUserTikcetsWithUserID(Guid id)
        //        {
        //            var tickets = await _unitOfWork.Tickets.GetAllUserTikcetsWithUserID(id);
        //            if (tickets == null)
        //                return null;
        //            return tickets.ToDto();
        //        }

        //        /// <summary>
        //        /// دریافت همه بلیط های رزرو یک کاربر با آیدی کاربر
        //        /// </summary>
        //        public async Task<List<TicketDto>> GetAllUserActiveTikcetsWithUserID(Guid id)
        //        {
        //            var tickets = await _unitOfWork.Tickets.GetAllUserActiveTikcetsWithUserID(id);
        //            if (tickets == null)
        //                return null;
        //            return tickets.ToDto();
        //        }

        //        /// <summary>
        //        /// دریافت همه بلیط های لغو شده یک کاربر با آیدی کاربر
        //        /// </summary>
        //        public async Task<List<TicketDto>> GetAllUserCanceledTikcetsWithUserID(Guid id)
        //        {
        //            var tickets = await _unitOfWork.Tickets.GetAllUserCanceledTikcetsWithUserID(id);
        //            if (tickets == null)
        //                return null;
        //            return tickets.ToDto();
        //        }
        //        #endregion

        //        #region AllOptions
        //        /// <summary>
        //        /// دریافت همه بلیط های رزروی خریده شده بصورت حضوری
        //        /// </summary>
        //        public async Task<List<TicketDto>> AllPresenceReservationTickets()
        //        {
        //            var tickets = await _unitOfWork.Tickets.AllPresenceReservationTickets();
        //            if (tickets == null)
        //                return null;
        //            return tickets.ToDto();
        //        }

        //        /// <summary>
        //        /// دریافت همه بلیط های رزروی خریده شده از سایت
        //        /// </summary>
        //        public async Task<List<TicketDto>> AllSiteReservationTickets()
        //        {
        //            var tickets = await _unitOfWork.Tickets.AllSiteReservationTickets();
        //            if (tickets == null)
        //                return null;
        //            return tickets.ToDto();
        //        }

        //        /// <summary>
        //        /// دریافت همه بلیط ها
        //        /// </summary>
        //        public async Task<List<TicketDto>> AllTickets()
        //        {
        //            var tickets = await _unitOfWork.Tickets.AllTickets();
        //            if (tickets == null)
        //                return null;
        //            return tickets.ToDto();
        //        }

        //        /// <summary>
        //        /// دریافت همه بلیط های لغو شده
        //        /// </summary>
        //        public async Task<List<TicketDto>> AllCanceledTickets()
        //        {
        //            var tickets = await _unitOfWork.Tickets.AllCanceledTickets();
        //            if (tickets == null)
        //                return null;
        //            return tickets.ToDto();
        //        }

        //        /// <summary>
        //        /// دریافت همه بلیط های رزرو شده
        //        /// </summary>
        //        public async Task<List<TicketDto>> AllReservationTickets()
        //        {
        //            var tickets = await _unitOfWork.Tickets.AllReservationTickets();
        //            if (tickets == null)
        //                return null;
        //            return tickets.ToDto();
        //        }

        //        #endregion

        //        #region Specials

        //        /// <summary>
        //        /// تغییر وضعیت بلیط های انجام شده به بازی شده
        //        /// </summary>
        //        public async Task<int> SetPerformedTicketsToPlayed()
        //        {
        //            var performedTickets = await _unitOfWork.Tickets.GetAllPerformedTickets();
        //            if (performedTickets.Count == 0)
        //                return 0;

        //            foreach (var ticket in performedTickets)
        //            {
        //                ticket.ConditionSet(Condition.Played);
        //            }

        //            var save = await _unitOfWork.Tickets.SaveChangesAsync();
        //            if (!save)
        //                return 503;
        //            return performedTickets.Count;
        //        }

        //        #endregion
    }
}
