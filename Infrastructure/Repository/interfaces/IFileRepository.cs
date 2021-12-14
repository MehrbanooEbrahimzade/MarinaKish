﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Domain.Models;
using File = Domain.Models.File;

namespace Infrastructure.Repository.interfaces
{
    public interface IFileRepository
    {
        /// <summary>
        /// اپلود کردن عکس
        /// </summary>
        Task<bool> UploadFileAsync(File pic);

        /// <summary>
        /// دریافت عکس با آی دی
        /// </summary>
        Task<Domain.Models.File> GetFileById(Guid id);

        /// <summary>
        /// دانلود عکس
        /// </summary>
        Task DownloadFile(FileStream stream, MemoryStream memory);

        /// <summary>
        /// گرفتن عکس با اسم عکس
        /// </summary>
        Task<File> GetImageByName(string fileName);

        /// <summary>
        /// پاک کردن فایل
        /// </summary>
        Task<bool> DeleteFileAsync(File pic);

        /// <summary>
        /// وجود داشتن کاربر
        /// </summary>
        Task<bool> AnyUser(Guid id);

        /// <summary>
        /// وجود داشتن تفریح
        /// </summary>
        Task<bool> AnyFun(Guid id);

        /// <summary>
        /// وجود داشتن سانس
        /// </summary>
        Task<bool> AnySchedule(Guid id);

        /// <summary>
        /// دریافت کاربر
        /// </summary>
        Task<User> GetUserById(Guid id);

        /// <summary>
        /// دریافت تفریح
        /// </summary>
        Task<Fun> GetFunById(Guid id);

        /// <summary>
        /// دریافت سانس
        /// </summary>
        Task<Schedule> GetScheduleById(Guid id);

        /// <summary>
        /// گرفتن همه عکس ها برای یک تفریح 
        /// </summary>
        Task<List<File>> GetAllPicForFun(string funid);

        /// <summary>
        /// گرفتن همه عکس ها برای یک کاربر
        /// </summary>
        Task<List<File>> GetAllPicForUser(string userid);

        /// <summary>
        /// گرفتن همه عکس ها برای یک سانس
        /// </summary>
        Task<List<File>> GetAllPicForSchedule(string scheduleid);

        /// <summary>
        /// گرفتن عکس غیرفعال با آیدی
        /// </summary>
        Task<File> getNotActiveFileById(Guid id);

        /// <summary>
        /// ذخیره اعمال انجام شده
        /// </summary>
        Task<bool> UpdateFileAsync();
    }
}
