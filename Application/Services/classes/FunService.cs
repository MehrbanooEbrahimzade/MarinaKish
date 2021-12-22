using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using Application.Commands.Fun;
using Application.Dtos;
using Application.Mappers;
using Application.Services.interfaces;
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
        public async void AddFunAsync(AddFunCommand command)
        {
            var funObj = command.ToModel();
            await _funRepository.AddFunAsync(funObj);
        }

        /// <summary>
        /// ویرایش تفریح
        /// </summary>
        public async Task UpdateFunAsync(UpdateFunCommand command)
        {
            var fun = await _funRepository.GetFunById(command.FunId);
            if (fun == null)
            {
                {
                    throw new Exception("Null");
                }
            }

            fun.UpdateFun(command.Name, command.About, command.Icon, command.BackgroundPicture, command.Video,
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
        public async void DeleteFunAsync(Guid id)
        {
            var fun = await _funRepository.GetFunById(id);
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
            var fun = await _funRepository.GetFunById(id);
            return fun?.ToDto();
        }

        /// <summary>
        /// گرفتن تفریح ها با نوع تفریح
        /// </summary>
        public async Task<FunDto> GetFunsWithFunType(string name)
        {
            var fun = await _funRepository.GetFunByFunType(name);
            return fun?.ToDto();
        }

        //        /// <summary>
        //        /// اضافه کردن عکس پس زمینه تفریح
        //        /// </summary>
        //        public async Task<string> AddFunBackgroundPicture(AddFileToFunCommand command)
        //        {
        //            var pic = await _funRepository.GetFileById(command.FileId);
        //            var fun = await _funRepository.GetFunById(command.FunId);

        //            if (pic == null || fun == null)
        //                return null;

        //            fun.SetBackgroundPicture(pic.Id.ToString()); 

        //            var save = await _funRepository.UpdateFunAsync();
        //            if (!save)
        //                return null;
        //            return fun.BackgroundPicture;
        //        }

        //        /// <summary>
        //        /// اضافه کردن آیکون تفریح
        //        /// </summary>
        //        public async Task<string> AddFunIcon(AddFileToFunCommand command)
        //        {
        //            var pic = await _funRepository.GetFileById(command.FileId);
        //            var fun = await _funRepository.GetFunById(command.FunId);
        //            if (pic == null || fun == null)
        //                return null;

        //            fun.SetIcon(pic.Id.ToString()); 

        //            var save = await _funRepository.UpdateFunAsync();
        //            if (!save)
        //                return null;
        //            return fun.Icon;
        //        }

        /// <summary>
        /// غیرفعال کردن یک تفریح
        /// </summary>
        //public async Task<bool> DisActiveFunById(Guid id)
        //{
        //    //var result = _funRepository.CheckFunTypeIsExist(id);
        //    //if (await result == false)
        //    //{
        //    //    throw new NullReferenceException();
        //    //}

        //    var fun = await _funRepository.GetActiveFunById(id);
        //    if (fun == null)
        //        return false;

        //    var funActiveSchedules = await _funRepository.GetAllFunActiveSchedulesById(id);

        //    foreach (var schedule in funActiveSchedules)
        //    {
        //        schedule.IsExist = false;
        //    }

        //    fun.SetIsActive(false);
        //    return await _funRepository.UpdateFunAsync();
        //}

        //        /// <summary>
        //        /// دوباره فعال کردن یک تفریح
        //        /// </summary>
        //        public async Task<bool> ReActiveFunById(Guid id)
        //        {
        //            var fun = await _funRepository.GetDisActiveFunById(id);
        //            if (fun == null)
        //                return false;

        //            var funDisActiveSchedules = await _funRepository.GetAllFunDisActiveSchedulesById(id);

        //            foreach (var schedule in funDisActiveSchedules)
        //            {
        //                schedule.IsExist = true;
        //            }

        //            fun.SetIsActive(true); 
        //            return await _funRepository.UpdateFunAsync();
        //        }

        /// <summary>
        /// دریافت همه تفریح های فعال
        /// </summary>
        public async Task<List<FunDto>> GetAllActivedFun()
        {
            var funs = await _funRepository.GetAllActivedFun();
            return funs.Count == 0 ? null : funs.ToDto();
        }

        /// <summary>
        /// دریافت همه تفریح های غیر فعال
        /// </summary>
        public async Task<List<FunDto>> GetAllDisActivedFun()
        {
            var funs = await _funRepository.GetAllDisActivedFun();
            return funs.Count == 0 ? null : funs.ToDto();
        }
    }
}
