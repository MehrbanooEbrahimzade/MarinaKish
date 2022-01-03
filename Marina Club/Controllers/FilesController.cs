using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
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
        /// (عکس و فیلم)
        /// </summary>
        [HttpPost("Upload")]
        public async Task<IActionResult> UploadFileAsync(IFormFile file)
        {
            
            var result = await _fileService.UploadFileAsync(file);

            if (result == null)
                BadReq(ApiMessage.PicNotAdd);

            return OkResult(ApiMessage.OkFileAdd, result);
        }

        /// <summary>
        /// دانلود کردن عکس
        /// </summary>
        [HttpGet("{id}/Download")]
        public async Task<IActionResult> DownloadPicsAsync(Guid id)
        {
            var myFile = await _fileService.DownloadFile(id);

            if (myFile.Bytes == null)
                BadReq(ApiMessage.BadRequest);

            return File(myFile.Bytes, myFile.Type);
        }

        /// <summary>
        /// پاک کردن فایل
        /// </summary>
        [HttpDelete("{id}/Delete")]
        public async Task<IActionResult> DeleteFileAsync(Guid id)
        {
            var result = await _fileService.DeleteFileAsync(id);

            if (!result)
                return BadReq(ApiMessage.BadRequest);

            return OkResult(ApiMessage.FileDeleted);

        }
    }
}
