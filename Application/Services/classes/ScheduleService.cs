using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Commands.Schedule;
using Application.Dtos;
using Application.Mappers;
using Application.Services.interfaces;
using Domain.Models;
using Infrastructure.Repository.interfaces;

namespace Application.Services.classes
{
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository _scheduleRepository;
        public ScheduleService(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        /// <summary>
        /// ساختن سانس
        /// </summary>
        public async Task<List<ScheduleDto>> CreateSchedule(AddScheduleCommand command)
        {
            var fun = await _scheduleRepository.GetFunByFunId(command.FunId);
            if (fun == null)
                return null;

            var lastScheduleDateTime = await _scheduleRepository.GetLastScheduleTimeByFunId(command.FunId);
            if (!lastScheduleDateTime.HasValue)
                lastScheduleDateTime = DateTime.Now.AddDays(1);
            DateTime scheduleExcuteTime = lastScheduleDateTime.Value;
            TimeSpan totalSansTime = new TimeSpan(0, fun.SansDuration + fun.SansGapTime, 0);
            var totalSansMinuteTime = (int)totalSansTime.TotalMinutes;
            var funEndTimeMin = (int)fun.EndTime.TotalMinutes;
            var funStartTimeMin = (int)fun.StartTime.TotalMinutes;
            var sansCount = (funEndTimeMin - funStartTimeMin) / totalSansMinuteTime;

            List<Schedule> schedules = new List<Schedule>();

            #region Create Schedules 
            for (int i = 0; i < command.NumberOfDays; i++)
            {
                for (int j = 0; j < sansCount; j++)
                {
                    var startTimes = fun.StartTime.Add(j * totalSansTime);
                    var sansModel = new Schedule(fun.FunType, scheduleExcuteTime, fun.Price, fun.SansTotalCapacity, fun.StartTime, fun.EndTime);
                  
                    //var sansModel = new Schedule(fun.SystemFunCode, fun.FunType, scheduleExcuteTime, fun.Price, startTimes, startTimes.Add(totalSansTime))
                    //{
                    // AvailableCapacity = fun.SansTotalCapacity,
                    //FunId = fun.Id
                    //};

                    fun.UpdateSchedule((int)sansModel.AvailableCapacity, (int)sansModel.AvailableCapacity); 
                    
                    await _scheduleRepository.AddScheduleAsync(sansModel);
                    schedules.Add(sansModel);
                }
                scheduleExcuteTime = scheduleExcuteTime.AddDays(1);
            }
            #endregion
            return schedules.ToDto();
        }

        /// <summary>
        /// گرفتن همه سانس ها برای یک تفریح - بدون تاریخ
        /// </summary>
        public async Task<List<ScheduleDto>> GetAllSchedulesForFun(Guid id)
        {
            var schedules = await _scheduleRepository.GetAllSchedulesForFunWithId(id);
            if (schedules == null)
                return null;
            return schedules.ToDto();
        }

        /// <summary>
        /// گرفتن همه سانس ها برای یک تفریح - به همراه تاریخ
        /// </summary>
        public async Task<List<ScheduleDto>> GetAllSchedulesForFun(Guid id, DateTime miladiDate)
        {
            var TimeSchedules = await _scheduleRepository.SearchSchedulesByTimeAndFun(miladiDate, id);
            if (TimeSchedules == null)
                return null;
            return TimeSchedules.ToDto();
        }

        /// <summary>
        /// لغو یا برگردوندن سانس
        /// </summary>
        public async Task<bool> CancelOrReExistSchedule(CancelOrReExistScheduleCommand command)
        {
            var schedule = await _scheduleRepository.GetScheduleByIdAsync(command.ScheduleId);
            schedule.IsExist = command.IsExist;
            var save = await _scheduleRepository.UpdateScheduleAsync();
            return schedule.IsExist;
        }

        /// <summary>
        /// لغو یا برگردوندن لیستی از سانس ها
        /// </summary>
        public async Task<bool> ScheduleListCORE(ScheduleListCORECommand command)
        {
            foreach (var guid in command.IDs)
            {
                var schedule = await _scheduleRepository.GetScheduleByIdAsync(guid);
                command.IsExist = command.IsExist;
            }
            await _scheduleRepository.UpdateScheduleAsync();
            return command.IsExist;
        }

        /// <summary>
        /// جست و جوی سانس ها با یک تاریخ
        /// </summary>
        public async Task<List<ScheduleDto>> SearchScheduleByDate(DateTime miladiFirstInputParse)
        {
            var oneDateSchedules = await _scheduleRepository.SearchScheduleByOneDate(miladiFirstInputParse);
            if (oneDateSchedules.Count == 0)
                return null;
            return oneDateSchedules.ToDto();
        }

        /// <summary>
        /// جست و جوی سانس ها با تاریخ بین دو تاریخ
        /// </summary>
        public async Task<List<ScheduleDto>> SearchScheduleByDate(DateTime miladiFirstInputParse, DateTime miladiSecondInputParse)
        {
            var twoDateSchedules = await _scheduleRepository.SearchScheduleByTwoDate(miladiFirstInputParse, miladiSecondInputParse);
            if (twoDateSchedules.Count == 0)
                return null;
            return twoDateSchedules.ToDto();
        }

        /// <summary>
        /// دریافت یک سانس
        /// </summary>
        public async Task<ScheduleDto> GetOneSchedule(Guid id)
        {
            var schedule = await _scheduleRepository.GetScheduleByIdAsync(id);
            if (schedule == null)
                return null;
            return schedule.ToDto();
        }

        /// <summary>
        /// تخفیف قیمت سانس ها با درصد تخفیف
        /// </summary>
        public async Task<List<ScheduleDto>> DiscountPercentListSchedules(DiscountPercentListSchedulesCommand command)
        {
            List<Schedule> schedules = new List<Schedule>();

            foreach (var guid in command.IDs)
            {
                var schedule = await _scheduleRepository.GetScheduleByIdAsync(guid);
                command.Price -= (schedule.Price * command.DiscountPercent) / 100;
                schedules.Add(schedule);
            }

            var save = await _scheduleRepository.UpdateScheduleAsync();
            if (!save || schedules.Count == 0)
                return null;
            return schedules.ToDto();
        }

        /// <summary>
        /// تخفیف قیمت سانس ها با قیمت تخفیف
        /// </summary>
        public async Task<List<ScheduleDto>> DiscountPriceListSchedules(DiscountPriceListSchedulesCommand command)
        {
            List<Schedule> schedules = new List<Schedule>();

            foreach (var guid in command.IDs)
            {
                var schedule = await _scheduleRepository.GetScheduleByIdAsync(guid);
                command.Price -= command.DiscountPrice;
                schedules.Add(schedule);
            }

            var save = await _scheduleRepository.UpdateScheduleAsync();
            if (!save || schedules.Count == 0)
                return null;
            return schedules.ToDto();
        }

        /// <summary>
        /// تخفیف قیمت تمام سانس های یک تفریح با درصد تخفیف
        /// </summary>
        public async Task<List<ScheduleDto>> DiscountPercentAllFunSchedules(DiscountPercentAllFunSchedulesCommand command)
        {
            var schedules = await _scheduleRepository.GetAllSchedulesForFunWithId(command.FunId);
            if (schedules.Count == 0)
                return null;
            for (int i = 0; i < schedules.Count; i++)
            {
                Schedule schedule = schedules[i];
                command.Price -= (command.Price * command.DiscountPercent) / 100;
            }

            var save = await _scheduleRepository.UpdateScheduleAsync();
            if (!save)
                return null;
            return schedules.ToDto();
        }

        /// <summary>
        /// تخفیف قیمت تمام سانس های یک تفریح با قیمت تخفیف
        /// </summary>
        public async Task<List<ScheduleDto>> DiscountPriceAllFunSchedules(DiscountPriceAllFunSchedulesCommand command)
        {
            var schedules = await _scheduleRepository.GetAllSchedulesForFunWithId(command.FunId);
            if (schedules.Count == 0)
                return null;
            for (int i = schedules.Count - 1; i >= 0; i--)
            {
                Schedule schedule = schedules[i];
                command.Price -= command.DiscountPrice;
            }

            var save = await _scheduleRepository.UpdateScheduleAsync();
            if (!save)
                return null;
            return schedules.ToDto();
        }

        /// <summary>
        /// افزایش درصد قیمت لیست سانس ها
        /// </summary>
        public async Task<List<ScheduleDto>> IncreaseListSchedulePricePercent(IncreaseListSchedulePricePercentCommand command)
        {
            List<Schedule> schedules = new List<Schedule>();

            foreach (var guid in command.IDs)
            {
                var schedule = await _scheduleRepository.GetScheduleByIdAsync(guid);
                command.Price += (schedule.Price * command.IncreasePricePercent) / 100;
                schedules.Add(schedule);
            }

            var save = await _scheduleRepository.UpdateScheduleAsync();
            if (!save || schedules.Count == 0)
                return null;
            return schedules.ToDto();
        }

        /// <summary>
        /// افزایش درصد قیمت کل سانس های یک تفریح
        /// </summary>
        public async Task<List<ScheduleDto>> IncreaseFunSchedulesPricePercent(IncreaseFunSchedulesPricePercentCommand command)
        {
            var schedules = await _scheduleRepository.GetAllSchedulesForFunWithId(command.FunId);
            if (schedules.Count == 0)
                return null;
            foreach (var schedule in schedules)
            {
                command.IncreasePricePercent += (schedule.Price * command.IncreasePricePercent) / 100;
            }

            var save = await _scheduleRepository.UpdateScheduleAsync();
            if (!save)
                return null;
            return schedules.ToDto();
        }

        /// <summary>
        /// افزایش قیمت کل سانس های یک تفریح
        /// </summary>
        public async Task<List<ScheduleDto>> IncreaseFunSchedulesPrice(IncreaseFunSchedulesPriceCommand command)
        {
            var schedules = await _scheduleRepository.GetAllSchedulesForFunWithId(command.FunId);
            if (schedules.Count == 0)
                return null;
            foreach (var schedule in schedules)
            {
                command.Price += command.IncreasePrice;
            }
            var save = await _scheduleRepository.UpdateScheduleAsync();
            if (!save)
                return null;
            return schedules.ToDto();
        }

        /// <summary>
        /// غیرفعال کردن همه سانس های تاریخ گذشته
        /// </summary>
        public async Task<List<ScheduleDto>> DisActiveAllExpiredSchedules()
        {
            var schedules = await _scheduleRepository.GetAllExpiredActiveSchedules();
            if (schedules.Count == 0)
                return null;
            foreach (var schedule in schedules)
            {
                schedule.IsExist = false;
            }

            var save = await _scheduleRepository.UpdateScheduleAsync();
            if (!save)
                return null;
            return schedules.ToDto();
        }

        /// <summary>
        /// اضافه کردن ظرفیت سانس
        /// </summary>
        public async Task<int> IncreaseScheduleCapacity(CapacityCommand command)
        {
            var schedule = await _scheduleRepository.GetActiveScheduleByIdAsync(command.ScheduleId);
            if (schedule == null)
                return 404;
            command.AvailableCapacity += command.Capacity;

            var save = await _scheduleRepository.UpdateScheduleAsync();
            if (!save)
                return 404;
            return (int)schedule.AvailableCapacity;
        }

        /// <summary>
        /// کم کردن ظرفیت سانس
        /// </summary>
        public async Task<int> ReduceScheduleCapacity(CapacityCommand command)
        {
            var schedule = await _scheduleRepository.GetActiveScheduleByIdAsync(command.ScheduleId);
            if (schedule == null)
                return 404;
            command.AvailableCapacity -= command.Capacity;

            var save = await _scheduleRepository.UpdateScheduleAsync();
            if (!save)
                return 404;
            return (int)schedule.AvailableCapacity;
        }
    }
}
