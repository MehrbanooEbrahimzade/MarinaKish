using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Application.Commands.ScheduleInfo;
using Application.Mappers;
using Application.Services.interfaces;
using Domain.RepositoryInterfaces;

namespace Application.Services.classes
{
    public class ScheduleInfoService: IScheduleInfoService
    {
        private readonly IScheduleInfoRepository _scheduleInfoRepository;

        public ScheduleInfoService(IScheduleInfoRepository scheduleInfoRepository)
        {
            _scheduleInfoRepository = scheduleInfoRepository;

        }

        /// <summary>
        ///اضافه کردن  
        /// </summary>
        public async Task AddScheduleInfoAsync(AddScheduleInfoCommand command)
        {
            var scheduleInfo = command.ToModel();
            await _scheduleInfoRepository.AddScheduleInfoAsync(scheduleInfo);
        }
    }
}
