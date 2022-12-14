using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Commands.User;
using Application.Dtos;
using Application.Mappers;
using Application.Services.interfaces;
using Domain.Models;

namespace Application.Services.classes
{
    public class SellerService : ISellerService
    {
        //        private readonly ISellerRepository _sellerRepository;

        //        public SellerService(ISellerRepository sellerRepository)
        //        {
        //            _sellerRepository = sellerRepository;
        //        }

        //        /// <summary>
        //        /// اضافه کردن و خرید بلیط برای فروشندگان
        //        /// </summary>
        //        public async Task<List<TicketDto>> AddSellerTicket(AddSellerTicketCommand command)
        //        {
        //            var schedule = await _sellerRepository.GetActiveScheduleById(command.ScheduleId);
        //            var fun = await _sellerRepository.GetFunByIdAsynch(schedule.FunId);
        //            var user = await _sellerRepository.GetActiveSellerById(command.SellerId);


        //            if (command.NumberOfTicket > schedule.AvailableCapacity || schedule == null || user == null)
        //                return null;

        //            List<Ticket> ResultBuyedTicket = new List<Ticket>();
        //            for (int i = 0; i < command.NumberOfTicket; i++)
        //            {

        //                var ticketModel = new Ticket(schedule.FunType, schedule.ExecuteDateTime, schedule.Start, schedule.End, 1);

        //                var addTicket = await _sellerRepository.AddTicketAsync(ticketModel);
        //                if (addTicket)
        //                    ResultBuyedTicket.Add(ticketModel);
        //            }

        //            command.AvailableCapacity -= ResultBuyedTicket.Count;
        //            fun.MinusOnlineCapacity(ResultBuyedTicket.Count);
        //            fun.PlusSellerCapacity(ResultBuyedTicket.Count); 

        //            var save = await _sellerRepository.SaveChanges();
        //            if (save)
        //                return ResultBuyedTicket.ToDto();
        //            return null;
        //        }

        //        /// <summary>
        //        /// دریافت همه فروشندگان
        //        /// </summary>
        //        public async Task<List<UserDto>> GetAllSellers()
        //        {
        //            var sellers = await _sellerRepository.GetAllSellers();
        //            if (sellers == null)
        //                return null;
        //            return sellers.ToDto();
        //        }

        //        /// <summary>
        //        /// دریافت تعداد همه فروشندگان
        //        /// </summary>
        //        public async Task<int> GetAllSellersCount()
        //        {
        //            return await _sellerRepository.GetAllSellersCount();
        //        }

        //        /// <summary>
        //        /// دریافت تعداد بلیط های خریده شده توسط کل فروشندگان
        //        /// </summary>
        //        public async Task<int> GetAllSellersTicketsCount()
        //        {
        //            var tickets = await _sellerRepository.GetAllRecentlyTickets();

        //            var SellersTicketsCount = 0;

        //            foreach (var ticket in tickets)
        //            {
        //                var isIDForUser = await _sellerRepository.CheckUserIdForSeller(ticket.UserId);
        //                if (isIDForUser)
        //                    SellersTicketsCount++;
        //            }

        //            return SellersTicketsCount;
        //        }

        //        /// <summary>
        //        /// دریافت بلیط های خریده شده توسط فروشنده
        //        /// </summary>
        //        public async Task<List<TicketDto>> GetAllSellerTickets(Guid id)
        //        {
        //            var isIDForSeller = await _sellerRepository.CheckUserIdForSeller(id);
        //            var tickets = await _sellerRepository.GetAllSellerTickets(id);
        //            if (!isIDForSeller || tickets == null)
        //                return null;
        //            return tickets.ToDto();
        //        }

        //        /// <summary>
        //        /// دریافت تعداد بلیط های خریده شده توسط فروشنده
        //        /// </summary>
        //        public async Task<int> GetAllSellerTicketsCount(Guid id)
        //        {
        //            var isIDForSeller = await _sellerRepository.CheckUserIdForSeller(id);
        //            if (!isIDForSeller)
        //                return 0;
        //            return await _sellerRepository.GetAllSellerTicketsCount(id);
        //        }

        //        /// <summary>
        //        /// دریافت بلیط های اخیر فروشندگان
        //        /// </summary>
        //        public async Task<List<TicketDto>> RecentlySellersTickets()
        //        {
        //            var tickets = await _sellerRepository.GetAllRecentlyTickets();

        //            List<TicketDto> ResultTicketList = new List<TicketDto>();

        //            foreach (var ticket in tickets)
        //            {
        //                var isIDForUser = await _sellerRepository.CheckUserIdForSeller(ticket.UserId);
        //                if (isIDForUser)
        //                    ResultTicketList.Add(ticket.ToDto());
        //            }

        //            return ResultTicketList;
        //        }

        //        /// <summary>
        //        /// اضافه کردن مشخصات فروشنده - بروزرسانی پروفایل
        //        /// </summary>
        //        public async Task<UserDto> UpdateSellerProfile(Guid id, AddSellerInfoCommand command)
        //        {
        //            var seller = await _sellerRepository.GetActiveSellerById(id);
        //            if (seller == null)
        //                return null;

        //            if(seller.NationalCode != command.NationalCode)
        //            {
        //                var anyNationalCode = await _sellerRepository.AnyNationalCodeAsync(command.NationalCode);
        //                if (anyNationalCode)
        //                    return null;
        //                seller.NationalCode = command.NationalCode;
        //            }
        //            seller.CreditCardCommand.CardNumber = command.CardNumber;
        //            seller.CreditCardCommand.ShabaNumber = command.ShabaNumber;
        //            await _sellerRepository.SaveChanges();
        //            return seller.ToDto();
        //        }
    }
}
