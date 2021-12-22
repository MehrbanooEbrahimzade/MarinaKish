using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Enums;
using Domain.Models;

namespace Infrastructure.Repository.interfaces
{
    public interface IFunRepository
    {
        /// <summary>
        /// بررسی وجود داشتن تفریح
        /// </summary>
        Task<bool> CheckFunTypeIsExist(string name);

        /// <summary>
        /// اضافه کردن تفریح به تِیبل 
        /// </summary>
        Task<bool> AddFunAsync(Fun fun);

        /// <summary>
        /// گرفتن تفریح با آیدی :
        /// </summary>
        Task<Fun> GetFunById(Guid id);

        /// <summary>
        /// گرفتن تفریح فعال با آیدی :
        /// </summary>
        Task<Fun> GetActiveFunById(Guid id);

        /// <summary>
        /// گرفتن تفریح غیرفعال با آیدی :
        /// </summary>
        Task<Fun> GetDisActiveFunById(Guid id);

        /// <summary>
        /// ذخیره کردن اعمال انجام شده
        /// </summary>
        Task<bool> UpdateFunAsync();

        /// <summary>
        /// حذف تفریح
        /// </summary>
        Task<bool> DeleteFunAsync(Guid id);

        /// <summary>
        /// گرفتن همه تفریح ها
        /// </summary>
        Task<List<Fun>> GetAllFunAsync();

        /// <summary>
        /// گرفتن تفریح با نوع تفریح
        /// </summary>
        Task<Fun> GetFunByFunType(string name);

        ///// <summary>
        ///// دریافت فایل با آیدی
        ///// </summary>
        //Task<File> GetFileById(Guid fileid);

        /// <summary>
        /// دریافت همه تفریح های فعال
        /// </summary>
        Task<List<Fun>> GetAllActivedFun();

        /// <summary>
        /// دریافت همه تفریح های غیر فعال
        /// </summary>
        Task<List<Fun>> GetAllDisActivedFun();

        ///// <summary>
        ///// دریافت همه سانس های برگذار نشده فعال یک تفریح با آیدی
        ///// </summary>
        //Task<List<Schedule>> GetAllFunActiveSchedulesById(Guid funid);

        ///// <summary>
        ///// دریافت همه سانس های برگذار نشده غیرفعال یک تفریح با آیدی
        ///// </summary>
        //Task<List<Schedule>> GetAllFunDisActiveSchedulesById(Guid funid);
    }
}
