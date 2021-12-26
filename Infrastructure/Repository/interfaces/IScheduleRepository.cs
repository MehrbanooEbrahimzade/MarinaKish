using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

namespace Infrastructure.Repository.interfaces
{
    public interface IScheduleRepository
    {
        //    /// <summary>
        //    /// دریافت تفریح با اسم تفریح
        //    /// </summary>
        //    Task<Fun> GetFunsByFunNameAsynch(FunType fun);

        //    /// <summary>
        //    /// دریافت تفریح با ایدی تفریح
        //    /// </summary>
        //    Task<Fun> GetFunByFunId(Guid id);

        //    /// <summary>
        //    /// اضافه کردن سانس به تیبل
        //    /// </summary>
        //    Task<bool> AddScheduleAsync(Schedule schedule);

        //    /// <summary>
        //    /// گرفتن همه سانس ها برای تفریح با نوع تفریح
        //    /// </summary>
        //    Task<List<Schedule>> GetAllSchedulesForFunWithFunType(FunType fun);

        //    /// <summary>
        //    /// گرفتن همه سانس ها برای تفریح با آیدی
        //    /// </summary>
        //    Task<List<Schedule>> GetAllSchedulesForFunWithId(Guid id);

        //    /// <summary>
        //    /// جستجوی سانس با تفریح و تاریخ
        //    /// </summary>
        //    Task<List<Schedule>> SearchSchedulesByTimeAndFun(DateTime excuteMiladiDate, Guid id);

        //    /// <summary>
        //    /// ذخیره اعمال انجام شده
        //    /// </summary>
        //    Task<bool> UpdateScheduleAsync();

        //    /// <summary>
        //    /// دریافت سانس با آیدی
        //    /// </summary>
        //    Task<Schedule> GetScheduleByIdAsync(Guid id);

        //    /// <summary>
        //    /// دریافت سانس فعال با آیدی
        //    /// </summary>
        //    Task<Schedule> GetActiveScheduleByIdAsync(Guid id);

        //    /// <summary>
        //    /// گرفتن تاریخ اخرین سانس با نوع تفریح
        //    /// </summary>
        //    Task<DateTime?> GetLastScheduleTimeByFunType(FunType funType);

        //    /// <summary>
        //    /// گرفتن تاریخ اخرین سانس با ایدی تفریح
        //    /// </summary>
        //    Task<DateTime?> GetLastScheduleTimeByFunId(Guid id);

        //    /// <summary>
        //    /// جست و جوی سانس ها با یک تاریخ
        //    /// </summary>
        //    Task<List<Schedule>> SearchScheduleByOneDate(DateTime firstDate);

        //    /// <summary>
        //    /// جست و جوی سانس ها با دو تاریخ
        //    /// </summary>
        //    Task<List<Schedule>> SearchScheduleByTwoDate(DateTime firstDate, DateTime secondDate);

        //    /// <summary>
        //    /// دریافت همه سانس های فعال تاریخ گذشته
        //    /// </summary>
        //    Task<List<Schedule>> GetAllExpiredActiveSchedules();
    }
}
