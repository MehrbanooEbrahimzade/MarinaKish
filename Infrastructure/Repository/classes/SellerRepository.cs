using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Models.enums;
using Infrastructure.Repository.interfaces;

namespace Infrastructure.Repository.classes
{
    public class SellerRepository : BaseRepository, ISellerRepository
    {
        public SellerRepository(DatabaseContext context) : base(context)
        {

        }

        /// <summary>
        /// اضافه کردن بلیط
        /// </summary>
        public async Task<bool> AddTicketAsync(Ticket ticketModel)
        {
            await _context.Tickets.AddAsync(ticketModel);
            return await _context.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// چک کننده وجود داشتن کد ملی
        /// </summary>
        public async Task<bool> AnyNationalCodeAsync(string nationalCode)
        {
            return await _context.Users
                .AnyAsync(x => x.NationalCode == nationalCode);
        }

        /// <summary>
        /// چک کردن درست بودن ایدی برای فروشنده
        /// </summary>
        public async Task<bool> CheckUserIdForSeller(Guid id)
        {
            return await _context.Users
                .AnyAsync(x => x.Id == id && x.RoleType == RoleType.Seller);
        }

        /// <summary>
        /// دریافت سانس فعال
        /// </summary>
        public async Task<Schedule> GetActiveScheduleById(Guid id)
        {
            return await _context.Schedules
                .FirstOrDefaultAsync(x => x.Id == id && x.IsExist == true);
        }

        /// <summary>
        /// دریافت فروشنده فعال
        /// </summary>
        public async Task<User> GetActiveSellerById(Guid id)
        {
            return await _context.Users
                .FirstOrDefaultAsync(x => x.Id == id && x.RoleType == RoleType.Seller);
        }

        /// <summary>
        /// دریافت تمامی بلیط های اخیر
        /// </summary>
        public async Task<List<Ticket>> GetAllRecentlyTickets()
        {
            return await _context.Tickets
                .Where(x => x.Condition != ECondition.InActive)
                .OrderByDescending(x => x.SubmitDate)
                .ToListAsync();
        }

        /// <summary>
        /// دریافت همه فروشندگان
        /// </summary>
        public async Task<List<User>> GetAllSellers()
        {
            return await _context.Users
                .Where(x =>x.RoleType == RoleType.Seller)
                .ToListAsync();
        }

        /// <summary>
        /// دریافت تعداد همه فروشندگان
        /// </summary>
        public async Task<int> GetAllSellersCount()
        {
            return await _context.Users
                .CountAsync(x => x.RoleType == RoleType.Seller);
        }

        /// <summary>
        /// دریافت بلیط های خریده شده توسط فروشنده
        /// </summary>
        public async Task<List<Ticket>> GetAllSellerTickets(Guid id)
        {
            return await _context.Tickets
                .Where(x => x.UserId == id && x.Condition == ECondition.Reservation)
                .OrderByDescending(x => x.SubmitDate)
                .ToListAsync();
        }

        /// <summary>
        /// دریافت تعداد بلیط های خریده شده توسط فروشنده
        /// </summary>
        public async Task<int> GetAllSellerTicketsCount(Guid id)
        {
            return await _context.Tickets
                .CountAsync(x => x.UserId == id && x.Condition == ECondition.Reservation);
        }

        /// <summary>
        /// دریافت تفریح
        /// </summary>
        public async Task<Fun> GetFunById(Guid id)
        {
            return await _context.Funs
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        /// <summary>
        /// ذخیره اعمال انجام شده
        /// </summary>
        public async Task<bool> SaveChanges()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
