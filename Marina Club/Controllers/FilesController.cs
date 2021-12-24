using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Application.Services.interfaces;
using System.Net.Mime;

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
        /// (عکس و فیلم)
        /// </summary>
        [HttpPost("Upload")]
        public async Task<IActionResult> UploadFileAsync(IFormFile file)
        {
            var result = await _fileService.UploadFileAsync(file);

            if (result == null)
                return BadReq(ApiMessage.PicNotAdd);

            return OkResult(ApiMessage.OkFileAdd, result);
        }

        /// <summary>
        /// دانلود کردن عکس
        /// </summary>
        [HttpGet("Downloadpics/{id}")]
        public async Task<IActionResult> DownloadPicsAsync(Guid id)
        {
            var bytes = await _fileService.DownloadFile(id);

            if (bytes == null)
                throw new ArgumentNullException(ApiMessage.BadRequest);

            return File(bytes, MediaTypeNames.Image.Jpeg);
        }

        /// <summary>
        /// دانلود کردن فیلم
        /// </summary>
        [HttpGet("downloadMovie/{id}")]
        public async Task<IActionResult> DownloadMovie(Guid id)//?
        {
            var bytes = await _fileService.DownloadFile(id);

            return File(bytes, "video/mp4");
        }

        /// <summary>
        /// پاک کردن فایل
        /// </summary>
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteFileAsync(Guid id)
        {
            var result = await _fileService.DeleteFileAsync(id);

            if (!result)
                return BadReq(ApiMessage.BadRequest);

            return OkResult(ApiMessage.FileDeleted);

        }


        ///// <summary>
        ///// گرفتن اطلاعات فایل
        ///// </summary>
        //[HttpGet("Info/{id}")]
        //public async Task<MyFile> GetInfoAsync(Guid id)//?
        //{
        //    var myFile = await _fileService.GetFileById(id);

        //    if (myFile == null)
        //        throw new ArgumentNullException(ApiMessage.PicNotExist);

        //    return myFile;
        //}

        ///// <summary>
        ///// گرفتن همه عکس های اسلایدی یک فان
        ///// </summary>
        //[HttpGet("AllPic/{id}")]
        //public async Task<IActionResult> GetAllPic(Fun funId)
        //{

        //    var result = await _fileService.GetAllPicForUser(funId);
        //    if (result == null)
        //        return BadReq(ApiMessage.UserNotHavePic, new { Reason = $"1-user with this id not found, 2-user with this id not have profile picture" });
        //    return OkResult(ApiMessage.GetAllUserProfiles, new { UserPicturesCount = result.Count });
        //}



        ///// <summary>
        ///// گرفتن همه عکس ها برای یک تفریح 
        ///// </summary>
        //[HttpGet("AllPicForFun/{id}")] // funID ( funs model )
        //public async Task<IActionResult> GetAllPicForFun(Guid id)
        //{
        //    var result = await _fileService.GetAllPicForFun(id);
        //    if (result == null)
        //        return BadReq(ApiMessage.FunNotHavePic, new { Reason = $"1-Fun with this id not found, 2-Fun with this id not have profile picture" });
        //    return OkResult(ApiMessage.GetAllFunProfiles, new { FunPictures = result });
        //}


        //public async Task<HttpResponseMessage> GetFile(Guid id)
        //{
        //    //if (String.IsNullOrEmpty(id))
        //    //    return await Request.CreateResponse(HttpStatusCode.BadRequest);

        //    var myFile = await _fileService.GetFileById(id);

        //    string fileName = myFile.Name;
        //    string localFilePath = myFile.FilePath;
        //    long fileSize = myFile.Size;



        //    //localFilePath = getFileFromID(id, out fileName, out fileSize);

        //    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK)
        //    {
        //        Content = new StreamContent(new FileStream(localFilePath, FileMode.Open, FileAccess.Read))
        //    };

        //    response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
        //    {
        //        FileName = fileName
        //    };

        //    response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/jpg");

        //    return response;
        //}


        //#region UsersOptions
        ///// <summary>
        ///// اضافه کردن عکس پروفایل کاربر
        ///// </summary>
        //[HttpPut("AddUserProfile/{id}")]
        //public async Task<IActionResult> AddUserProfilePicture(Guid id, AddFileToUserCommand command)
        //{
        //    command.FileID = id;
        //    if (!command.Validate())
        //        return BadReq(ApiMessage.WrongUserIDOrFileID, new { Reason = $"1-enter fileID pls, 2-enter userID pls" });

        //    var result = await _fileService.AddUserProfilePicture(command);
        //    if (result == null)
        //        return BadReq(ApiMessage.UserProfileNotAdded, new { Reason = $"1-user with this id not found, 2-file with this id not found" });
        //    return OkResult(ApiMessage.UserProfileAdded, new { UserPictures = result });
        //}

        ///// <summary>
        ///// گرفتن همه عکس ها برای یک کاربر
        ///// </summary>
        //[HttpGet("AllPicForUser/{id}")] //userID ( users model )
        //public async Task<IActionResult> GetAllPicForUser(Guid id)
        //{
        //    var result = await _fileService.GetAllPicForUser(id);
        //    if (result == null)
        //        return BadReq(ApiMessage.UserNotHavePic, new { Reason = $"1-user with this id not found, 2-user with this id not have profile picture" });
        //    return OkResult(ApiMessage.GetAllUserProfiles, new { UserPictures = result });
        //}

        //#endregion

        //#region FunOptions
        ///// <summary>
        ///// اضافه کردن عکس پروفایل تفریح
        ///// </summary>
        //[HttpPut("AddFunProfile/{id}")]
        //public async Task<IActionResult> AddFunProfilePicture(Guid id, AddFileToFunCommand command)
        //{
        //    command.FileId = id;
        //    if (!command.Validate())
        //        return BadReq(ApiMessage.WrongFunIDOrFileID, new { Reason = $"1-enter eFun id, 2-enter file id" });

        //    var result = await _fileService.AddFunProfilePicture(command);
        //    if (result == null)
        //        return BadReq(ApiMessage.FunProfileNotAdded, new { Reason = $"1-eFun with this id not found, 2-file with this id not found" });
        //    return OkResult(ApiMessage.FunProfileAdded, new { FunPictures = result });
        //}

        ///// <summary>
        ///// گرفتن تعداد همه عکس ها برای یک تفریح 
        ///// </summary>
        //[HttpGet("AllPicForFun-Count/{id}")] // funID ( funs model )
        //public async Task<IActionResult> GetAllPicForFunCount(Guid id)
        //{
        //    var result = await _fileService.GetAllPicForFun(id);
        //    if (result == null)
        //        return BadReq(ApiMessage.FunNotHavePic, new { Reason = $"1-Fun with this id not found, 2-Fun with this id not have profile picture" });
        //    return OkResult(ApiMessage.GetAllFunProfiles, new { FunPicturesCount = result.Count });
        //}
        //#endregion

        //#region SchedulesOptions
        ///// <summary>
        ///// اضافه کردن عکس پروفایل سانس
        ///// </summary>
        //[HttpPut("AddScheduleProfile/{id}")]
        //public async Task<IActionResult> AddScheduleProfilePicture(Guid id, AddFileToScheduleCommand command)
        //{
        //    command.FileID = id;
        //    if (!command.Validate())
        //        return BadReq(ApiMessage.WrongScheduleIDOrFileID, new { Reason = $"1-enter file id, 2-enter schedule id" });

        //    var result = await _fileService.AddScheduleProfilePicture(command);
        //    if (result == null)
        //        return BadReq(ApiMessage.ScheduleProfileNotAdded, new { Reason = $"1-schedule with this id not found, 2-file with this id not found" });
        //    return OkResult(ApiMessage.ScheduleProfileAdded, new { SchedulePictures = result });
        //}

        ///// <summary>
        ///// گرفتن همه عکس ها برای یک سانس
        ///// </summary>
        //[HttpGet("AllPicForSchedule/{id}")] //scheduleID
        //public async Task<IActionResult> GetAllPicForSchedule(Guid id)
        //{
        //    var result = await _fileService.GetAllPicForSchedule(id);
        //    if (result == null)
        //        return BadReq(ApiMessage.ScheduleNotHavePic, new { Reason = $"1-schedule with this id not found, 2-schedule with this id not have profile" });
        //    return OkResult(ApiMessage.GetAllScheduleProfiles, new { SchedulePictures = result });
        //}

        //#endregion

        //#region private_methods
        //[NonAction]
        //private string GetContentType(string path)
        //{
        //    var provider = new FileExtensionContentTypeProvider();

        //    if (!provider.TryGetContentType(path, out var contentType))
        //    {
        //        contentType = "application/octet-stream";
        //    }
        //    return contentType;

        //}
        //#endregion
    }
}
