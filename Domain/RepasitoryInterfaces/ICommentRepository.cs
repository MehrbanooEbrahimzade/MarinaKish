using Domain.Enums;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Domain.Models;

namespace Domain.RepasitoryInterfaces
{
    public interface ICommentRepository : IGenericRepository<Comment>
    {

        /// <summary> 
        /// اضافه کردن کامنت به تیبل
        /// </summary>
        Task<bool> AddAsync(Comment comment);

        /// <summary>
        /// دریافت کامنت با آیدی
        /// </summary>
        Task<Comment> GetById(Guid id);

        /// <summary>
        /// ذخیره کردن عملیات انجام شده
        /// </summary>

        Task<bool> SaveChangeAsync();

        /// <summary>
        /// دریافت کامنت های یک تفریح با وضعیت کامنت
        /// </summary>
        Task<List<Comment>> GetFunCommentsByStatus(Guid funId, Status status);



        ///// <summary>
        ///// دریافت کامنت با فان آیدی
        ///// </summary>
        //Task<Comment> GetByFunId(Guid funId);



    }
}
