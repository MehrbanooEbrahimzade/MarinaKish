using System.Threading.Tasks;
using Marina_Club.Commands.Fun;
using Marina_Club.Repository.interfaces;
using Marina_Club.Services.interfaces;
using Marina_Club.Mappers;
using System.Collections.Generic;
using Marina_Club.Dtos;
using System;

namespace Marina_Club.Services.classes
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
        public async Task<Guid?> AddFunAsync(AddFunCommand command)
        {
            var funObj = command.ToModel();
            var addFunResult = await _funRepository.AddFunAsync(funObj);
            if (!addFunResult)
                return null;
            return funObj.Id;
        }

        /// <summary>
        /// ویرایش تفریح
        /// </summary>
        public async Task<FunDto> UpdateFunAsync(UpdateFunCommand command)
        {
            var fun = await _funRepository.GetFunById(command.FunId);
            if (fun == null)
                return null;

            #region Update

            fun.FunType = command.FunType;

            fun.Price = command.Price;

            fun.StartTime = TimeSpan.Parse(command.StartTime);
            fun.EndTime = TimeSpan.Parse(command.EndTime);
            fun.SansDuration = command.SansDuration;
            fun.SansTotalCapacity = command.SansTotalCapacity;
            fun.SansGapTime = command.SansGapTime;

            fun.About = command.About;
            #endregion

            var save = await _funRepository.UpdateFunAsync();
            if (!save)
                return null;
            return fun.ToDto();
        }

        /// <summary>
        /// حذف تفریح
        /// </summary>
        public async Task<bool> DeleteFunAsync(Guid id)
        {
            var fun = await _funRepository.GetFunById(id);
            if (fun == null)
                return false;
            return await _funRepository.DeleteFunAsync(fun);
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
            if (fun == null)
                return null;
            return fun.ToDto();
        }

        /// <summary>
        /// گرفتن تفریح ها با نوع تفریح
        /// </summary>
        public async Task<List<FunDto>> GetFunsWithFunType(GetFunWithFunTypeCommand command)
        {
            var funs = await _funRepository.GetFunsWithFunType(command.FunType);
            if (funs == null)
                return null;
            return funs.ToDto();
        }

        /// <summary>
        /// اضافه کردن عکس پس زمینه تفریح
        /// </summary>
        public async Task<string> AddFunBackgroundPicture(AddFileToFunCommand command)
        {
            var pic = await _funRepository.GetFileById(command.FileId);
            var fun = await _funRepository.GetFunById(command.FunId);

            if (pic == null || fun == null)
                return null;

            fun.BackgroundPicture = pic.Id.ToString();

            var save = await _funRepository.UpdateFunAsync();
            if (!save)
                return null;
            return fun.BackgroundPicture;
        }

        /// <summary>
        /// اضافه کردن آیکون تفریح
        /// </summary>
        public async Task<string> AddFunIcon(AddFileToFunCommand command)
        {
            var pic = await _funRepository.GetFileById(command.FileId);
            var fun = await _funRepository.GetFunById(command.FunId);
            if (pic == null || fun == null)
                return null;

            fun.icon = pic.Id.ToString();

            var save = await _funRepository.UpdateFunAsync();
            if (!save)
                return null;
            return fun.icon;
        }

        /// <summary>
        /// غیرفعال کردن یک تفریح
        /// </summary>
        public async Task<bool> DisActiveFunById(Guid id)
        {
            var fun = await _funRepository.GetActiveFunById(id);
            if (fun == null)
                return false;

            var funActiveSchedules = await _funRepository.GetAllFunActiveSchedulesById(id);

            foreach (var schedule in funActiveSchedules)
            {
                schedule.IsExist = false;
            }

            fun.IsActive = false;
            return await _funRepository.UpdateFunAsync();
        }

        /// <summary>
        /// دوباره فعال کردن یک تفریح
        /// </summary>
        public async Task<bool> ReActiveFunById(Guid id)
        {
            var fun = await _funRepository.GetDisActiveFunById(id);
            if (fun == null)
                return false;

            var funDisActiveSchedules = await _funRepository.GetAllFunDisActiveSchedulesById(id);

            foreach (var schedule in funDisActiveSchedules)
            {
                schedule.IsExist = true;
            }

            fun.IsActive = true;
            return await _funRepository.UpdateFunAsync();
        }

        /// <summary>
        /// دریافت همه تفریح های فعال
        /// </summary>
        public async Task<List<FunDto>> GetAllActivedFun()
        {
            var funs = await _funRepository.GetAllActivedFun();
            if (funs.Count == 0)
                return null;
            return funs.ToDto();
        }

        /// <summary>
        /// دریافت همه تفریح های غیر فعال
        /// </summary>
        public async Task<List<FunDto>> GetAllDisActivedFun()
        {
            var funs = await _funRepository.GetAllDisActivedFun();
            if (funs.Count == 0)
                return null;
            return funs.ToDto();
        }
    }
}
