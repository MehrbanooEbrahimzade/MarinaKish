using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Domain.RepasitoryInterfaces;
using Infrastructure.Persist;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repository.Classes
{
    public class UserRepository :  IUserRepository
    {
      
        protected readonly DatabaseContext _context;
        protected UserRepository(DatabaseContext context)
        {
            _context = context;
        }
    
        public async Task DeleteUser(User user)
        {
             _context.Users.Remove(user);
            
        }


        public async Task<User> GetUserById(string id)
        {
            var user =_context.Users.Include(x=>x.CreditCard).SingleOrDefault(x=>x.Id == id);        
            return  user;
        }

        public Task<User> SearchAsync(Guid id)
        {
            return _context.Users.Include(c => c.CreditCard)
                .FirstOrDefaultAsync(user => user.Id == id.ToString());
        }

        ///// <summary>
        ///// چک کردن unique بودن نام کاربری
        ///// </summary>
        //public async Task<bool> IsUserNameExist(string username)
        //{
        //    var isExist = await _context.Users
        //        .AnyAsync(u => u.UserName == username);

        //    return isExist;
        //}

        ///// <summary>
        ///// چک کردن unique بودن کد ملی
        ///// </summary>
        //public async Task<bool> IsNCExist(string nationalCode)
        //{
        //    return await _context.Users
        //        .AnyAsync(x => x.NationalCode == nationalCode);
        //}

        ///// <summary>
        ///// چک کردن unique بودن شاره تلفن
        ///// </summary>
        //public async Task<bool> IsPhoneExist(string phone)
        //{
        //    return await _context.Users
        //        .AnyAsync(x => x.PhoneNumber == phone);
        //}

        ///// <summary>
        ///// عملیات ثبت نام کاربر :
        ///// </summary>
        //public async Task<bool> UserSignUpAsync(User user)
        //{
        //    await _context.AddAsync(user);
        //    return await _context.SaveChangesAsync() > 0;
        //}

        ///// <summary>
        ///// عملیات وارد شدن کاربر :
        ///// </summary>
        //public async Task<User> UserLoginAsync(string UserName)
        //{
        //    return await _context.Users
        //        .SingleOrDefaultAsync(x => x.UserName == UserName);
        //}

        ///// <summary>
        ///// گرفتن کاربر با شماره تلفن :
        ///// </summary>
        //public async Task<User> GetUserByPhone(string phone)
        //{
        //    return await _context.Users
        //        .FirstOrDefaultAsync(x => x.PhoneNumber == phone);
        //}

        ///// <summary>
        ///// ذخیره کردن عملیات انجام شده :
        ///// </summary>
        //public async Task<bool> SaveChanges()
        //{
        //    return await _context.SaveChangesAsync() > 0;
        //}

        ///// <summary>
        ///// گرفتن کاربر با کد تایید :
        ///// </summary>
        //public async Task<User> GetUserByVerifyCode(string verifyCode)
        //{
        //    return await _context.Users
        //        .SingleOrDefaultAsync(x => x.VerifyCode == verifyCode);
        //}


        ///// <summary>
        //    /// دریافت کاربر با آیدی
        ////    /// </summary>
        ////    public async Task<User> GetUserById(Guid id)
        ////{
        ////    return await _context.Users
        ////        .FirstOrDefaultAsync(x => x.Id == id);
        ////}

        ///// <summary>
        ///// پیدا کردن کاربر با نام کاربری
        ///// </summary>
        //public async Task<List<User>> SearchUserByNameOrUsername(string username)
        //{
        //    return await _context.Users
        //        .FromSql("Select * from dbo.Users as u where u.FullName like {0} or u.UserName like {0}", $"%{username}%")
        //        .ToListAsync();
        //}

        ///// <summary>
        ///// گرفتن کل فروشندگان
        ///// </summary>
        //public async Task<List<User>> GetAllSeller()
        //{
        //    return await _context.Users
        //        .Where(x => x.RoleType == RoleType.Seller)
        //        .ToListAsync();
        //}

        ///// <summary>
        ///// گرفتن فایل با آیدی
        ///// </summary>
        //public async Task<MyFile> GetFileById(Guid id)
        //{
        //    return await _context.Files
        //        .SingleOrDefaultAsync(x => x.Id == id && x.IsActive == true);
        //}


        //    /// <summary>
        //    /// دریافت همه بلیط های خریده شده یا لغو شده کاربر
        ////    /// </summary>
        ////public async Task<List<Ticket>> AllBuyedOrCanceledUserTickets(Guid id)
        ////{
        ////    return await _context.Tickets
        ////        .Where(x => x.UserId == id && x.Condition != Condition.InActive)
        ////        .ToListAsync();
        ////}
    }
}
