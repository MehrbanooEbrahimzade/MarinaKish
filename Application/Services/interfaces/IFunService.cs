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
        Task<Guid> AddFunAsync(AddFunCommand command);

        /// <summary>
        /// ویرایش تفریح
        /// </summary>
        Task UpdateFunAsync(UpdateFunCommand command);

        /// <summary>
        /// دریافت همه تفریح ها
        /// </summary>
        Task<List<FunDto>> GetAllFunAsync();

        /// <summary>
        /// غیرفعال کردن تفریح
        /// </summary>
        Task<bool> InactivateFunAsync(Guid id);

        /// <summary>
        /// گرفتن یک تفریح
        /// </summary>
        Task<FunDto> GetOneFunAsync(Guid id);

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

        Task<string> DateTimeNow(); 
    }
}
