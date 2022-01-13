using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.RepasitoryInterfaces
{
    public interface IFunRepository: IGenericRepository<Fun>
    {
        /// <summary>
        /// بررسی وجود داشتن تفریح
        /// </summary>
        Task<bool> CheckFunTypeIsExistAsync(Guid id);

        /// <summary>
        /// حذف عکسهای اسلایدی یک فان
        /// </summary>
        Task DeleteSliderPicturesByFunAsync(Fun fun);

        /// <summary>
        /// گرفتن تفریح فعال با آیدی :
        /// </summary>
        Task<Fun> GetActiveFunByIdAsynch(Guid id);

        /// <summary>
        /// غیرفعال کردن یک فان
        /// </summary>
        Task<bool> InactivateFun(Guid fileId);

        /// <summary>
        /// گرفتن تفریح غیرفعال با آیدی :
        /// </summary>
        Task<Fun> GetDisActiveFunByIdAsynch(Guid id);

        /// <summary>
        ///گرفتن تفریح  با اسم تفریح
        /// </summary>
        Task<Fun> GetFunsByFunNameAsync(string name);

        /// <summary>
        /// دریافت همه تفریح های فعال
        /// </summary>
        Task<List<Fun>> GetAllActiveFunAsync();
       
        ///// <summary>
        ///// دریافت فایل با آیدی
        ///// </summary>
        //Task<MyFile> GetFileById(Guid fileid);

        /// <summary>
        /// دریافت همه تفریح های غیر فعال
        /// </summary>
        Task<List<Fun>> GetAllDisActiveFunAsync();

        /// <summary>
        ///  دریافت تفریح فعال با اسم
        /// </summary>
        Task<Fun> GetActiveFunWithFunNameAsync(string name);

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
