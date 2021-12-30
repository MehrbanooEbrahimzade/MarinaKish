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
        Guid AddFunAsync(AddFunCommand command);

        /// <summary>
        /// ویرایش تفریح
        /// </summary>
        Task UpdateFunAsync(UpdateFunCommand command);

        /// <summary>
        /// حذف تفریح
        /// </summary>
        Task DeleteFunAsync(Guid id);
        /// <summary>
        /// دریافت همه تفریح ها
        /// </summary>
        Task<List<FunDto>> GetAllFunAsync();

        /// <summary>
        /// گرفتن یک تفریح
        /// </summary>
        Task<FunDto> GetOneFunAsync(Guid id);

        /// <summary>
        /// گرفتن تفریح ها با اسم تفریح
        /// </summary>
        Task<List<FunDto>> GetFunsWithFunNameAsynch(string name);


        /// <summary>
        /// غیرفعال کردن یک تفریح
        /// </summary>
        Task<bool> DisActiveFunByIdAsynch(Guid id);

        /// <summary>
        /// دوباره فعال کردن یک تفریح
        /// </summary>
        Task<bool> ReActiveFunByIdAsynch(Guid id);

        /// <summary>
        /// دریافت همه تفریح های فعال
        /// </summary>
        Task<List<FunDto>> GetAllActivedFunAsynch();

        /// <summary>
        /// دریافت همه تفریح های غیر فعال
        /// </summary>
        Task<List<FunDto>> GetAllDisActivedFunAsynch();
    }
}
