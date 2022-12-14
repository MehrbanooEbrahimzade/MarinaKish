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
        private readonly IFunRepository _funRepository;

        public FileService(IFileRepository fileRepository, IFunRepository funRepository)
        {
            _fileRepository = fileRepository;
            _funRepository = funRepository;
        }

        /// <summary>
        /// اپلود کردن عکس
        /// </summary>
        public async Task<Guid?> UploadFileAsync(IFormFile file)
        {
            var fileName = NameGenerator(file.FileName, out var format);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", fileName);
            var size = file.Length;

            if (format != "png" && format != "jpg" && format != "mp4")
                throw new FormatException("فرمت های معتبر:png/jpg/mp4 خطا\n!");

            switch (format)
            {
                case "png":
                case "jpg" when size > 15000000:
                    throw new InvalidDataException(" حجم عکس شماباید کمتر از15مگابیت باشد!");
                case "mp4" when size > 500000000:
                    throw new InvalidDataException(" حجم فیلم شماباید کمتر از500 مگابایت باشد!");
            }


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
                //Bytes = await File.ReadAllBytesAsync(myFile.FilePath),
                Type = FileFormat.GetMimeType(myFile.Name.Split('.').Last()),
                Url = "http://194.36.174.133/" + myFile.Name
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


        /// <summary>
        /// گرفتن همه عکس ها برای یک تفریح 
        /// </summary>
        //public async Task<byte[]> GetAllPicForFun(Guid funid)
        //{

        //    var myFile = await _fileRepository.GetFileByIdAsync(id);

        //    if (myFile == null)
        //        return null;

        //    byte[] bytes = File.ReadAllBytes(myFile.FilePath);

        //    return bytes;

        //var pics = await _fileRepository.GetAllPicForFun(funid.ToString());
        //if (pics == null)
        //    return null;

        //List<string> PicsResult = new List<string>();
        //foreach (var pic in pics)
        //{
        //    PicsResult.Add(pic.Id.ToString());
        //}

        //return PicsResult;
        //}

        /// <summary>
        /// گرفتن عکس با اسم عکس
        /// </summary>
        //public async Task<FilesDto> GetImageByName(Guid fileId)
        //{
        //    var file = await _fileRepository.GetFileById(fileId);
        //    return file.ToDto();
        //}



        //        /// <summary>
        //        /// اضافه کردن عکس پروفایل کاربر
        //        /// </summary>
        //        public async Task<List<string>> AddUserProfilePicture(AddFileToUserCommand command)
        //        {
        //            var file = await _fileRepository.GetFileById(command.FileID);
        //            var anyUser = await _fileRepository.AnyUser(command.UserID);
        //            if (!anyUser || file == null)
        //                return null;

        //            file.UserID = command.UserID.ToString();
        //            await _fileRepository.SaveChanges();

        //            List<string> UserPicsList = new List<string>();
        //            var userPics = await _fileRepository.GetAllPicForUser(command.UserID.ToString());

        //            foreach (var pic in userPics)
        //            {
        //                UserPicsList.Add(pic.Id.ToString());
        //            }

        //            return UserPicsList;

        //        }

        //        /// <summary>
        //        /// اضافه کردن عکس پروفایل تفریح
        //        /// </summary>
        //        public async Task<List<string>> AddFunProfilePicture(AddFileToFunCommand command)
        //        {
        //            var file = await _fileRepository.GetFileById(command.FileId);
        //            var anyFun = await _fileRepository.AnyFun(command.FunId);
        //            if (!anyFun || file == null)
        //                return null;

        //            file.FunID = command.FunId.ToString();
        //            await _fileRepository.SaveChanges();

        //            List<string> FunPicsList = new List<string>();
        //            var funPics = await _fileRepository.GetAllPicForFun(command.FunId.ToString());

        //            foreach (var pic in funPics)
        //            {
        //                FunPicsList.Add(pic.Id.ToString());
        //            }
        //            return FunPicsList;
        //        }

        //        /// <summary>
        //        /// اضافه کردن عکس پروفایل سانس
        //        /// </summary>
        //        public async Task<List<string>> AddScheduleProfilePicture(AddFileToScheduleCommand command)
        //        {
        //            var file = await _fileRepository.GetFileById(command.FileID);
        //            var anySchedule = await _fileRepository.AnySchedule(command.ScheduleID);
        //            if (!anySchedule || file == null)
        //                return null;

        //            file.ScheduleID = command.ScheduleID.ToString();
        //            await _fileRepository.SaveChanges();

        //            List<string> SchedulePicsList = new List<string>();
        //            var schedulePics = await _fileRepository.GetAllPicForSchedule(command.ScheduleID.ToString());

        //            foreach (var pic in schedulePics)
        //            {
        //                SchedulePicsList.Add(pic.Id.ToString());
        //            }
        //            return SchedulePicsList;
        //        }


        //        /// <summary>
        //        /// گرفتن همه عکس ها برای یک کاربر
        //        /// </summary>
        //        public async Task<List<string>> GetAllPicForUser(Guid userid)
        //        {
        //            var pics = await _fileRepository.GetAllPicForUser(userid.ToString());
        //            if (pics == null)
        //                return null;

        //            List<string> PicsResult = new List<string>();
        //            foreach (var pic in pics)
        //            {
        //                PicsResult.Add(pic.Id.ToString());
        //            }

        //            return PicsResult;
        //        }

        //        /// <summary>
        //        /// گرفتن همه عکس ها برای یک سانس
        //        /// </summary>
        //        public async Task<List<string>> GetAllPicForSchedule(Guid scheduleid)
        //        {
        //            var pics = await _fileRepository.GetAllPicForSchedule(scheduleid.ToString());
        //            if (pics == null)
        //                return null;

        //            List<string> PicsResult = new List<string>();
        //            foreach (var pic in pics)
        //            {
        //                PicsResult.Add(pic.Id.ToString());
        //            }

        //            return PicsResult;
        //        }

        //        /// <summary>
        //        /// غیرفعال کردن عکس
        //        /// </summary>
        //        public async Task<bool> DisActivePicById(Guid id)
        //        {
        //            var pic = await _fileRepository.GetFileById(id);
        //            if (pic == null)
        //                return false;
        //            pic.IsActive = false;
        //            return await _fileRepository.SaveChanges();
        //        }

        //        /// <summary>
        //        /// دوباره فعال کردن عکس
        //        /// </summary>
        //        public async Task<bool> ReActivePicById(Guid id)
        //        {
        //            var pic = await _fileRepository.getNotActiveFileById(id);
        //            if (pic == null)
        //                return false;
        //            pic.IsActive = true;
        //            return await _fileRepository.SaveChanges();
        //        }

        #region Private_Methods
        private string NameGenerator(string filename, out string format)
        {
            var fileArray = filename.Split(".").ToList();
            var constName = $"{fileArray[0]}MR";
            var randomNumber = new Random().Next(100, 100000).ToString();
            format = fileArray.Last();

            return constName + randomNumber + "." + format;
        }
        #endregion
    }
}