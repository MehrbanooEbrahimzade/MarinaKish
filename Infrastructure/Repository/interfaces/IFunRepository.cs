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
        Task<bool> CheckFunTypeIsExistAsynch(Guid id);

        /// <summary>
        /// اضافه کردن تفریح به تِیبل 
        /// </summary>
         void AddFunAsync(Fun fun);

        /// <summary>
        /// گرفتن تفریح با آیدی :
        /// </summary>
        Task<Fun> GetFunByIdAsynch(Guid id);

        /// <summary>
        /// گرفتن تفریح فعال با آیدی :
        /// </summary>
        Task<Fun> GetActiveFunByIdAsynch(Guid id);

        /// <summary>
        /// گرفتن تفریح غیرفعال با آیدی :
        /// </summary>
        Task<Fun> GetDisActiveFunByIdAsynch(Guid id);

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
        Task<Fun> GetFunByFunNameAsynch(string name);

        /// <summary>
        /// دریافت همه تفریح های فعال
        /// </summary>
        Task<List<Fun>> GetAllActivedFunAsynh();
        ///// <summary>
        ///// دریافت فایل با آیدی
        ///// </summary>
        //Task<MyFile> GetFileById(Guid fileid);

        /// <summary>
        /// دریافت همه تفریح های غیر فعال
        /// </summary>
        Task<List<Fun>> GetAllDisActivedFunAsynch();

        /// <summary>
        ///  دریافت تفریح فعال با اسم
        /// </summary>
        Task<Fun> GetActiveFunWithFunNameAsynch(string name);

        /// <summary>
        /// دریافت تفریح های فعال با آیدی
        /// </summary>
        Task<List<Fun>> GetAllFunActiveSchedulesById(Guid funId);

        /// <summary>
        /// دریافت همه سانس های برگذار نشده غیرفعال یک تفریح با آیدی
        /// </summary>
        Task<List<Fun>> GetAllFunDisActiveSchedulesById(Guid funId);
    }
}
