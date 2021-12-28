using System.Threading.Tasks;
using Domain.Models;

namespace Infrastructure.Repository.Interfaces
{
    public interface IScheduleInfoRepository
    {
        Task AddScheduleInfoAsync(ScheduleInfo scheduleInfo);

    }
}
