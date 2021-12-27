using System.Threading.Tasks;
using Application.Commands.ScheduleInfo;

namespace Application.Services.interfaces
{
    public interface IScheduleInfoService
    {
        /// <summary>
        ///اضافه کردن  
        /// </summary>
        Task AddScheduleInfoAsync(AddScheduleInfoCommand command);


    }
}
