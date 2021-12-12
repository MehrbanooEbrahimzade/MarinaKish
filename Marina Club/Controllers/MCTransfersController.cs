using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Application.Commands;
using Application.Services.interfaces;

namespace Marina_Club.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MCTransfersController : ApiController
    {
        private readonly IMarineCoinTransferService _MCTransferService;
        public MCTransfersController(IMarineCoinTransferService MCTransferService)
        {
            _MCTransferService = MCTransferService;
        }

        /// <summary>
        /// اضافه کردن کیف پول کاربر
        /// </summary>
        [HttpPost("IncreaseUserWallet/{id}")] // userid ( users model )
        public async Task<IActionResult> IncreaseUserWallet(Guid id, CoinCommand command)
        {
            var result = await _MCTransferService.IncreaseUserWallet(id, command.Coin);
            if (result == null)
                return BadReq(ApiMessage.WalletNotIncreased, new {Reasons = $"1-user is not active(is blocked), 2-user not found(user id is wrong)" });
            return OkResult(ApiMessage.WalletIncreased, new { Wallet = result });
        }

        /// <summary>
        /// کم کردن کیف پول کاربر
        /// </summary>
        [HttpPost("DecreaseUserWallet/{id}")] // userid ( users model )
        public async Task<IActionResult> DecreaseUserWallet(Guid id, CoinCommand command)
        {
            var result = await _MCTransferService.DecreaseUserWallet(id, command.Coin);
            if (result == null)
                return BadReq(ApiMessage.WalletNotDecreased, new { Reasons = $"1-user is not active(is blocked), 2-user not found(user id is wrong)" });
            return OkResult(ApiMessage.WalletDecreased, new { TransferInfo = $"Wallet : {result[0]}, ShomarehPeygiri : {result[1]}" });
        }

        /// <summary>
        /// همه تراکنش های انجام داده شده یک کاربر
        /// </summary>
        [HttpGet("AllUserTransfers/{id}")] // userid ( users model )
        public async Task<IActionResult> AllUserTransfers(Guid id)
        {
            var result = await _MCTransferService.AllUserTransfers(id);
            if (result == null)
                return BadReq(ApiMessage.UserNotHaveAnyTransfer);
            return OkResult(ApiMessage.GetUserRecentTransfer, new { RecentHistory = result });
        }

        /// <summary>
        /// تعداد همه تراکنش های انجام داده شده یک کاربر
        /// </summary>
        [HttpGet("AllUserTransfer-Count/{id}")] // userid ( users model )
        public async Task<IActionResult> AllUserTransfersCount(Guid id)
        {
            var result = await _MCTransferService.AllUserTransfersCount(id);
            if(result == 0)
                return BadReq(ApiMessage.UserNotHaveAnyTransfer);
            return OkResult(ApiMessage.GetUserRecentTransfer, new { RecentHistoryCount = result });
        }

        /// <summary>
        /// مقدار گردش مالی یک کاربر - همه تراکنش های انجام شده
        /// </summary>
        [HttpGet("TotalUserCoinTransfer-Sum/{id}")] // userid ( users model )
        public async Task<IActionResult> TotalUserCoinTransfersSum(Guid id)
        {
            var result = await _MCTransferService.TotalUserCoinTransfersSum(id);
            if (result == 0)
                return BadReq(ApiMessage.UserNotHaveAnyTransfer);
            return OkResult(ApiMessage.GetUserCoinTransfersSum, new { TotalCoinTransfer = result });
        }

        /// <summary>
        /// دریافت یک گردش مالی
        /// </summary>
        [HttpGet("GetOne/{id}")]
        public async Task<IActionResult> GetOneMarineCoinTransfer(Guid id)
        {
            var result = await _MCTransferService.GetOneMarineCoinTransfer(id);
            if (result == null)
                return BadReq(ApiMessage.GetMarineCoinTransferFail, new { Reason = $"wrong transfer id" });
            return OkResult(ApiMessage.GetMarineCoinTransfer, new { RecentTransfer = result });
        }

        /// <summary>
        /// همه تراکنش های مالی دریایی
        /// </summary>
        [HttpGet("AllMarineCoinTransfers")]
        public async Task<IActionResult> AllMarineCoinTransfers()
        {
            var result = await _MCTransferService.AllMarineCoinTransfers();
            if (result == null)
                return BadReq(ApiMessage.NotHaveAnyCoinTransfers);
            return OkResult(ApiMessage.GetMarineCoinTransfers, new { RecentTransfers = result });
        }

        /// <summary>
        /// تعداد همه تراکنش های مالی دریایی
        /// </summary>
        [HttpGet("AllMarineCoinTransfers-Count")]
        public async Task<IActionResult> AllMarineCoinTransfersCount()
        {
            var result = await _MCTransferService.AllMarineCoinTransfersCount();
            return OkResult(ApiMessage.GetMarineCoinTransfer, new { TransfersCount = result });
        }

        /// <summary>
        /// جمع مبلغ همه تراکنش ها
        /// </summary>
        [HttpGet("TotalCoinTransfers-Sum")]
        public async Task<IActionResult> TotalCoinTransfersSum()
        {
            var result = await _MCTransferService.TotalCoinTransfersSum();
            if (result == null)
                return BadReq(ApiMessage.TransferNotYet, new { CoinTransfersSum = 0 });
            return OkResult(ApiMessage.GetCoinTransfersSum, new { CoinTransfersSum = result });
        }

        /// <summary>
        /// جمع مبلغ همه تراکنش های یک کاربر
        /// </summary>
        //[HttpGet("TotalUsersCoinTransfer-Sum")] // add +seller in seller controller
        //public async Task<IActionResult> TotalUsersCoinTransferSum()
        //{
        //    var result = await _MCTransferService.TotalUsersCoinTransfersSum();
        //    return OkResult(ApiMessage.GetUsersCoinTransfersSum, new { UsersCoinTransfersSum = result });
        //} comment shod chon ekrarie --> total coin transfers

        /// <summary>
        /// جمع مبلغ کیف پول همه کاربران
        /// </summary>
        [HttpGet("UsersWallet-Sum")]
        public async Task<IActionResult> TotalUsersWalletSum()
        {
            var result = await _MCTransferService.TotalUsersWalletSum();
            if (result == 0)
                return BadReq(ApiMessage.TransferNotYet);
            return OkResult(ApiMessage.GetTotalUsersWallet, new { WalletsSum = result });
        }

        // add label to model to see incoming(variz be kife pul) ya outgoing(bardasht az kife pul) e
        // add searches wih shamsi ( sum , count )
    }
}
