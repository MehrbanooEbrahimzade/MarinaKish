using Domain.RepasitoryInterfaces;
using System.Threading.Tasks;

namespace Domain.IConfiguration
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        ITicketRepository Tickets { get; }
        IScheduleInfoRepository ScheduleInfos { get; }
        IScheduleRepository Schedules { get; }
        IFunRepository Funs { get; }
        IFileRepository FileS { get; }
        IContactUsRepository ContactUs { get; }


        Task CompleteAsync();
    }
}
