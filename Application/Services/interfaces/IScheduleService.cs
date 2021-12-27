using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Commands.Schedule;
using Application.Dtos;

namespace Application.Services.interfaces
{
    public interface IScheduleService
    {
        /// <summary>
        /// ساخت پیشنهاد ویژه 
        /// </summary>
        Task AddSpecialOffer(AddSpecialOfferCommand command);


        //    /// <summary>
        //    /// ساختن سانس
        //    /// </summary>
        //    Task<List<ScheduleDto>> CreateSchedule(AddScheduleCommand command);

        //    /// <summary>
        //    /// گرفتن همه سانس ها برای یک تفریح - بدون تاریخ
        //    /// </summary>
        //    Task<List<ScheduleDto>> GetAllSchedulesForFun(Guid id);

        //    /// <summary>
        //    /// گرفتن همه سانس ها برای یک تفریح - به همراه تاریخ
        //    /// </summary>
        //    Task<List<ScheduleDto>> GetAllSchedulesForFun(Guid id, DateTime miladiDate);

        //    /// <summary>
        //    /// لغو یا برگردوندن سانس
        //    /// </summary>
        //    Task<bool> CancelOrReExistSchedule(CancelOrReExistScheduleCommand command);

        //    /// <summary>
        //    /// جست و جوی سانس ها با یک تاریخ
        //    /// </summary>
        //    Task<List<ScheduleDto>> SearchScheduleByDate(DateTime miladiFirstInputParse);

        //    /// <summary>
        //    /// جست و جوی سانس ها با تاریخ بین دو تاریخ
        //    /// </summary>
        //    Task<List<ScheduleDto>> SearchScheduleByDate(DateTime miladiFirstInputParse, DateTime miladiSecondInputParse);

        //    /// <summary>
        //    /// دریافت یک سانس
        //    /// </summary>
        //    Task<ScheduleDto> GetOneSchedule(Guid id);

        //    /// <summary>
        //    /// لغو یا برگردوندن سانس ها
        //    /// </summary>
        //    Task<bool> ScheduleListCORE(ScheduleListCORECommand command); //////

        //    /// <summary>
        //    /// تخفیف قیمت سانس ها با درصد تخفیف
        //    /// </summary>
        //    Task<List<ScheduleDto>> DiscountPercentListSchedules(DiscountPercentListSchedulesCommand command);

        //    /// <summary>
        //    /// تخفیف قیمت سانس ها با قیمت تخفیف
        //    /// </summary>
        //    Task<List<ScheduleDto>> DiscountPriceListSchedules(DiscountPriceListSchedulesCommand command);

        //    /// <summary>
        //    /// تخفیف قیمت تمام سانس های یک تفریح با درصد تخفیف
        //    /// </summary>
        //    Task<List<ScheduleDto>> DiscountPercentAllFunSchedules(DiscountPercentAllFunSchedulesCommand command);

        //    /// <summary>
        //    /// تخفیف قیمت تمام سانس های یک تفریح با قیمت تخفیف
        //    /// </summary>
        //    Task<List<ScheduleDto>> DiscountPriceAllFunSchedules(DiscountPriceAllFunSchedulesCommand command);

        //    /// <summary>
        //    /// افزایش درصد قیمت لیست سانس ها
        //    /// </summary>
        //    Task<List<ScheduleDto>> IncreaseListSchedulePricePercent(IncreaseListSchedulePricePercentCommand command);

        //    /// <summary>
        //    /// افزایش درصد قیمت کل سانس های یک تفریح
        //    /// </summary>
        //    Task<List<ScheduleDto>> IncreaseFunSchedulesPricePercent(IncreaseFunSchedulesPricePercentCommand command);

        //    /// <summary>
        //    /// افزایش قیمت کل سانس های یک تفریح
        //    /// </summary>
        //    Task<List<ScheduleDto>> IncreaseFunSchedulesPrice(IncreaseFunSchedulesPriceCommand command);

        //    /// <summary>
        //    /// غیرفعال کردن همه سانس های تاریخ گذشته
        //    /// </summary>
        //    Task<List<ScheduleDto>> DisActiveAllExpiredSchedules();

        //    /// <summary>
        //    /// اضافه کردن ظرفیت سانس
        //    /// </summary>
        //    Task<int> IncreaseScheduleCapacity(CapacityCommand command);

        //    /// <summary>
        //    /// کم کردن ظرفیت سانس
        //    /// </summary>
        //    Task<int> ReduceScheduleCapacity(CapacityCommand command);
    }
}
