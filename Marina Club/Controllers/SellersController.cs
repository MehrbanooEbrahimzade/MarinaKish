using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Marina_Club.Services.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marina_Club.Commands.User;

namespace Marina_Club.Controllers
{
    [Route("api/Users/[controller]")]
    [ApiController]
    public class SellersController : ApiController
    {
        private readonly ISellerService _sellerService;
        public SellersController(ISellerService sellerService)
        {
            _sellerService = sellerService;
        }

        /// <summary>
        /// اضافه کردن مشخصات فروشنده - بروزرسانی پروفایل
        /// </summary>
        [HttpPut("UpdateSellerProfile/{id}")]
        public async Task<IActionResult> UpdateSellerProfile(Guid id, AddSellerInfoCommand command)
        {
            command.Validate();
            var result = await _sellerService.UpdateSellerProfile(id, command);
            if (result == null)
                return BadReq(ApiMessage.SellerProfileUpdateFail, new { Reasons = $"1-this national code already exist, 2-seller is blocked, 3-seller id is wrong" });
            return OkResult(ApiMessage.SellerProfileUpdated, new { SellerObject = result });
        }

        /// <summary>
        /// اضافه کردن و خرید بلیط برای فروشندگان
        /// </summary>
        [HttpPost("AddSellerTicket")]
        public async Task<IActionResult> AddSellerTicket(AddSellerTicketCommand command)
        {
            command.Validate();
            var result = await _sellerService.AddSellerTicket(command);
            if(result == null)
                return BadReq(ApiMessage.TicketNotBuys, new { Reasons = $"1-number of ticket greater than schedule available ticket, 2-schedule is not active, 3-user is blocked,4-user is not seller, 5-seller id is wrong, 6-schedule id is wrong" });
            return OkResult(ApiMessage.SellerTicketsBuyedAndGetted, new { SellerBuyedTickets = result });
        }

        /// <summary>
        /// دریافت همه فروشندگان
        /// </summary>
        [HttpGet("AllSeller")]
        public async Task<IActionResult> GetAllSeller()
        {
            var result = await _sellerService.GetAllSellers();
            if (result == null)
                return BadReq(ApiMessage.MarineNoHaveSeller);
            return OkResult(ApiMessage.AllSellersAvailable, new { Sellers = result });
        }

        /// <summary>
        /// دریافت تعداد همه فروشندگان
        /// </summary>
        [HttpGet("AllSeller-Count")]
        public async Task<IActionResult> GetAllSellersCount()
        {
            var result = await _sellerService.GetAllSellersCount();
            if(result == 0)
                return BadReq(ApiMessage.MarineNoHaveSeller);
            return OkResult(ApiMessage.AllSellersAvailable, new { SellersCount = result });
        }

        /// <summary>
        /// دریافت بلیط های خریده شده توسط فروشنده
        /// </summary>
        [HttpGet("SellerTickets/{id}")] //user id - seller
        public async Task<IActionResult> GetAllSellerTickets(Guid id)
        {
            var result = await _sellerService.GetAllSellerTickets(id);
            if (result == null)
                return BadReq(ApiMessage.WrongSellerId, new { Reasons = $"1-seller not have any tickets, 2-wrong seller id" });
            return OkResult(ApiMessage.AllSellerTicketsAvailable, new { SellerTickets = result });
        }

        /// <summary>
        /// دریافت تعداد بلیط های خریده شده توسط فروشنده
        /// </summary>
        [HttpGet("SellerTickets-Count/{id}")] //user id - seller
        public async Task<IActionResult> GetAllSellerTicketsCount(Guid id)
        {
            var result = await _sellerService.GetAllSellerTicketsCount(id);
            if (result == 0)
                return BadReq(ApiMessage.WrongSellerId, new { Reasons = $"1-wrong seller id, 2-seller not have any tickets" });
            return OkResult(ApiMessage.AllSellerTicketsAvailable, new { SellerTicketsCount = result });
        }

        /// <summary>
        /// دریافت بلیط های اخیر فروشندگان
        /// </summary>
        [HttpGet("RecentlySellersTickets")] 
        public async Task<IActionResult> RecentlySellersTickets()
        {
            var result = await _sellerService.RecentlySellersTickets();
            return OkResult(ApiMessage.AllSellersTicketsAvailable, new { RecentlySellersTicket = result });
        }

        /// <summary>
        /// دریافت تعداد بلیط های خریده شده توسط کل فروشندگان
        /// </summary>
        [HttpGet("SellersTickets-Count")] 
        public async Task<IActionResult> GetAllSellersTicketsCount()
        {
            var result = await _sellerService.GetAllSellersTicketsCount();
            return OkResult(ApiMessage.AllSellersTicketsAvailable, new { SellersTicketsCount = result });
        }
    }
}
