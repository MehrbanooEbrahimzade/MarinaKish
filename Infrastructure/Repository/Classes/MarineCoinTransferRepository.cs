using Infrastructure.Persist;
using Infrastructure.Repository.Interfaces;

namespace Infrastructure.Repository.Classes
{
    public class MarineCoinTransferRepository : BaseRepository, IMarineCoinTransferRepository
    {
        public MarineCoinTransferRepository(DatabaseContext context) : base(context)
        {

        }

        //        /// <summary>
        //        /// اضافه کردن تراکنش سکه دریایی
        //        /// </summary>
        //        public async Task<bool> AddMCTransfer(CashTransfer coinTransfer)
        //        {
        //            await _context.MarineCoinTransfers
        //                .AddAsync(coinTransfer);
        //            return await _context.SaveChangesAsync() > 0;
        //        }

        //        /// <summary>
        //        /// همه تراکنش های مالی دریایی
        //        /// </summary>
        //        public async Task<List<CashTransfer>> AllMarineCoinTransfers()
        //        {
        //            return await _context.MarineCoinTransfers
        //                .OrderByDescending(x => x.TransferDate)
        //                .ToListAsync();
        //        }

        //        /// <summary>
        //        /// تعداد همه تراکنش های مالی دریایی
        //        /// </summary>
        //        public async Task<int> AllMarineCoinTransfersCount()
        //        {
        //            return await _context.MarineCoinTransfers
        //                .CountAsync();
        //        }

        //        /// <summary>
        //        /// همه تراکنش های انجام داده شده یک کاربر
        //        /// </summary>
        //        public async Task<List<CashTransfer>> AllUserTransfers(Guid id)
        //        {
        //            return await _context.MarineCoinTransfers
        //                .Where(x => x.UserId == id)
        //                .OrderByDescending(x => x.TransferDate)
        //                .ToListAsync();
        //        }

        //        /// <summary>
        //        /// تعداد همه تراکنش های انجام داده شده یک کاربر
        //        /// </summary>
        //        public async Task<int> AllUserTransfersCount(Guid id)
        //        {
        //            return await _context.MarineCoinTransfers
        //                .CountAsync(x => x.UserId == id);
        //        }

        //        /// <summary>
        //        /// گرفتن کاربر فعال با آیدی
        //        /// </summary>
        //        public async Task<User> GetActiveUserById(Guid id)
        //        {
        //            return await _context.Users
        //                .FirstOrDefaultAsync(x => x.Id == id && x.IsActive == true);
        //        }

        //        /// <summary>
        //        /// دریافت یک گردش مالی
        //        /// </summary>
        //        public async Task<CashTransfer> GetOneMarineCoinTransfer(Guid id)
        //        {
        //            return await _context.MarineCoinTransfers
        //                .FirstOrDefaultAsync(x => x.Id == id);
        //        }

        //        /// <summary>
        //        /// گرفتن کاربر با آیدی
        //        /// </summary>
        //        public async Task<User> GetUserById(Guid id)
        //        {
        //            return await _context.Users
        //                .SingleOrDefaultAsync(x => x.Id == id);
        //        }

        //        public async Task<bool> SaveChanges()
        //        {
        //            return await _context.SaveChangesAsync() > 0;
        //        }

        //        /// <summary>
        //        /// جمع مبلغ همه تراکنش ها
        //        /// </summary>
        //        public async Task<decimal> TotalCoinTransfersSum()
        //        {
        //            return await _context.MarineCoinTransfers
        //                .SumAsync(x => x.MarineCoin);
        //        }

        //        /// <summary>
        //        /// مقدار گردش مالی یک کاربر
        //        /// </summary>
        //        public async Task<decimal> TotalUserCoinTransfersSum(Guid id)
        //        {
        //            return await _context.MarineCoinTransfers
        //                .Where(x => x.UserId == id)
        //                .SumAsync(x => x.MarineCoin);
        //        }

        //        /// <summary>
        //        /// جمع مبلغ همه تراکنش های همه کاربران
        //        /// </summary>
        //        public async Task<decimal> TotalUsersCoinTransfersSum()
        //        {
        //            return await _context.MarineCoinTransfers
        //                .SumAsync(x => x.MarineCoin);
        //        }

        //        /// <summary>
        //        /// جمع مبلغ همه تراکنش های یک کاربر
        //        /// </summary>
        //        //public async Task<decimal> TotalUsersWalletSum()
        //        //{
        //        //    return await _context.Users
        //        //        .SumAsync(x => x.Wallet);
        //        //}
    }
}
