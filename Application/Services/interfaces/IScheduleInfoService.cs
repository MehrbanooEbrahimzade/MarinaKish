using System.Threading.Tasks;
using Application.Commands.ScheduleInfo;

namespace Application.Services.interfaces
{
    public interface IScheduleInfoService
    {
        /// <summary>
        ///اضافه کردن  
        /// </summary>
        void AddScheduleInfoAsync(AddScheduleInfoCommand command);

        /// <summary>
        ///ادیت کردن  
        /// </summary>
        Task UpdateScheduleInfoAsync(UpdateScheduleInfoCommand command); 
        /// <summary>
        /// ساخت و اضافه کردن سانس
        /// </summary>
        void CreateAndAddSchedule(AddScheduleInfoCommand command);
    }
}