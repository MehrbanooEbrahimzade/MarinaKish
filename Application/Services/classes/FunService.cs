using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using Application.Commands.Fun;
using Application.Dtos;
using Application.Mappers;
using Application.Services.interfaces;
using Domain.IConfiguration;
using Microsoft.Extensions.Logging;

namespace Application.Services.classes
{
    public class FunService : IFunService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        public FunService(IUnitOfWork unitOfWork,ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        /// <summary>
        /// اضافه کردن تفریح
        /// </summary>
        public Guid AddFunAsync(AddFunCommand command)
        {
            var fun = command.ToModel();
            _unitOfWork.Funs.AddAsync(fun);
            return fun.Id;
        }

        /// <summary>
        /// ویرایش تفریح
        /// </summary>
        public async Task UpdateFunAsync(UpdateFunCommand command)
        {
            var fun = await _unitOfWork.Funs.GetByIdAsync(command.FunId);
            await _unitOfWork.Funs.DeleteSliderPicturesByFunAsync(fun);

            if (fun == null)
            {
                {
                    throw new Exception("Null");
                }
            }

            fun.UpdateFun(command.Name, command.About, command.Icon, command.BackgroundPicture, command.Video, command.SliderPictures.ToModel(),
                    command.ScheduleInfo.StartTime, command.ScheduleInfo.EndTime,
                    command.ScheduleInfo.GapTime, command.ScheduleInfo.Duration,
                    command.ScheduleInfo.TotalCapacity, command.ScheduleInfo.PresenceCapacity,
                    command.ScheduleInfo.OnlineCapacity, command.ScheduleInfo.Amount);
            var save = await _unitOfWork.Funs.UpdateFunAsync();
            if (!save)
            {
                throw new Exception("Not Save");
            }
        }

        /// <summary>
        /// حذف تفریح
        /// </summary>
        public async Task DeleteFunAsync(Guid id)
        {
            await _unitOfWork.Funs.DeleteAsync(id);
        }

        /// <summary>
        /// دریافت همه تفریح ها
        /// </summary>
        public async Task<List<FunDto>> GetAllFunAsync()
        {
            var funs = await _unitOfWork.Funs.AllAsync();
            return (List<FunDto>) funs.ToDto();
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
        /// گرفتن تفریح ها با اسم تفریح
        /// </summary>
        public async Task<FunDto> GetFunsWithFunNameAsynch(string name)
        {
            var fun = await _unitOfWork.Funs.GetFunsByFunNameAsync(name);
            return fun?.ToDto();
        }

        /// <summary>
        /// غیرفعال کردن یک تفریح
        /// </summary>
        public async Task<bool> DisActiveFunByIdAsynch(Guid id)
        {
            var result = _unitOfWork.Funs.CheckFunTypeIsExistAsync(id);
            if (await result == false)
            {
                throw new NullReferenceException();
            }

            var fun = await _unitOfWork.Funs.GetActiveFunByIdAsynch(id);
            if (fun == null)
                return false;

            var funActiveSchedules = await _unitOfWork.Funs.GetAllFunActiveSchedulesById(id);

            foreach (var schedule in funActiveSchedules)
            {
                schedule.SetIsActive(false);
            }

            fun.SetIsActive(false);
            return await _unitOfWork.Funs.UpdateFunAsync();
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
            return await _unitOfWork.Funs.UpdateFunAsync();
        }

        /// <summary>
        /// دریافت همه تفریح های فعال
        /// </summary>
        public async Task<List<FunDto>> GetAllActivedFunAsynch()
        {
            var funs = await _unitOfWork.Funs.GetAllActiveFunAsync();
            return (List<FunDto>) (funs.Count == 0 ? null : funs.ToDto());
        }

        /// <summary>
        /// دریافت همه تفریح های غیر فعال
        /// </summary>
        public async Task<List<FunDto>> GetAllDisActivedFunAsynch()
        {
            var funs = await _unitOfWork.Funs.GetAllDisActiveFunAsync();
            return (List<FunDto>) (funs.Count == 0 ? null : funs.ToDto());
        }
    }
}
