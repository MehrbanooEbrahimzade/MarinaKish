using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using Application.Commands.Fun;
using Application.Dtos;
using Application.Mappers;
using Application.Services.interfaces;
using Domain.RepasitoryInterfaces;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Infrastructure.Repository.interfaces;

namespace Application.Services.classes
{
    public class FunService : IFunService
    {
        private readonly IFunRepository _funRepository;

        public FunService(IFunRepository funRepository)
        {
            _funRepository = funRepository;
        }

        /// <summary>
        /// اضافه کردن تفریح
        /// </summary>
        public async Task AddFunAsync(AddFunCommand command)
        {
            var funObj =  command.ToModel();
             _funRepository.AddFunAsync(funObj);
        }

        /// <summary>
        /// ویرایش تفریح
        /// </summary>
        public async Task UpdateFunAsync(UpdateFunCommand command)
        {
            var fun = await _funRepository.GetFunByIdAsynch(command.FunId);
            if (fun == null)
            {
                {
                    throw new Exception("Null");
                }
            }

            fun.UpdateFun(command.Name, command.About, command.Icon, command.BackgroundPicture, command.Video,command.PictureSlider,
                    command.ScheduleInfo.StartTime, command.ScheduleInfo.EndTime,
                    command.ScheduleInfo.GapTime, command.ScheduleInfo.Duration,
                    command.ScheduleInfo.TotalCapacity, command.ScheduleInfo.PresenceCapacity,
                    command.ScheduleInfo.OnlineCapacity, command.ScheduleInfo.Amount);
            var save = await _funRepository.UpdateFunAsync();
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
            var fun = await _funRepository.GetFunByIdAsynch(id);
            if (fun == null)
            {
                throw new Exception("Not Null");
            }
            await _funRepository.DeleteFunAsync(fun.Id);
        }

        /// <summary>
        /// دریافت همه تفریح ها
        /// </summary>
        public async Task<List<FunDto>> GetAllFunAsync()
        {
            var funs = await _funRepository.GetAllFunAsync();
            return funs.ToDto();
        }

        /// <summary>
        /// گرفتن یک تفریح
        /// </summary>
        public async Task<FunDto> GetOneFunAsync(Guid id)
        {
            var fun = await _funRepository.GetFunByIdAsynch(id);
            return fun?.ToDto();
        }

        /// <summary>
        /// گرفتن تفریح ها با اسم تفریح
        /// </summary>
        public async Task<List<FunDto>> GetFunsWithFunNameAsynch(string name)
        {
            var fun = await _funRepository.GetFunsByFunNameAsynch(name);
            return fun?.ToDto();
        }

        /// <summary>
        /// غیرفعال کردن یک تفریح
        /// </summary>
        public async Task<bool> DisActiveFunByIdAsynch(Guid id)
        {
            var result = _funRepository.CheckFunTypeIsExistAsynch(id);
            if (await result == false)
            {
                throw new NullReferenceException();
            }

            var fun = await _funRepository.GetActiveFunByIdAsynch(id);
            if (fun == null)
                return false;

            var funActiveSchedules = await _funRepository.GetAllFunActiveSchedulesById(id);

            foreach (var schedule in funActiveSchedules)
            {
                schedule.SetIsActive(false);
            }

            fun.SetIsActive(false);
            return await _funRepository.UpdateFunAsync();
        }

        /// <summary>
        /// دوباره فعال کردن یک تفریح
        /// </summary>
        public async Task<bool> ReActiveFunByIdAsynch(Guid id)
        {
            var fun = await _funRepository.GetDisActiveFunByIdAsynch(id);
            if (fun == null)
                return false;
            var funDisActiveSchedules = await _funRepository.GetAllFunDisActiveSchedulesById(id);

            foreach (var schedule in funDisActiveSchedules)
            {
                schedule.SetIsActive(true);
            }

            fun.SetIsActive(true);
            return await _funRepository.UpdateFunAsync();
        }

        /// <summary>
        /// دریافت همه تفریح های فعال
        /// </summary>
        public async Task<List<FunDto>> GetAllActivedFunAsynch()
        {
            var funs = await _funRepository.GetAllActivedFunAsynh();
            return funs.Count == 0 ? null : funs.ToDto();
        }

        /// <summary>
        /// دریافت همه تفریح های غیر فعال
        /// </summary>
        public async Task<List<FunDto>> GetAllDisActivedFunAsynch()
        {
            var funs = await _funRepository.GetAllDisActivedFunAsynch();
            return funs.Count == 0 ? null : funs.ToDto();
        }
    }
}
