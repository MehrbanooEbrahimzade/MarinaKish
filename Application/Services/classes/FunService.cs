using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using Application.Commands.Fun;
using Application.Dtos;
using Application.Mappers;
using Application.Services.interfaces;
using Domain.IConfiguration;
using Microsoft.Extensions.Logging;
using Application.Commands.ScheduleInfo;
using Application.Helper;

namespace Application.Services.classes
{
    public class FunService : IFunService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        public FunService(IUnitOfWork unitOfWork, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        /// <summary>
        /// اضافه کردن تفریح
        /// </summary>
        public async Task<Guid> AddFunAsync(AddFunCommand command)
        {
            var fun = command.ToModel();

            var addFun = await _unitOfWork.Funs.AddAsync(fun);

            command.ScheduleInfo.FunId = fun.Id;

            await CreateAndAddSchedule(command.ScheduleInfo);

            if (!addFun)
                throw new ArgumentNullException("عملیات اضافه کردن تفریح با خطا مواجه شد!");

            await _unitOfWork.CompleteAsync();

            return fun.Id;
        }

        /// <summary>
        ///ساخت سانس از روی اطلاعاتش
        /// </summary>
        public async Task CreateAndAddSchedule(AddScheduleInfoCommand command)
        {
            var schedules = ScheduleMaker.MakeSchedule(command);
            await _unitOfWork.Schedules.AddScheduleAsync(schedules);
        }

        /// <summary>
        /// ویرایش تفریح
        /// </summary>
        public async Task UpdateFunAsync(UpdateFunCommand command)
        {
            var fun = await _unitOfWork.Funs.GetByIdAsync(command.FunId);

            if (fun == null)
                throw new NullReferenceException("تفریح یافت نشد!");

            fun.UpdateFun(command.Name, command.About, command.Icon, command.BackgroundPicture, command.Video, /*command.SliderPictures.ToModel(),*/
                    command.ScheduleInfo.StartTime, command.ScheduleInfo.EndTime,
                    command.ScheduleInfo.GapTime, command.ScheduleInfo.Duration,
                    command.ScheduleInfo.TotalCapacity, command.ScheduleInfo.PresenceCapacity,
                    command.ScheduleInfo.OnlineCapacity, command.ScheduleInfo.Amount);

            var getschedule = await _unitOfWork.Schedules.GetAllAsync(command.FunId);

            foreach (var item in getschedule)
            {
                item.ForPrice(command.ScheduleInfo.Amount);
            }



            await _unitOfWork.CompleteAsync();

        }

        /// <summary>
        /// غیرفعال کردن تفریح
        /// </summary>
        public async Task<bool> InactivateFunAsync(Guid id)
        {
            await _unitOfWork.Funs.InactivateFun(id);
            await _unitOfWork.Schedules.InactivateSchedulesAsync(id);
            await _unitOfWork.CompleteAsync();
            return true;
        }

        /// <summary>
        /// دریافت همه تفریح ها
        /// </summary>
        public async Task<List<FunDto>> GetAllFunAsync()
        {
            var funs = await _unitOfWork.Funs.AllAsync();
            return funs.ToDto();
        }

        /// <summary>
        /// گرفتن یک تفریح
        /// </summary>
        public async Task<FunDto> GetOneFunAsync(Guid id)
        {
            var fun = await _unitOfWork.Funs.GetByIdAsync(id);
            return fun?.ToDto();
        }

        /// <summary>
        /// گرفتن یک تفریح ها 
        /// </summary>
        public async Task<FunDto> GetFunsByIdAsynch(Guid id)
        {
            var fun = await _unitOfWork.Funs.GetByIdAsync(id);
            return fun?.ToDto();
        }


        /// <summary>
        /// دوباره فعال کردن یک تفریح
        /// </summary>
        public async Task<bool> ReActiveFunByIdAsynch(Guid id)
        {
            var fun = await _unitOfWork.Funs.GetDisActiveFunByIdAsynch(id);
            if (fun == null)
                return false;
            var funDisActiveSchedules = await _unitOfWork.Funs.GetAllFunDisActiveSchedulesById(id);

            foreach (var schedule in funDisActiveSchedules)
            {
                schedule.SetIsActive(true);
            }

            fun.SetIsActive(true);
            await _unitOfWork.CompleteAsync();
            return true;

        }

        /// <summary>
        /// دریافت همه تفریح های فعال
        /// </summary>
        public async Task<List<FunDto>> GetAllActivedFunAsynch()
        {
            var funs = await _unitOfWork.Funs.GetAllActiveFunAsync();
            return (List<FunDto>)(funs.Count == 0 ? null : funs.ToDto());
        }

        /// <summary>
        /// دریافت همه تفریح های غیر فعال
        /// </summary>
        public async Task<List<FunDto>> GetAllDisActivedFunAsynch()
        {
            var funs = await _unitOfWork.Funs.GetAllDisActiveFunAsync();
            return (List<FunDto>)(funs.Count == 0 ? null : funs.ToDto());
        }
    }
}
