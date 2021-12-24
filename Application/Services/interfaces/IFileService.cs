using System;
using System.IO;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Services.classes;
using Domain.Models;
using Microsoft.AspNetCore.Http;

namespace Application.Services.interfaces
{
    public interface IFileService
    {
        /// <summary>
        /// اپلود کردن عکس
        /// </summary>
        Task<Guid?> UploadFileAsync(IFormFile file);

        /// <summary>
        /// دریافت عکس با آی دی
        /// </summary>
        Task<MyFile> GetFileById(Guid id);

        /// <summary>
        /// دانلود عکس
        /// </summary>
        Task<MyFileDto> DownloadFile(Guid id);

        ///// <summary>
        ///// گرفتن عکس با اسم عکس
        ///// </summary>
        //Task<FilesDto> GetImageByName(string fileName);

        /// <summary>
        /// پاک کردن فایل
        /// </summary>
        Task<bool> DeleteFileAsync(Guid id);

        ///// <summary>
        ///// اضافه کردن عکس پروفایل کاربر
        ///// </summary>
        //Task<List<string>> AddUserProfilePicture(AddFileToUserCommand command);

        ///// <summary>
        ///// اضافه کردن عکس پروفایل تفریح
        ///// </summary>
        //Task<List<string>> AddFunProfilePicture(AddFileToFunCommand command);

        ///// <summary>
        ///// اضافه کردن عکس پروفایل سانس
        ///// </summary>
        //Task<List<string>> AddScheduleProfilePicture(AddFileToScheduleCommand command);

        ///// <summary>
        ///// گرفتن همه عکس ها برای یک تفریح 
        ///// </summary>
        //Task<List<string>> GetAllPicForFun(Guid funid);

        ///// <summary>
        ///// گرفتن همه عکس ها برای یک کاربر
        ///// </summary>
        //Task<List<string>> GetAllPicForUser(Guid userid);

        ///// <summary>
        ///// گرفتن همه عکس ها برای یک سانس
        ///// </summary>
        //Task<List<string>> GetAllPicForSchedule(Guid scheduleid);

    }
}
