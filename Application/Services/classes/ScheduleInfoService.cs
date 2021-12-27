using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Application.Commands.ScheduleInfo;
using Application.Helper;
using Application.Mappers;
using Application.Services.interfaces;
using Domain.Models;
using Domain.RepositoryInterfaces;
using Infrastructure.RepositoryImplementation.Classes;

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
            var schedules=  ScheduleMaker.MakeSchedule(command);
            await _scheduleRepository.AddScheduleAsync(schedules);
            await _scheduleInfoRepository.AddScheduleInfoAsync(scheduleInfo);
        }

        ///// <summary>
        /////اضافه کردن سانس
        ///// </summary>
        //public async Task AddScheduleAsync(ScheduleInfo scheduleInfo)
        //{
        //}
    }
}
