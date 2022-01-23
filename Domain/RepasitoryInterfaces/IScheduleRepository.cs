using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.RepasitoryInterfaces
{
    public interface IScheduleRepository : IGenericRepository<Schedule>
    {
        /// <summary>
        /// اضافه کردن یک سانس
        /// </summary> 
        Task AddScheduleAsync(List<Schedule> schedules);
        /// <summary>
        /// پاک کردن همه سانس های یک تفریح
        /// </summary>
        Task<bool> DeleteAllSchedulesOfaFun(Guid funId);
        /// <summary>
        /// دریافت سانس های یک تفریح با ایدی تفریح
        /// </summary>
        Task<List<Schedule>> GetFunSchedulesByFunId(Guid funId);

        Task<Schedule> GetActiveScheduleByIdAsync(Guid id);

        /// <summary>
        /// غیر فعال کردن سانس های یک فان
        /// </summary>
        Task<bool> InactivateSchedulesAsync(Guid funId);

        /// <summary>
        /// دریافت تمام سانس های یک تفریح
        /// </summary>
        Task<List<Schedule>> GetSchedulesForFunAsync(Guid id);
        Task<List<Schedule>> GetAllAsync(Guid id);

        /// <summary>
        /// دریافت تمام سانس های تفریح با تاریخ 
        /// </summary>
        Task<List<Schedule>> GetAllByDateAsync(Guid id, DateTime dateTime);

    }
}
