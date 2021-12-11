using Marina_Club.Commands.User;
using Marina_Club.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marina_Club.Services.interfaces
{
    public interface ISellerService
    {
        /// <summary>
        /// دریافت همه فروشندگان
        /// </summary>
        Task<List<UserDto>> GetAllSellers();

        /// <summary>
        /// دریافت تعداد همه فروشندگان
        /// </summary>
        Task<int> GetAllSellersCount();

        /// <summary>
        /// دریافت بلیط های خریده شده توسط فروشنده
        /// </summary>
        Task<List<TicketDto>> GetAllSellerTickets(Guid id);

        /// <summary>
        /// دریافت تعداد بلیط های خریده شده توسط فروشنده
        /// </summary>
        Task<int> GetAllSellerTicketsCount(Guid id);

        /// <summary>
        /// دریافت تعداد بلیط های خریده شده توسط کل فروشندگان
        /// </summary>
        Task<int> GetAllSellersTicketsCount();

        /// <summary>
        /// دریافت بلیط های اخیر فروشندگان
        /// </summary>
        Task<List<TicketDto>> RecentlySellersTickets();

        /// <summary>
        /// اضافه کردن و خرید بلیط برای فروشندگان
        /// </summary>
        Task<List<TicketDto>> AddSellerTicket(AddSellerTicketCommand command);

        /// <summary>
        /// اضافه کردن مشخصات فروشنده - بروزرسانی پروفایل
        /// </summary>
        Task<UserDto> UpdateSellerProfile(Guid id, AddSellerInfoCommand command);
    }
}
