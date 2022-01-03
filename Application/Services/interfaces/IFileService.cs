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
        /// دانلود عکس
        /// </summary>
        Task<MyFileDto> DownloadFile(Guid id);

        /// <summary>
        /// پاک کردن فایل
        /// </summary>
        Task<bool> DeleteFileAsync(Guid id);
    }
}
