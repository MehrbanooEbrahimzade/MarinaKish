using System.Threading.Tasks;
using System.IO;
using System;
using System.Collections.Generic;
using Application.Commands.Files;
using Application.Commands.Fun;
using Application.Dtos;
using Application.Mappers;
using Application.Services.interfaces;
using Domain.Models;
using Infrastructure.Repository.interfaces;
using Microsoft.AspNetCore.Http;
using File = Domain.Models.File;

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
            var fileName = NameGenerator(file.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", fileName);
            var size = file.Length.ToString();

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            List<string> fileProperties = new List<string>();
            fileProperties.Add(fileName);
            fileProperties.Add(filePath);
            fileProperties.Add(size);

            var fileObj = fileProperties.ToModel();

            var addedFileResult = await _fileRepository.UploadFileAsync(fileObj);

            if (addedFileResult)
                return fileObj.Id;
            return null;
        }

        /// <summary>
        /// دریافت عکس با آی دی
        /// </summary>
        public async Task<File> GetFileById(Guid id)
        {
            var file = await _fileRepository.GetFileById(id);
            if (file == null)
                return null;
            return file;
        }

        /// <summary>
        /// دانلود عکس
        /// </summary>
        public async Task DownloadFile(FileStream stream, MemoryStream memory)
        {
            await _fileRepository.DownloadFile(stream, memory);
        }

        /// <summary>
        /// گرفتن عکس با اسم عکس
        /// </summary>
        public async Task<FilesDto> GetImageByName(string fileName)
        {
            var file = await _fileRepository.GetImageByName(fileName);
            return file.ToDto();
        }

        /// <summary>
        /// پاک کردن فایل
        /// </summary>
        public async Task<bool> DeleteFileAsync(Guid id)
        {
            var file = await _fileRepository.GetFileById(id);
            if (file == null)
                return false;
            return await _fileRepository.DeleteFileAsync(file);
        }

        /// <summary>
        /// اضافه کردن عکس پروفایل کاربر
        /// </summary>
        public async Task<List<string>> AddUserProfilePicture(AddFileToUserCommand command)
        {
            var file = await _fileRepository.GetFileById(command.FileID);
            var anyUser = await _fileRepository.AnyUser(command.UserID);
            if (!anyUser || file == null)
                return null;

            file.UserID = command.UserID.ToString();
            await _fileRepository.UpdateFileAsync();

            List<string> UserPicsList = new List<string>();
            var userPics = await _fileRepository.GetAllPicForUser(command.UserID.ToString());

            foreach (var pic in userPics)
            {
                UserPicsList.Add(pic.Id.ToString());
            }

            return UserPicsList;

        }

        /// <summary>
        /// اضافه کردن عکس پروفایل تفریح
        /// </summary>
        public async Task<List<string>> AddFunProfilePicture(AddFileToFunCommand command)
        {
            var file = await _fileRepository.GetFileById(command.FileId);
            var anyFun = await _fileRepository.AnyFun(command.FunId);
            if (!anyFun || file == null)
                return null;

            file.FunID = command.FunId.ToString();
            await _fileRepository.UpdateFileAsync();

            List<string> FunPicsList = new List<string>();
            var funPics = await _fileRepository.GetAllPicForFun(command.FunId.ToString());

            foreach (var pic in funPics)
            {
                FunPicsList.Add(pic.Id.ToString());
            }
            return FunPicsList;
        }

        /// <summary>
        /// اضافه کردن عکس پروفایل سانس
        /// </summary>
        public async Task<List<string>> AddScheduleProfilePicture(AddFileToScheduleCommand command)
        {
            var file = await _fileRepository.GetFileById(command.FileID);
            var anySchedule = await _fileRepository.AnySchedule(command.ScheduleID);
            if (!anySchedule || file == null)
                return null;

            file.ScheduleID = command.ScheduleID.ToString();
            await _fileRepository.UpdateFileAsync();

            List<string> SchedulePicsList = new List<string>();
            var schedulePics = await _fileRepository.GetAllPicForSchedule(command.ScheduleID.ToString());

            foreach (var pic in schedulePics)
            {
                SchedulePicsList.Add(pic.Id.ToString());
            }
            return SchedulePicsList;
        }

        /// <summary>
        /// گرفتن همه عکس ها برای یک تفریح 
        /// </summary>
        public async Task<List<string>> GetAllPicForFun(Guid funid)
        {
            var pics = await _fileRepository.GetAllPicForFun(funid.ToString());
            if (pics == null)
                return null;

            List<string> PicsResult = new List<string>();
            foreach (var pic in pics)
            {
                PicsResult.Add(pic.Id.ToString());
            }

            return PicsResult;
        }

        /// <summary>
        /// گرفتن همه عکس ها برای یک کاربر
        /// </summary>
        public async Task<List<string>> GetAllPicForUser(Guid userid)
        {
            var pics = await _fileRepository.GetAllPicForUser(userid.ToString());
            if (pics == null)
                return null;

            List<string> PicsResult = new List<string>();
            foreach (var pic in pics)
            {
                PicsResult.Add(pic.Id.ToString());
            }

            return PicsResult;
        }

        /// <summary>
        /// گرفتن همه عکس ها برای یک سانس
        /// </summary>
        public async Task<List<string>> GetAllPicForSchedule(Guid scheduleid)
        {
            var pics = await _fileRepository.GetAllPicForSchedule(scheduleid.ToString());
            if (pics == null)
                return null;

            List<string> PicsResult = new List<string>();
            foreach (var pic in pics)
            {
                PicsResult.Add(pic.Id.ToString());
            }

            return PicsResult;
        }

        /// <summary>
        /// غیرفعال کردن عکس
        /// </summary>
        public async Task<bool> DisActivePicById(Guid id)
        {
            var pic = await _fileRepository.GetFileById(id);
            if (pic == null)
                return false;
            pic.IsActive = false;
            return await _fileRepository.UpdateFileAsync();
        }

        /// <summary>
        /// دوباره فعال کردن عکس
        /// </summary>
        public async Task<bool> ReActivePicById(Guid id)
        {
            var pic = await _fileRepository.getNotActiveFileById(id);
            if (pic == null)
                return false;
            pic.IsActive = true;
            return await _fileRepository.UpdateFileAsync();
        }

        #region Private_Methods
        private string NameGenerator(string filename)
        {

            var fileArray = filename.Split(".");
            var constName = $"{fileArray[0]}MR";
            var randomNumber = new Random().Next(100, 100000).ToString();

            return constName + randomNumber + "." + fileArray[1];
        }

        #endregion
    }
}
