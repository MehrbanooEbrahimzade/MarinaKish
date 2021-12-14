using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Models.enums;
using Infrastructure.Repository.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.classes
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(DatabaseContext context) : base(context)
        {

        }

        /// <summary>
        /// چک کردن unique بودن نام کاربری
        /// </summary>
        public async Task<bool> IsUserNameExist(string username)
        {
            var isExist = await _context.Users
                .AnyAsync(u => u.UserName == username);

            return isExist;
        }

        /// <summary>
        /// چک کردن unique بودن کد ملی
        /// </summary>
        public async Task<bool> isNCExist(string nationalCode)
        {
            return await _context.Users
                .AnyAsync(x => x.NationalCode == nationalCode);
        }

        /// <summary>
        /// چک کردن unique بودن شاره تلفن
        /// </summary>
        public async Task<bool> isPhoneExist(string phone)
        {
            return await _context.Users
                .AnyAsync(x => x.CellPhone == phone);
        }

        /// <summary>
        /// عملیات ثبت نام کاربر :
        /// </summary>
        public async Task<bool> UserSignUpAsync(User user)
        {
            await _context.AddAsync(user);
            return await _context.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// عملیات وارد شدن کاربر :
        /// </summary>
        public async Task<User> UserLoginAsync(string UserName)
        {
            return await _context.Users
                .Include(x => x.ContactInfo)
                .SingleOrDefaultAsync(x => x.UserName == UserName);
        }

        /// <summary>
        /// گرفتن کاربر با شماره تلفن :
        /// </summary>
        public async Task<User> GetUserByPhone(string phone)
        {
            return await _context.Users
                .Include(x => x.ContactInfo)
                .FirstOrDefaultAsync(x => x.CellPhone == phone);
        }

        /// <summary>
        /// ذخیره کردن عملیات انجام شده :
        /// </summary>
        public async Task<bool> UpdateUserAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// گرفتن کاربر با کد تایید :
        /// </summary>
        public async Task<Domain.Models.User> GetUserByVerifyCode(string verifyCode)
        {
            return await _context.Users
                .Include(x => x.ContactInfo)
                .SingleOrDefaultAsync(x => x.VerifyCode == verifyCode);
        }

        /// <summary>
        /// دریافت کاربر با آیدی
        /// </summary>
        public async Task<User> GetUserById(Guid id)
        {
            return await _context.Users
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <summary>
        /// پیدا کردن کاربر با نام کاربری
        /// </summary>
        public async Task<List<User>> SearchUserByNameOrUsername(string username)
        {
            return await _context.Users
                .FromSql("Select * from dbo.Users as u where u.FullName like {0} or u.UserName like {0}", $"%{username}%")
                .Where(x => x.IsActive == true)
                .ToListAsync();
        }

        /// <summary>
        /// گرفتن کل فروشندگان
        /// </summary>
        public async Task<List<User>> GetAllSeller()
        {
            return await _context.Users
                .Where(x => x.RoleType == RoleTypec.Seller && x.IsActive == true)
                .Include(x => x.ContactInfo)
                .ToListAsync();
        }

        /// <summary>
        /// گرفتن فایل با آیدی
        /// </summary>
        public async Task<File> GetFileById(Guid id)
        {
            return await _context.Files
                .SingleOrDefaultAsync(x => x.Id == id && x.IsActive == true);
        }

        /// <summary>
        /// دریافت کاربر بلاک شده
        /// </summary>
        public async Task<User> GetBlockedUser(Guid userid)
        {
            return await _context.Users
                .SingleOrDefaultAsync(x => x.Id == userid && x.IsActive == false);
        }

        /// <summary>
        /// همه کاربر های فعال
        /// </summary>
        public async Task<List<User>> AllActiveUsers()
        {
            return await _context.Users
                .Where(x => x.IsActive && x.RoleType == RoleTypec.Buyer)
                .OrderByDescending(x=> x.DateJoin)
                .ToListAsync();
        }

        /// <summary>
        /// تعداد همه کاربر های فعال
        /// </summary>
        public async Task<int> AllActiveUsersCount()
        {
            return await _context.Users
                .CountAsync(x => x.IsActive == true && x.RoleType == RoleTypec.Buyer);
        }

        /// <summary>
        ///  همه کاربر های بلاک شده
        /// </summary>
        public async Task<List<User>> AllBlockedUsers()
        {
            return await _context.Users
                .Where(x => x.IsActive == false)
                .OrderByDescending(x => x.DateJoin)
                .ToListAsync();
        }

        /// <summary>
        /// تعداد همه کاربر های بلاک شده
        /// </summary>
        public async Task<int> AllBlockedUsersCount()
        {
            return await _context.Users
                .CountAsync(x => x.IsActive == false);
        }

        /// <summary>
        /// دریافت کاربری که فروشنده نیست با آیدی
        /// </summary>
        public async Task<User> GetNotSellerUserById(Guid id)
        {
            return await _context.Users
                .FirstOrDefaultAsync(x => x.Id == id && x.RoleType != RoleTypec.Seller);
        }

        /// <summary>
        /// دریافت کاربری که ادمین نیست با آیدی
        /// </summary>
        public async Task<User> GetNotAdminUserById(Guid id)
        {
            return await _context.Users
                .FirstOrDefaultAsync(x => x.Id == id && x.RoleType != RoleTypec.Ad_min);
        }

        /// <summary>
        /// دریافت کاربری که ادمین یا فروشنده است با آیدی
        /// </summary>
        public async Task<User> GetAdminOrSellerUserById(Guid id)
        {
            return await _context.Users
                .FirstOrDefaultAsync(x => x.Id == id && x.RoleType != RoleTypec.Buyer);
        }

        /// <summary>
        /// دریافت کاربر فعال با آیدی
        /// </summary>
        public async Task<User> GetActiveUserById(Guid id)
        {
            return await _context.Users
                .FirstOrDefaultAsync(x => x.Id == id && x.IsActive == true);
        }

        /// <summary>
        /// دریافت همه بلیط های خریده شده یا لغو شده کاربر
        /// </summary>
        public async Task<List<Ticket>> AllBuyedOrCanceledUserTickets(Guid id)
        {
            return await _context.Tickets
                .Where(x => x.UserId == id && x.Condition != ECondition.InActive)
                .ToListAsync();
        }
    }
}
