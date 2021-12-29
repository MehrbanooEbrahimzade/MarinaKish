using System;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.RepasitoryInterfaces
{
    public interface IScheduleInfoRepository
    {
        Task AddScheduleInfoAsync(ScheduleInfo scheduleInfo);
        Task<ScheduleInfo> GetByIdAsync(Guid id);
        Task DeleteScheduleInfoAsync(Guid id);

    }
}
