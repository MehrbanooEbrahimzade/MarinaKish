using System.Threading.Tasks;
using Domain.Models;

namespace Domain.RepositoryInterfaces
{
    public interface IScheduleInfoRepository
    {
        Task AddScheduleInfoAsync(ScheduleInfo scheduleInfo);

    }
}
