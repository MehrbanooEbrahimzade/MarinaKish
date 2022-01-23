using System;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.RepasitoryInterfaces
{
    public interface IScheduleInfoRepository : IGenericRepository<ScheduleInfo>
    {
        Task<bool> GetFunById(Guid funId);
    }
}
