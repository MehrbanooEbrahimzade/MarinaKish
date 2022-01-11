using Domain.Enums;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Domain.RepasitoryInterfaces
{
    public interface ICommentRepository : IGenericRepository<Comment>
    {

   

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
