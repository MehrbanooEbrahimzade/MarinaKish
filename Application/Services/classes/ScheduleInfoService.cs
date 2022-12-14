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
        private readonly IFunService _funService;

        public ScheduleInfoService(ILogger<ScheduleInfoService> logger, IUnitOfWork unitOfWork, IFunService funService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _funService = funService;

        }

        /// <summary> 
        ///اضافه کردن اطلاعات سانس و ساخت سانس از روی اطلاعاتش
        /// </summary>
        public async Task<bool> AddScheduleInfoAsync(AddScheduleInfoCommand command)
        {
            var checkgetfun = await _unitOfWork.ScheduleInfos.GetFunById(command.FunId);
            if (checkgetfun == false)
                throw new Exception("چنین تفریحی یافت نشد");

            //var scheduleInfo = new ScheduleInfo(command.StartTime, command.EndTime, command.GapTime, command.Duration, command.TotalCapacity, 
            //     command.PresenceCapacity, command.OnlineCapacity, command.Amount, command.FunId);

            var getschedule = await _unitOfWork.ScheduleInfos.GetByIdAsync(command.ScheduleInfoId);
            if (getschedule == null)
                throw new Exception("چنین اطلاعات سانسی وجود ندارد");

            getschedule.UpdateScheduleInfo(command.StartTime, command.EndTime, command.GapTime, command.Duration, command.TotalCapacity,
                command.PresenceCapacity, command.OnlineCapacity, command.Amount);


            var addschedule = _funService.CreateAndAddSchedule(command);
            if (addschedule == null)
                throw new Exception("عملیات اضافه کردن سانس انحام نشد");

            await _unitOfWork.CompleteAsync();

            return true;
        }

        /// <summary>
        /// ادیت کردن اطلاعات سانس
        /// </summary>
        //public async Task<bool> UpdateScheduleInfoAsync(UpdateScheduleInfoCommand command)
        //{
        //    await _unitOfWork.Schedules.DeleteAllSchedulesOfaFun(command.FunId);
        //    CreateAndAddSchedule(command);

        //    var scheduleInfo = await _unitOfWork.ScheduleInfos.GetByIdAsync(command.Id);

        //    if (scheduleInfo == null)
        //        throw new ArgumentNullException("چنین سانسی با چنین آی دیی یافت نشد");

        //    scheduleInfo.UpdateScheduleInfo(command.StartTime, command.EndTime, command.GapTime, command.Duration
        //        , command.TotalCapacity, command.PresenceCapacity, command.OnlineCapacity, command.Amount);

        //    await _unitOfWork.CompleteAsync();
        //    return true;
        //}

        ///// <summary>
        /////ساخت سانس از روی اطلاعاتش
        ///// </summary>
        //public void CreateAndAddSchedule(AddScheduleInfoCommand command)
        //{
        //    var schedules = ScheduleMaker.MakeSchedule(command);
        //    _unitOfWork.Schedules.AddScheduleAsync(schedules);

        //    _unitOfWork.CompleteAsync();
        //}
    }
}
