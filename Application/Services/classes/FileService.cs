using System.Threading.Tasks;
using System.IO;
using System;
using System.Linq;
using Application.Services.interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Infrastructure.Helper;
using Application.Dtos;
using Domain.RepasitoryInterfaces;
using static Application.Services.classes.ApiControllers;

namespace Application.Services.classes
{
    public class FileService : IFileService
    {
        private readonly IFileRepository _fileRepository;

        public FileService(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        /// <summary>
        /// اپلود کردن عکس
        /// </summary>
        public async Task<Guid?> UploadFileAsync(IFormFile file)
        {
            string format;
            var fileName = NameGenerator(file.FileName, out format);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", fileName);
            var size = file.Length;
            switch (format)
            {
                case null:
                    throw new ArgumentNullException("خطا");
                case "png":
                case "jpg" when size>15000000:
                    throw new InvalidDataException(" حجم عکس شماباید کمتر از15مگابیت باشد!");
                case "mp4" when size > 1500000000:
                    throw new InvalidDataException(" حجم فیلم شماباید کمتر از1.5 گیگابایت باشد!");
            }

            if (format != "png" && format != "jpg" && format != "mp4")
                throw new FormatException("فرمت های معتبر:png/jpg/mp4 این فرمت پشتیبانی نمیشود!");
            
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var newFile = new MyFile(fileName, filePath, size);

            await _fileRepository.UploadFileAsync(newFile);
            await _fileRepository.SaveChanges();
            return newFile.Id;
        }

        /// <summary>
        /// دانلود عکس
        /// </summary>
        public async Task<MyFileDto> DownloadFile(Guid id)
        {
            var myFile = await _fileRepository.GetFileByIdAsync(id);

            if (myFile == null)
                 throw new ArgumentNullException(ApiMessage.nullFile);

            var myFileDto = new MyFileDto
            {
                Bytes = await File.ReadAllBytesAsync(myFile.FilePath),
                Type = FileFormat.GetMimeType(myFile.Name.Split('.').Last())
            };

            return myFileDto;
        }


        
        /// <summary>
        /// پاک کردن فایل
        /// </summary>
        public async Task<bool> DeleteFileAsync(Guid id)
        {
            var file = await _fileRepository.GetFileByIdAsync(id);
            if (file == null)
            {
                throw new ArgumentNullException(ApiMessage.nullFile);
            }

            await _fileRepository.DeleteFileAsync(file);

            File.Delete(file.FilePath);

            return await _fileRepository.SaveChanges();
        }


        #region Private_Methods
        private string NameGenerator(string filename, out string format)
        {
            var fileArray = filename.Split(".").ToList();
            var constName = $"{fileArray[0]}MR";
            var randomNumber = new Random().Next(100, 100000).ToString();
            format =fileArray.Last();

            return constName + randomNumber + "." + format;
        }
        #endregion
    }
}