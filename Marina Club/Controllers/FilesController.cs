using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.StaticFiles;
using Application.Commands.Files;
using Application.Commands.Fun;
using Application.Services.interfaces;

namespace Marina_Club.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ApiController
    {
        private readonly IFileService _fileService;
        public FilesController(IFileService fileService)
        {
            _fileService = fileService;
        }

        /// <summary>
        /// اپلود کردن فایل
        /// </summary>
        [HttpPost("Upload")]
        public async Task<IActionResult> UploadFileAsync(IFormFile file)
        {
            var result = await _fileService.UploadFileAsync(file);

            return result == null ? BadReq(ApiMessage.PicNotAdd) : OkResult
                (ApiMessage.OkFileAdd, new { Id = $"{result}" });
        }

        /// <summary>
        /// دانلود فایل
        /// </summary>
        [HttpGet("Download/{id}")]
        public async Task<IActionResult> DownloadFileAsync(Guid id)
        {
            var myFile = await _fileService.GetFileById(id);

            return myFile==null ? BadReq(ApiMessage.PicNotExist)
                : File(memory, GetContentType(myFile.FilePath), myFile.Name);
        }

        //[HttpGet("MusicDownload/{id}")]

        /// <summary>
        /// غیرفعال کردن عکس
        /// </summary>
        [HttpPut("DisActive/{id}")]
        public async Task<IActionResult> DisActivePicById(Guid id)
        {
            var result = await _fileService.DisActivePicById(id);
            if (!result)
                return BadReq(ApiMessage.PicNotExist);
            return OkResult(ApiMessage.FileDisActived, new { IsDisActived = result });
        }

        /// <summary>
        /// دوباره فعال کردن عکس
        /// </summary>
        [HttpPut("ReActive/{id}")]
        public async Task<IActionResult> ReActivePicById(Guid id)
        {
            var result = await _fileService.ReActivePicById(id);
            if (!result)
                return BadReq(ApiMessage.PicNotExist);
            return OkResult(ApiMessage.FileReActived, new { IsReActived = result });
        }


        /// <summary>
        /// پاک کردن فایل
        /// </summary>
        [HttpDelete("{id}/Delete")]
        public async Task<IActionResult> DeleteFileAsync(Guid id)
        {
            var result = await _fileService.DeleteFileAsync(id);
            if (!result)
                return BadReq(ApiMessage.PicNotExist);
            return OkResult(ApiMessage.FileDeleted, new { IsFileDeleted = result });
        }

        #region UsersOptions
        /// <summary>
        /// اضافه کردن عکس پروفایل کاربر
        /// </summary>
        [HttpPut("AddUserProfile/{id}")]
        public async Task<IActionResult> AddUserProfilePicture(Guid id, AddFileToUserCommand command)
        {
            command.FileID = id;
            if (!command.Validate())
                return BadReq(ApiMessage.WrongUserIDOrFileID, new { Reason = $"1-enter fileID pls, 2-enter userID pls" });

            var result = await _fileService.AddUserProfilePicture(command);
            if (result == null)
                return BadReq(ApiMessage.UserProfileNotAdded, new { Reason = $"1-user with this id not found, 2-file with this id not found" });
            return OkResult(ApiMessage.UserProfileAdded, new { UserPictures = result });
        }

        /// <summary>
        /// گرفتن همه عکس ها برای یک کاربر
        /// </summary>
        [HttpGet("AllPicForUser/{id}")] //userID ( users model )
        public async Task<IActionResult> GetAllPicForUser(Guid id)
        {
            var result = await _fileService.GetAllPicForUser(id);
            if (result == null)
                return BadReq(ApiMessage.UserNotHavePic, new { Reason = $"1-user with this id not found, 2-user with this id not have profile picture" });
            return OkResult(ApiMessage.GetAllUserProfiles, new { UserPictures = result });
        }

        /// <summary>
        /// گرفتن همه عکس ها برای یک کاربر
        /// </summary>
        [HttpGet("AllPicForUser-Count/{id}")] //userID ( users model )
        public async Task<IActionResult> GetAllPicForUserCount(Guid id)
        {
            var result = await _fileService.GetAllPicForUser(id);
            if (result == null)
                return BadReq(ApiMessage.UserNotHavePic, new { Reason = $"1-user with this id not found, 2-user with this id not have profile picture" });
            return OkResult(ApiMessage.GetAllUserProfiles, new { UserPicturesCount = result.Count });
        }
        #endregion

        #region FunOptions
        /// <summary>
        /// اضافه کردن عکس پروفایل تفریح
        /// </summary>
        [HttpPut("AddFunProfile/{id}")]
        public async Task<IActionResult> AddFunProfilePicture(Guid id, AddFileToFunCommand command)
        {
            command.FileId = id;
            if (!command.Validate())
                return BadReq(ApiMessage.WrongFunIDOrFileID, new { Reason = $"1-enter fun id, 2-enter file id" });

            var result = await _fileService.AddFunProfilePicture(command);
            if (result == null)
                return BadReq(ApiMessage.FunProfileNotAdded, new { Reason = $"1-fun with this id not found, 2-file with this id not found" });
            return OkResult(ApiMessage.FunProfileAdded, new { FunPictures = result });
        }

        /// <summary>
        /// گرفتن همه عکس ها برای یک تفریح 
        /// </summary>
        [HttpGet("AllPicForFun/{id}")] // funID ( funs model )
        public async Task<IActionResult> GetAllPicForFun(Guid id)
        {
            var result = await _fileService.GetAllPicForFun(id);
            if (result == null)
                return BadReq(ApiMessage.FunNotHavePic, new { Reason = $"1-Fun with this id not found, 2-Fun with this id not have profile picture" });
            return OkResult(ApiMessage.GetAllFunProfiles, new { FunPictures = result });
        }

        /// <summary>
        /// گرفتن تعداد همه عکس ها برای یک تفریح 
        /// </summary>
        [HttpGet("AllPicForFun-Count/{id}")] // funID ( funs model )
        public async Task<IActionResult> GetAllPicForFunCount(Guid id)
        {
            var result = await _fileService.GetAllPicForFun(id);
            if (result == null)
                return BadReq(ApiMessage.FunNotHavePic, new { Reason = $"1-Fun with this id not found, 2-Fun with this id not have profile picture" });
            return OkResult(ApiMessage.GetAllFunProfiles, new { FunPicturesCount = result.Count });
        }
        #endregion

        #region SchedulesOptions
        /// <summary>
        /// اضافه کردن عکس پروفایل سانس
        /// </summary>
        [HttpPut("AddScheduleProfile/{id}")]
        public async Task<IActionResult> AddScheduleProfilePicture(Guid id, AddFileToScheduleCommand command)
        {
            command.FileID = id;
            if (!command.Validate())
                return BadReq(ApiMessage.WrongScheduleIDOrFileID, new { Reason = $"1-enter file id, 2-enter schedule id" });

            var result = await _fileService.AddScheduleProfilePicture(command);
            if (result == null)
                return BadReq(ApiMessage.ScheduleProfileNotAdded, new { Reason = $"1-schedule with this id not found, 2-file with this id not found" });
            return OkResult(ApiMessage.ScheduleProfileAdded, new { SchedulePictures = result });
        }

        /// <summary>
        /// گرفتن همه عکس ها برای یک سانس
        /// </summary>
        [HttpGet("AllPicForSchedule/{id}")] //scheduleID
        public async Task<IActionResult> GetAllPicForSchedule(Guid id)
        {
            var result = await _fileService.GetAllPicForSchedule(id);
            if (result == null)
                return BadReq(ApiMessage.ScheduleNotHavePic, new { Reason = $"1-schedule with this id not found, 2-schedule with this id not have profile" });
            return OkResult(ApiMessage.GetAllScheduleProfiles, new { SchedulePictures = result });
        }

        #endregion

        #region private_methods
        [NonAction]
        private string GetContentType(string path)
        {
            var provider = new FileExtensionContentTypeProvider();

            if (!provider.TryGetContentType(path, out var contentType))
            {
                contentType = "application/octet-stream";
            }
            return contentType;

        }
        #endregion
    }
}
