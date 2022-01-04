using System;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.RepasitoryInterfaces
{
    public interface IFileRepository: IGenericRepository<MyFile>
    {
        /// <summary>
        /// اپلود کردن عکس
        /// </summary>
        Task UploadFileAsync(MyFile pic);

        /// <summary>
        /// دریافت عکس با آی دی
        /// </summary>
        Task<MyFile> GetFileByIdAsync(Guid id);

        /// <summary>
        /// پاک کردن فایل
        /// </summary>
        Task DeleteFileAsync(MyFile pic);

        /// <summary>
        /// ذخیره اعمال انجام شده
        /// </summary>
        Task<bool> SaveChanges();


        ///// <summary>
        ///// دانلود عکس
        ///// </summary>
        //Task DownloadFile(FileStream stream, MemoryStream memory);

        ///// <summary>
        ///// گرفتن عکس با اسم عکس
        ///// </summary>
        //Task<Domain.Models.MyFile> GetImageByName(string fileName);


        //        /// <summary>
        //        /// دریافت تفریح
        //        /// </summary>
        //        Task<Fun> GetFunByIdAsynch(Guid id);
        ///// <summary>
        ///// گرفتن همه عکس ها برای یک تفریح 
        ///// </summary>
        //Task<List<Domain.Models.MyFile>> GetAllPicForFun(string funId);

        ///// <summary>
        ///// گرفتن همه عکس ها برای یک کاربر
        ///// </summary>
        //Task<List<Domain.Models.MyFile>> GetAllPicForUser(string userId);

        ///// <summary>
        ///// گرفتن همه عکس ها برای یک سانس
        ///// </summary>
        //Task<List<Domain.Models.MyFile>> GetAllPicForSchedule(string scheduleid);

        ///// <summary>
        ///// گرفتن عکس غیرفعال با آیدی
        ///// </summary>
        //Task<Domain.Models.MyFile> getNotActiveFileById(Guid id);


    }
}
