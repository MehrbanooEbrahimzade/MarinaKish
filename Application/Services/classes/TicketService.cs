﻿using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Application.Commands;
using Application.Commands.Ticket;
using Application.Dtos;
using Application.Mappers;
using Application.Services.interfaces;
using Domain.Models;
using Domain.Models.enums;
using Infrastructure.Repository.interfaces;

namespace Application.Services.classes
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;
        public TicketService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        /// <summary>
        /// اضافه کردن بلیط خریده شده در سایت - به سبد خرید
        /// </summary>
        public async Task<Guid?> AddTicketForBasket(AddTicketToBasketCommand command)
        {
            #region Get Schedule and Fun and User

            var schedule = await _ticketRepository.GetActiveScheduleById(command.ScheduleId);
            var user = await _ticketRepository.GetActiveUserById(command.UserId);

            #endregion

            if (command.NumberOfTicket > schedule.AvailableCapacity || schedule == null || user == null)
                return null;

            var ticketModel = new Ticket(schedule.FunType, schedule.ExcuteMiladiDateTime, schedule.StartTime, schedule.EndTime, command.NumberOfTicket);
           

            var addAndSave = await _ticketRepository.AddTicketAsync(ticketModel);
            if (!addAndSave)
                return null;
            return ticketModel.Id;

        }

        /// <summary>
        /// حذف بلیط از سبد خرید
        /// </summary>
        public async Task<List<Guid?>> DeleteTicketsFromBasketBuy(IdListCommand command)
        {
            List<Guid?> NotDeleted = new List<Guid?>();
            foreach (var id in command.IDs)
            {
                var ticket = await _ticketRepository.GetTicketInBasketBuyById(id);
                if (ticket == null)
                    NotDeleted.Add(id);
                else
                    await _ticketRepository.DeleteTicketsFromBasketBuy(ticket);
            }
            if (NotDeleted.Count == 0)
                return null;
            return NotDeleted;
        }

        /// <summary>
        /// اضافه کردن بلیط خریده شده بصورت حضوری
        /// </summary>
        public async Task<TicketDto> AddTicketFromPresence(AddTicketFromPresenceCommand command)
        {
            #region Get Schedule and Fun and User

            var schedule = await _ticketRepository.GetActiveScheduleById(command.ScheduleId);
            var fun = await _ticketRepository.GetFunById(schedule.FunId);
            var user = await _ticketRepository.GetUserByPhone(command.UserCellPhone);

            #endregion

            if (command.NumberOfTicket > schedule.AvailableCapacity || schedule == null || user == null)
                return null;

            if (user.RoleType == RoleTypec.Seller)
            {
                fun.OnlineCapacity -= command.NumberOfTicket;
                fun.SellerCapacity += command.NumberOfTicket;
            }

            command.AvailableCapacity -= command.NumberOfTicket;

            var ticketModel = new Ticket(schedule.FunType, schedule.ExcuteMiladiDateTime, schedule.StartTime, schedule.EndTime, command.NumberOfTicket);
         

            var addAndSave = await _ticketRepository.AddTicketAsync(ticketModel);
            if (!addAndSave)
                return null;
            return ticketModel.ToDto();
        }

        /// <summary>
        /// گرفتن یک بلیط
        /// </summary>
        public async Task<TicketDto> GetOneTicket(Guid id)
        {
            var ticket = await _ticketRepository.GetTicketById(id);
            if (ticket == null)
                return null;
            return ticket.ToDto();
        }

        /// <summary>
        /// عوض کزدن وضعیت یک بلیط
        /// </summary>
        public async Task<string> ChangeTicketCondition(EditTicketConditionCommand command)
        {
            var ticket = await _ticketRepository.GetTicketById(command.TicketId);
            if (ticket == null)
                return null;
            ticket.Condition = command.ChangeCondition;
            var save = await _ticketRepository.SaveChangesAsync();
            if (!save)
                return null;
            return ticket.Condition.ToString();
        }

        #region Search Options
        /// <summary>
        /// جست و جوی بلیط فعال با یک تاریخ
        /// </summary>
        public async Task<List<TicketDto>> SearchReservedTicketsByDate(DateTime firstMiadiParse)
        {
            var OneDateTickets = await _ticketRepository.OneDateReservedTicketSearch(firstMiadiParse);
            if (OneDateTickets.Count == 0)
                return null;
            return OneDateTickets.ToDto();
        }

        /// <summary>
        /// جست و جوی بلیط فعال با دو تاریخ
        /// </summary>
        public async Task<List<TicketDto>> SearchReservedTicketsByDate(DateTime firstMiadiParse, DateTime secondMiladiParse)
        {
            var twoDateTickets = await _ticketRepository.TwoDateReservedTicketsSearch(firstMiadiParse, secondMiladiParse);
            if (twoDateTickets.Count == 0)
                return null;
            return twoDateTickets.ToDto();
        }

        /// <summary>
        ///  جست و جوی یک تاریخه برای جمع مبلغ بلیط های فعال
        /// </summary>
        public async Task<decimal> SearchReservedTicketsPriceByDateSum(DateTime firstMiadiParse)
        {
            return await _ticketRepository.OneDateReservedTicketsPriceSearchSum(firstMiadiParse);
        }

        /// <summary>
        ///  جست و جوی دو تاریخه برای جمع مبلغ بلیط های فعال
        /// </summary>
        public async Task<decimal> SearchReservedTicketsPriceByDateSum(DateTime firstMiadiParse, DateTime secondMiladiParse)
        {
            return await _ticketRepository.TwoDateReservedTicketsPriceSearchSum(firstMiadiParse, secondMiladiParse);
        }

        /// <summary>
        /// جست و جوی تعداد بلیط غیرفعال با یک تاریخ
        /// </summary>
        public async Task<List<TicketDto>> SearchInActivedTicketsByDate(DateTime firstMiadiParse)
        {
            var OneDateTickets = await _ticketRepository.OneDateInActivedTicketSearch(firstMiadiParse);
            if (OneDateTickets.Count == 0)
                return null;
            return OneDateTickets.ToDto();
        }

        /// <summary>
        /// جست و جوی تعداد بلیط غیرفعال با دو تاریخ
        /// </summary>
        public async Task<List<TicketDto>> SearchInActivedTicketsByDate(DateTime firstMiadiParse, DateTime secondMiladiParse)
        {
            var twoDateTickets = await _ticketRepository.TwoDateInActivedTicketsSearch(firstMiadiParse, secondMiladiParse);
            if (twoDateTickets.Count == 0)
                return null;
            return twoDateTickets.ToDto();
        }

        /// <summary>
        /// جست و جوی بلیط لغو شده با یک تاریخ
        /// </summary>
        public async Task<List<TicketDto>> SearchCanceledTicketsByDate(DateTime firstMiadiParse)
        {
            var OneDateTickets = await _ticketRepository.OneDateCanceledTicketSearch(firstMiadiParse);
            if (OneDateTickets.Count == 0)
                return null;
            return OneDateTickets.ToDto();
        }

        /// <summary>
        /// جست و جوی بلیط لغو شده با دو تاریخ
        /// </summary>
        public async Task<List<TicketDto>> SearchCanceledTicketsByDate(DateTime firstMiadiParse, DateTime secondMiladiParse)
        {
            var twoDateTickets = await _ticketRepository.TwoDateCanceledTicketsSearch(firstMiadiParse, secondMiladiParse);
            if (twoDateTickets.Count == 0)
                return null;
            return twoDateTickets.ToDto();
        }

        #endregion

        /// <summary>
        /// پاک کردن بلیط
        /// </summary>
        public async Task<bool> DeleteTicket(Guid id)
        {
            var ticket = await _ticketRepository.GetInActiveTicketById(id);
            if (ticket == null)
                return false;
            return await _ticketRepository.DeleteTicket(ticket);
        }

        /// <summary>
        /// ثبت خرید و فعال کردن بلیط
        /// </summary>
        public async Task<TicketDto> EntryBuyTicket(Guid id)
        {
            var ticket = await _ticketRepository.GetInActiveTicketById(id);
            if (ticket == null)
                return null;

            var schedule = await _ticketRepository.GetActiveScheduleById(ticket.ScheduleId);
            if (schedule == null)
                return null;

            var fun = await _ticketRepository.GetFunById(schedule.FunId);
            var user = await _ticketRepository.GetUserById(ticket.UserId);

            if (user.RoleType == RoleTypec.Seller)
                fun.SellerCapacity += ticket.NumberOfTicket;
            else
                fun.RealTimeCapacity -= ticket.NumberOfTicket;

            fun.OnlineCapacity -= ticket.NumberOfTicket;

            ticket.Condition = ECondition.Reservation;
            //schedule.AvailableCapacity -= ticket.NumberOfTicket;

            var save = await _ticketRepository.SaveChangesAsync();
            if (!save)
                return null;
            return ticket.ToDto();
        }

        /// <summary>
        /// لغو بلیط
        /// </summary>
        public async Task<decimal?> CancelTicket(Guid id)
        {
            var ticket = await _ticketRepository.GetReservedTicketById(id);
            var schedule = await _ticketRepository.GetScheduleByIdAsync(ticket.ScheduleId);
            var fun = await _ticketRepository.GetFunById(schedule.FunId);
            var user = await _ticketRepository.GetUserById(ticket.UserId);
            if (ticket == null)
                return null;

            if (user.RoleType == RoleTypec.Seller)
            {
                fun.SellerCapacity -= ticket.NumberOfTicket;
                fun.OnlineCapacity += ticket.NumberOfTicket;
            }

            fun.RealTimeCapacity += ticket.NumberOfTicket;
            ticket.Condition = ECondition.Cancel;
            //schedule.AvailableCapacity += ticket.NumberOfTicket;
            user.Wallet += ticket.TotalPrice;

            var save = await _ticketRepository.SaveChangesAsync();
            if (!save)
                return null;
            return schedule.AvailableCapacity;
        }


        #region ScheduleOptions

        /// <summary>
        /// گرفتن همه بلیط های یک سانس
        /// </summary>
        public async Task<List<TicketDto>> GetAllScheduleTickets(Guid id)
        {
            var tickets = await _ticketRepository.GetAllScheduleTickets(id);
            if (tickets == null)
                return null;
            return tickets.ToDto();
        }

        /// <summary>
        /// گرفتن همه بلیط های فعال یک سانس
        /// </summary>
        public async Task<List<TicketDto>> GetAllScheduleActiveTickets(Guid id)
        {
            var tickets = await _ticketRepository.GetAllScheduleActiveTickets(id);
            if (tickets == null)
                return null;
            return tickets.ToDto();
        }

        /// <summary>
        /// دریافت کل بلیط های غیرفعال یک سانس
        /// </summary>
        public async Task<List<TicketDto>> AllInActiveScheduleTickets(Guid id)
        {
            var tickets = await _ticketRepository.AllInActiveScheduleTickets(id);
            if (tickets == null)
                return null;
            return tickets.ToDto();
        }

        /// <summary>
        /// دریافت مقدار پول کل بلیط های فروخته شده
        /// </summary>
        public async Task<decimal> ScheduleTicketsPrice(Guid id)
        {
            return await _ticketRepository.ScheduleTicketsPrice(id);
        }

        /// <summary>
        /// دریافت همه بلیط های لغو شده یک سانس
        /// </summary>
        public async Task<List<TicketDto>> GetAllScheduleCanceledTickets(Guid id)
        {
            var tickets = await _ticketRepository.GetAllScheduleCanceledTickets(id);
            if (tickets == null)
                return null;
            return tickets.ToDto();
        }

        #endregion

        #region FunOptions

        /// <summary>
        /// دریافت همه بلیط های یک تفریح با آیدی تفریح
        /// </summary>
        public async Task<List<TicketDto>> GetAllFunTicketsWithFunID(Guid id)
        {
            var tickets = await _ticketRepository.GetAllFunTicketsWithFunID(id);
            if (tickets == null)
                return null;
            return tickets.ToDto();
        }

        /// <summary>
        /// دریافت همه بلیط های رزرو شده یک تفریح با آیدی تفریح
        /// </summary>
        public async Task<List<TicketDto>> GetAllFunActiveTicketsWithFunID(Guid id)
        {
            var tickets = await _ticketRepository.GetAllFunActiveTicketsWithFunID(id);
            if (tickets == null)
                return null;
            return tickets.ToDto();
        }

        /// <summary>
        /// دریافت همه بلیط های لغو شده یک تفریح با آیدی تفریح
        /// </summary>
        public async Task<List<TicketDto>> GetAllFunCanceledTicketsWithFunID(Guid id)
        {
            var tickets = await _ticketRepository.GetAllFunCanceledTicketsWithFunID(id);
            if (tickets == null)
                return null;
            return tickets.ToDto();
        }

        /// <summary>
        /// دریافت کل بلیط های غیرفعال یک تفریح با آیدی تفریح
        /// </summary>
        public async Task<List<TicketDto>> AllFunInActiveTickets(Guid id)
        {
            var tickets = await _ticketRepository.AllFunInActiveTickets(id);
            if (tickets == null)
                return null;
            return tickets.ToDto();
        }

        #endregion

        #region UserOptions
        /// <summary>
        /// دریافت کل بلیط های غیرفعال یک کاربر - سبد خرید
        /// </summary>
        public async Task<List<TicketDto>> AllUserInActiveTickets(Guid id)
        {
            var tickets = await _ticketRepository.AllUserInActiveTickets(id);
            if (tickets == null)
                return null;
            return tickets.ToDto();
        }

        /// <summary>
        /// دریافت تعداد کل بلیط های غیرفعال یک کاربر
        /// </summary>
        public async Task<int> InActiveUserTicketsCount(Guid id)
        {
            return await _ticketRepository.InActiveUserTicketsCount(id);
        }

        /// <summary>
        /// دریافت تعداد کل بلیط های رزرو یک کاربر
        /// </summary>
        public async Task<int> ReservationUserTicketsCount(Guid id)
        {
            return await _ticketRepository.ReservationUserTicketsCount(id);
        }

        /// <summary>
        /// دریافت تعداد کل بلیط های لغو شده یک کاربر
        /// </summary>
        public async Task<int> CanceledUserTicketsCount(Guid id)
        {
            return await _ticketRepository.CanceledUserTicketsCount(id);
        }

        /// <summary>
        /// دریافت همه بلیط های یک کاربر با آیدی کاربر
        /// </summary>
        public async Task<List<TicketDto>> GetAllUserTikcetsWithUserID(Guid id)
        {
            var tickets = await _ticketRepository.GetAllUserTikcetsWithUserID(id);
            if (tickets == null)
                return null;
            return tickets.ToDto();
        }

        /// <summary>
        /// دریافت همه بلیط های رزرو یک کاربر با آیدی کاربر
        /// </summary>
        public async Task<List<TicketDto>> GetAllUserActiveTikcetsWithUserID(Guid id)
        {
            var tickets = await _ticketRepository.GetAllUserActiveTikcetsWithUserID(id);
            if (tickets == null)
                return null;
            return tickets.ToDto();
        }

        /// <summary>
        /// دریافت همه بلیط های لغو شده یک کاربر با آیدی کاربر
        /// </summary>
        public async Task<List<TicketDto>> GetAllUserCanceledTikcetsWithUserID(Guid id)
        {
            var tickets = await _ticketRepository.GetAllUserCanceledTikcetsWithUserID(id);
            if (tickets == null)
                return null;
            return tickets.ToDto();
        }
        #endregion

        #region AllOptions
        /// <summary>
        /// دریافت همه بلیط های رزروی خریده شده بصورت حضوری
        /// </summary>
        public async Task<List<TicketDto>> AllPresenceReservationTickets()
        {
            var tickets = await _ticketRepository.AllPresenceReservationTickets();
            if (tickets == null)
                return null;
            return tickets.ToDto();
        }

        /// <summary>
        /// دریافت همه بلیط های رزروی خریده شده از سایت
        /// </summary>
        public async Task<List<TicketDto>> AllSiteReservationTickets()
        {
            var tickets = await _ticketRepository.AllSiteReservationTickets();
            if (tickets == null)
                return null;
            return tickets.ToDto();
        }

        /// <summary>
        /// دریافت همه بلیط ها
        /// </summary>
        public async Task<List<TicketDto>> AllTickets()
        {
            var tickets = await _ticketRepository.AllTickets();
            if (tickets == null)
                return null;
            return tickets.ToDto();
        }

        /// <summary>
        /// دریافت همه بلیط های لغو شده
        /// </summary>
        public async Task<List<TicketDto>> AllCanceledTickets()
        {
            var tickets = await _ticketRepository.AllCanceledTickets();
            if (tickets == null)
                return null;
            return tickets.ToDto();
        }

        /// <summary>
        /// دریافت همه بلیط های رزرو شده
        /// </summary>
        public async Task<List<TicketDto>> AllReservationTickets()
        {
            var tickets = await _ticketRepository.AllReservationTickets();
            if (tickets == null)
                return null;
            return tickets.ToDto();
        }

        #endregion

        #region Specials

        /// <summary>
        /// تغییر وضعیت بلیط های انجام شده به بازی شده
        /// </summary>
        public async Task<int> SetPerformedTicketsToPlayed()
        {
            var performedTickets = await _ticketRepository.GetAllPerformedTickets();
            if (performedTickets.Count == 0)
                return 0;

            foreach (var ticket in performedTickets)
            {
                ticket.Condition = ECondition.Played;
            }

            var save = await _ticketRepository.SaveChangesAsync();
            if (!save)
                return 503;
            return performedTickets.Count;
        }

        #endregion
    }
}
