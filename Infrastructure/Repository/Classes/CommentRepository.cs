using Domain.Enums;
using Domain.Models;
using Domain.RepasitoryInterfaces;
using Infrastructure.Persist;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Classes
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(DatabaseContext context, ILogger logger) : base(context, logger) { }

        /// <summary> 
        /// اضافه کردن کامنت به تیبل
        /// </summary>

        public override async Task<bool> AddAsync(Comment comment)
        {
            try
            {
                await dbSet.AddAsync(comment);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Add method error", typeof(CommentRepository));
                return false;
            }
        }


        /// <summary>
        /// دریافت کامنت با آیدی
        /// </summary>
        public override async Task<Comment> GetByIdAsync(Guid id)
        {
            try
            {
                var getcomment = await dbSet.FirstOrDefaultAsync(f => f.Id == id);

                if (getcomment == null)
                    throw new NullReferenceException("کامنتی شناسایی نشد");

                return getcomment;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} GetById method error", typeof(TicketRepository));
                return null;
            }

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
