using System.Threading.Tasks;
using Application.Commands.ScheduleInfo;

namespace Application.Services.interfaces
{
    public interface IScheduleInfoService
    {
        /// <summary>
        ///اضافه کردن  
        /// </summary>
        Task<bool> AddScheduleInfoAsync(AddScheduleInfoCommand command);

        ///// <summary>
        /////ادیت کردن  
        ///// </summary>
        //Task<bool> UpdateScheduleInfoAsync(UpdateScheduleInfoCommand command); 
        ///// <summary>
        ///// ساخت و اضافه کردن سانس
        ///// </summary> 
        //void CreateAndAddSchedule(AddScheduleInfoCommand command);
    }
}