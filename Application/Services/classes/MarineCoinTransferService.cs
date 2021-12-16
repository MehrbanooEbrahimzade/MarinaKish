using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Mappers;
using Application.Services.interfaces;
using Domain.Models;

namespace Application.Services.classes
{
    public class MarineCoinTransferService : IMarineCoinTransferService
    {
        //        private readonly IMarineCoinTransferRepository _MCTransferRepository;
        //        public MarineCoinTransferService(IMarineCoinTransferRepository MCTransferRepository)
        //        {
        //            _MCTransferRepository = MCTransferRepository;
        //        }

        //        /// <summary>
        //        /// اضافه کردن کیف پول کاربر
        //        /// </summary>
        //        //public async Task<string> IncreaseUserWallet(Guid id, decimal Coin)
        //        //{
        //        //    var user = await _MCTransferRepository.GetActiveUserById(id);
        //        //    if (user == null)
        //        //        return null;
        //        //    var mcTransferModel = new CashTransfer(Coin, user.Id);

        //        //    user.Wallet += Coin;
        //        //    await _MCTransferRepository.AddMCTransfer(mcTransferModel);
        //        //    return user.Wallet.ToString();
        //        //}

        //        /// <summary>
        //        /// کم کردن کیف پول کاربر
        //        /// </summary>
        //        //public async Task<List<string>> DecreaseUserWallet(Guid id, decimal Coin)
        //        //{
        //        //    var user = await _MCTransferRepository.GetActiveUserById(id);
        //        //    if (user == null)
        //        //        return null;

        //        //    var mcTransferModel = new CashTransfer(Coin, user.Id);


        //        //    user.Wallet -= Coin;
        //        //    await _MCTransferRepository.AddMCTransfer(mcTransferModel);

        //        //    List<string> ResultList = new List<string>();
        //        //    ResultList.Add(user.Wallet.ToString());
        //        //    ResultList.Add(mcTransferModel.TransferNumber);
        //        //    return ResultList;
        //        //}

        //        ///// <summary>
        //        ///// همه تراکنش های مالی دریایی
        //        /// </summary>
        //        public async Task<List<CashTransferDto>> AllMarineCoinTransfers()
        //        {
        //            var marineTransfers = await _MCTransferRepository.AllMarineCoinTransfers();
        //            if (marineTransfers == null)
        //                return null;
        //            return marineTransfers.ToDto();
        //        }

        //        /// <summary>
        //        /// تعداد همه تراکنش های مالی دریایی
        //        /// </summary>
        //        public async Task<int> AllMarineCoinTransfersCount()
        //        {
        //            return await _MCTransferRepository.AllMarineCoinTransfersCount();
        //        }

        //        /// <summary>
        //        /// همه تراکنش های انجام داده شده یک کاربر
        //        /// </summary>
        //        public async Task<List<CashTransferDto>> AllUserTransfers(Guid id)
        //        {
        //            var marineTransfers = await _MCTransferRepository.AllUserTransfers(id);
        //            if (marineTransfers == null)
        //                return null;
        //            return marineTransfers.ToDto();
        //        }

        //        /// <summary>
        //        /// تعداد همه تراکنش های انجام داده شده یک کاربر
        //        /// </summary>
        //        public async Task<int> AllUserTransfersCount(Guid id)
        //        {
        //            return await _MCTransferRepository.AllUserTransfersCount(id);
        //        }

        //        /// <summary>
        //        /// دریافت یک گردش مالی
        //        /// </summary>
        //        public async Task<CashTransferDto> GetOneMarineCoinTransfer(Guid id)
        //        {
        //            var mcTransfer = await _MCTransferRepository.GetOneMarineCoinTransfer(id);
        //            if (mcTransfer == null)
        //                return null;
        //            return mcTransfer.ToDto();
        //        }


        //        /// <summary>
        //        /// جمع مبلغ همه تراکنش ها
        //        /// </summary>
        //        public async Task<string> TotalCoinTransfersSum()
        //        {
        //            var transferSum = await _MCTransferRepository.TotalCoinTransfersSum();
        //            if (transferSum == 0)
        //                return null;
        //            return transferSum.ToString();
        //        }

        //        /// <summary>
        //        /// مقدار گردش مالی یک کاربر
        //        /// </summary>
        //        public async Task<decimal> TotalUserCoinTransfersSum(Guid id)
        //        {
        //            return await _MCTransferRepository.TotalUserCoinTransfersSum(id);
        //        }

        //        /// <summary>
        //        /// جمع مبلغ همه تراکنش های همه کاربران
        //        /// </summary>
        //        public async Task<string> TotalUsersCoinTransfersSum()
        //        {
        //            var transfersSum = await _MCTransferRepository.TotalUsersCoinTransfersSum();
        //            if (transfersSum == 0)
        //                return null;
        //            return transfersSum.ToString();
        //        }

        //        /// <summary>
        //        /// جمع مبلغ همه تراکنش های یک کاربر
        //        /// </summary>
        //        //public async Task<decimal> TotalUsersWalletSum()
        //        //{
        //        //    var userWalletSum = await _MCTransferRepository.TotalUsersWalletSum();
        //        //    if (userWalletSum == 0)
        //        //        return 0;
        //        //    return userWalletSum;

        //}
    }
}
