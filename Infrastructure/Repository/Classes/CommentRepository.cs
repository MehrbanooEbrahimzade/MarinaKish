using Domain.Models;
using Domain.RepasitoryInterfaces;
using Infrastructure.Persist;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Classes
{
    public class CommentRepository : ICommentRepository
    {
        public CommentRepository(DatabaseContext context)
        {

        }

        Task<bool> IGenericRepository<Comment>.AddAsync(Comment entity)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Comment>> IGenericRepository<Comment>.AllAsync()
        {
            throw new NotImplementedException();
        }

        Task<bool> IGenericRepository<Comment>.DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        Task<Comment> IGenericRepository<Comment>.GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        ///// <summary>
        ///// اضافه کردن کامنت به تیبل
        ///// </summary>
        //public async Task<bool> AddAsync(Comment comment)
        //{ 
        //    await _context.Comments.AddAsync(comment);
        //    return await _context.SaveChangesAsync() > 0;
        //}

        ///// <summary>
        ///// دریافت کامنت با آیدی
        ///// </summary>
        //public async Task<Comment> GetById(Guid id)
        //{
        //    return await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);
        //}

        ///// <summary>
        ///// ذخیره کردن عملیات انجام شده
        ///// </summary>
        //public async Task<bool> SaveChangeAsync()
        //{
        //    return await _context.SaveChangesAsync() > 0;
        //}

        ///// <summary>
        ///// دریافت کامنت با فان آیدی
        ///// </summary>
        //public async Task<Comment> GetByFunId(Guid funId)
        //{
        //    return await _context.Comments
        //        .FirstOrDefaultAsync(x => x.FunId == funId );
        //}

        ///// <summary>
        ///// دریافت کامنت های یک تفریح با وضعیت کامنت
        ///// </summary>
        //public async Task<List<Comment>> GetFunCommentsByStatus(Guid funId, Status status)
        //{
        //    return await _context.Comments
        //        .Where(x => x.FunId == funId && x.Status == status)
        //        .OrderByDescending(x => x.SubmitDate)
        //        .ToListAsync();
        //}
    }
}
