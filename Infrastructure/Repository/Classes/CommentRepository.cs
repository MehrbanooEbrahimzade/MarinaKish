using Domain.Enums;
using Domain.Models;
using Domain.RepasitoryInterfaces;
using Infrastructure.Persist;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Classes
{
    public class CommentRepository : BaseRepository, ICommentRepository
    {
        public CommentRepository(DatabaseContext context) : base(context)
        {

        }

        /// <summary> 
        /// اضافه کردن کامنت به تیبل
        /// </summary>
        public async Task<bool> AddAsync(Comment comment)
        {
            await _context.Comments.AddAsync(comment);

            return await _context.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// دریافت کامنت با آیدی
        /// </summary>
        public async Task<Comment> GetById(Guid id)
        {
            return await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <summary>
        /// ذخیره کردن عملیات انجام شده
        /// </summary>
        public async Task<bool> SaveChangeAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// دریافت کامنت های یک تفریح با وضعیت کامنت
        /// </summary>
        public async Task<List<Comment>> GetFunCommentsByStatus(Guid funId, Status status)
        {
            return await _context.Comments
                .Where(x => x.FunId == funId && x.Status == status)
                .OrderByDescending(x => x.SubmitDate)
                .ToListAsync();
        }

        ///// <summary>
        ///// دریافت کامنت با فان آیدی
        ///// </summary>
        //public async Task<Comment> GetByFunId(Guid funId)
        //{
        //    return await _context.Comments
        //        .FirstOrDefaultAsync(x => x.FunId == funId );
        //}


    }
}
