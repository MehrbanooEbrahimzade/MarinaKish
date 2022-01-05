using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Application.Commands.ScheduleInfo;
using Application.Helper;
using Application.Mappers;
using Application.Services.interfaces;
using Domain.IConfiguration;
using Domain.Models;
using Domain.RepasitoryInterfaces;
using Microsoft.Extensions.Logging;

namespace Application.Services.classes
{
    public class ScheduleInfoService : IScheduleInfoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public ScheduleInfoService(IUnitOfWork unitOfWork,ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;

        }

        /// <summary> 
        ///اضافه کردن اطلاعات سانس و ساخت سانس از روی اطلاعاتش
        /// </summary>
        public void AddScheduleInfoAsync(AddScheduleInfoCommand command)
        {
            var scheduleInfo = command.ToModel();
            CreateAndAddSchedule(command);
            _scheduleInfoRepository.AddScheduleInfoAsync(scheduleInfo);
        }

        /// <summary>
        /// ادیت کردن اطلاعات سانس
        /// </summary>
        public async Task UpdateScheduleInfoAsync(UpdateScheduleInfoCommand command)
        {
            await _scheduleRepository.DeleteAllSchedulesOfaFun(command.FunId);
            CreateAndAddSchedule(command);
            var scheduleInfo = await _scheduleInfoRepository.GetByIdAsync(command.Id);
            scheduleInfo.UpdateScheduleInfo(command.StartTime, command.EndTime, command.GapTime, command.Duration
                , command.TotalCapacity, command.PresenceCapacity, command.OnlineCapacity, command.Amount);
        }

        public void CreateAndAddSchedule(AddScheduleInfoCommand command)
        {
            var schedules = ScheduleMaker.MakeSchedule(command);
            _scheduleRepository.AddScheduleAsync(schedules);
        }
    }
}
