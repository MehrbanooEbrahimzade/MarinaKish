using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Domain.Models;

namespace Infrastructure.Repository.interfaces
{
    public interface IFileRepository
    {
        /// <summary>
        /// اپلود کردن عکس
        /// </summary>

        Task UploadFileAsync(Domain.Models.MyFile pic);

        /// <summary>
        /// دریافت عکس با آی دی
        /// </summary>
        Task<Domain.Models.MyFile> GetFileById(Guid id);

        /// <summary>
        /// دانلود عکس
        /// </summary>
        Task DownloadFile(FileStream stream, MemoryStream memory);

        ///// <summary>
        ///// گرفتن عکس با اسم عکس
        ///// </summary>
        //Task<Domain.Models.MyFile> GetImageByName(string fileName);

        /// <summary>
        /// پاک کردن فایل
        /// </summary>
        Task<bool> DeleteFileAsync(Domain.Models.MyFile pic);

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

        /// <summary>
        /// ذخیره اعمال انجام شده
        /// </summary>
        Task<bool> SaveChanges();
    }
}
