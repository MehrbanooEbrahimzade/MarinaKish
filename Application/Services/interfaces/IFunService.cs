using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Commands.Fun;
using Application.Dtos;

namespace Application.Services.interfaces
{
    public interface IFunService
    {
        /// <summary>
        /// اضافه کردن تفریح
        /// </summary>
        void AddFunAsync(AddFunCommand command);

        /// <summary>
        /// ویرایش تفریح
        /// </summary>
        Task UpdateFunAsync(UpdateFunCommand command);

        /// <summary>
        /// حذف تفریح
        /// </summary>
        void DeleteFunAsync(Guid id);

        /// <summary>
        /// دریافت همه تفریح ها
        /// </summary>
        Task<List<FunDto>> GetAllFunAsync();

        /// <summary>
        /// گرفتن یک تفریح
        /// </summary>
        Task<FunDto> GetOneFunAsync(Guid id);

        /// <summary>
        /// گرفتن تفریح ها با نوع تفریح
        /// </summary>
        Task<FunDto> GetFunsWithFunType(string name);

        ///// <summary>
        ///// اضافه کردن عکس پس زمینه تفریح
        ///// </summary>
        //Task<string> AddFunBackgroundPicture(AddFileToFunCommand command);

        ///// <summary>
        ///// اضافه کردن آیکون تفریح
        ///// </summary>
        //Task<string> AddFunIcon(AddFileToFunCommand command);

        /// <summary>
        /// غیرفعال کردن یک تفریح
        /// </summary>
        //Task<bool> DisActiveFunById(Guid id);

        /// <summary>
        /// دوباره فعال کردن یک تفریح
        /// </summary>
        //Task<bool> ReActiveFunById(Guid id);

        /// <summary>
        /// دریافت همه تفریح های فعال
        /// </summary>
        Task<List<FunDto>> GetAllActivedFun();

        /// <summary>
        /// دریافت همه تفریح های غیر فعال
        /// </summary>
        Task<List<FunDto>> GetAllDisActivedFun();
    }
}
