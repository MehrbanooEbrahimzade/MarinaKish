using System;
using System.Collections.Generic;
using System.Text;
using Application.Commands.ScheduleInfo;
using Application.Services.interfaces;
using Domain.RepositoryInterfaces;

namespace Application.Services.classes
{
    public class ScheduleInfoService
    {
        private readonly IScheduleInfoRepository _scheduleInfoRepository;

        public ScheduleInfoService(IScheduleInfoRepository scheduleInfoRepository)
        {
            _scheduleInfoRepository = scheduleInfoRepository;

        }
        public void AddScheduleInfoAsync(AddScheduleInfoCommand command)
        {

        }


    }
}
