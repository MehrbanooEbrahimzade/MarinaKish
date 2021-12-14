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
    public class CommentRepository : BaseRepository, ICommentRepository
    {
        public CommentRepository(DatabaseContext context) : base(context)
        {

        }

        /// <summary>
        /// دریافت کاربر با نام کاربری
        /// </summary>
        public async Task<User> GetUserByPhone(string phone)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.PhoneNumber == phone);
        }

        /// <summary>
        /// درسافت تفریح با اسم تفریح
        /// </summary>
        public async Task<Fun> GetFunByFunType(FunType fun)
        {
            return await _context.Funs.FirstOrDefaultAsync(x => x.FunType == fun);
        }

        /// <summary>
        /// اضافه کردن کامنت به تیبل
        /// </summary>
        public async Task<bool> AddCommentAsync(Comment comment)
        {
            await _context.Comments.AddAsync(comment);
            return await _context.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// دریافت کامنت با آیدی
        /// </summary>
        public async Task<Comment> GetCommentById(Guid id)
        {
            return await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <summary>
        /// ذخیره کردن عملیات انجام شده
        /// </summary>
        public async Task<bool> SaveChangeCommentAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// گرفتن همه کامنت های قبول شده برای یک تفریح
        /// </summary>
        public async Task<List<Comment>> GetAllAcceptedCommentsForFun(Guid id)
        {
            return await _context.Comments
                .Where(x => x.FunId == id && x.Status == EStatus.Accepted)
                .OrderByDescending(x => x.SubmitDate)
                .ToListAsync();
        }

        /// <summary>
        /// دریافت کاربر فعال با آیدی
        /// </summary>
        public async Task<User> GetActiveUserById(Guid id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == id && x.IsActive == true);
        }

        /// <summary>
        /// دریافت کاربر با آیدی
        /// </summary>
        public async Task<User> GetUserById(Guid id)
        {
            return await _context.Users.SingleOrDefaultAsync(x => x.Id == id);
        }

        /// <summary>
        /// دریافت تفریح فعال با آیدی
        /// </summary>
        public async Task<Fun> GetActiveFunById(Guid id)
        {
            return await _context.Funs.FirstOrDefaultAsync(x => x.Id == id && x.IsActive == true);
        }

        /// <summary>
        /// دریافت تفریح با آیدی
        /// </summary>
        public async Task<Fun> GetFunById(Guid id)
        {
            return await _context.Funs.FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <summary>
        /// گرفتن همه کامنت های قبول شده یک کاربر
        /// </summary>
        public async Task<List<Comment>> GetAllAcceptedUserComments(Guid id)
        {
            return await _context.Comments
                .Where(x => x.UserId == id && x.Status == EStatus.Accepted)
                .OrderByDescending(x => x.SubmitDate)
                .ToListAsync();
        }

        /// <summary>
        /// دریافت کامنت قبول شده با آیدی
        /// </summary>
        public async Task<Comment> GetAcceptedCommentById(Guid id)
        {
            return await _context.Comments
                .FirstOrDefaultAsync(x => x.Id == id && x.Status == EStatus.Accepted);
        }

        /// <summary>
        /// دریافت کامنت درحال انتظار با آیدی
        /// </summary>
        public async Task<Comment> GetWaitingCommentById(Guid id)
        {
            return await _context.Comments
                .FirstOrDefaultAsync(x => x.Id == id && x.Status == EStatus.Waiting);
        }

        /// <summary>
        /// دریافت کامنت رد شده با آیدی
        /// </summary>
        public async Task<Comment> GetDeclinedCommentById(Guid id)
        {
            return await _context.Comments.FirstOrDefaultAsync(x => x.Id == id && x.Status == EStatus.Declined);
        }

        /// <summary>
        /// دریافت کامنت غیر بلاک شده با آیدی
        /// </summary>
        public async Task<Comment> GetNotBlockedCommentById(Guid id)
        {
            return await _context.Comments.FirstOrDefaultAsync(x => x.Id == id && x.Status != EStatus.Blocked);
        }

        /// <summary>
        /// دریافت کامنت های درحال انتظار یک تفریح با آیدی
        /// </summary>
        public async Task<List<Comment>> GetAllWaitingCommentsForFun(Guid id)
        {
            return await _context.Comments
                .Where(x => x.FunId == id && x.Status == EStatus.Waiting)
                .OrderByDescending(x => x.SubmitDate)
                .ToListAsync();
        }

        /// <summary>
        /// دریافت کامنت های رد شده یک تفریح با آیدی
        /// </summary>
        public async Task<List<Comment>> GetAllDeclinedCommentsForFun(Guid id)
        {
            return await _context.Comments
                .Where(x => x.FunId == id && x.Status == EStatus.Declined)
                .OrderByDescending(x => x.SubmitDate)
                .ToListAsync();
        }

        /// <summary>
        /// دریافت کامنت های بلاک شده یک تفریح با آیدی
        /// </summary>
        public async Task<List<Comment>> GetAllBlockedCommentsForFun(Guid id)
        {
            return await _context.Comments
                .Where(x => x.FunId == id && x.Status == EStatus.Blocked)
                .OrderByDescending(x => x.SubmitDate)
                .ToListAsync();
        }
    }
}
