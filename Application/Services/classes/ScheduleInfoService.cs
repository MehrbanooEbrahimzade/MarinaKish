using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Application.Commands.ScheduleInfo;
using Application.Helper;
using Application.Mappers;
using Application.Services.interfaces;
using Domain.Models;
using Domain.RepasitoryInterfaces;

namespace Application.Services.classes
{
    public class ScheduleInfoService: IScheduleInfoService
    {
        private readonly IScheduleInfoRepository _scheduleInfoRepository;
        private readonly IScheduleRepository _scheduleRepository;

        public ScheduleInfoService(IScheduleInfoRepository scheduleInfoRepository, IScheduleRepository scheduleRepository)
        {
            _scheduleInfoRepository = scheduleInfoRepository;
            _scheduleRepository = scheduleRepository;

        }

        /// <summary>
        ///اضافه کردن اطلاعات سانس و ساخت سانس از روی اطلاعاتش
        /// </summary>
        public async Task AddScheduleInfoAsync(AddScheduleInfoCommand command)
        {
            var scheduleInfo = command.ToModel();
            await CreateAndAddSchedule(command);
            await _scheduleInfoRepository.AddScheduleInfoAsync(scheduleInfo);
        }

        /// <summary>
        /// ادیت کردن اطلاعات سانس
        /// </summary>
        public async Task UpdateScheduleInfoAsync(UpdateScheduleInfoCommand command)
        {
             _scheduleRepository.DeleteAllSchedulesOfaFun(command.FunId);
             await CreateAndAddSchedule(command);
            var scheduleInfo = await _scheduleInfoRepository.GetByIdAsync(command.Id);
            scheduleInfo.UpdateScheduleInfo(command.StartTime, command.EndTime, command.GapTime, command.Duration
                , command.TotalCapacity, command.PresenceCapacity, command.OnlineCapacity, command.Amount);
        }

        public async Task deleteScheduleInfoAsync(Guid funId)
        {

        }
        public async Task CreateAndAddSchedule(AddScheduleInfoCommand command)
        {
            var schedules = ScheduleMaker.MakeSchedule(command);
             _scheduleRepository.AddScheduleAsync(schedules);
        }
    }
}
