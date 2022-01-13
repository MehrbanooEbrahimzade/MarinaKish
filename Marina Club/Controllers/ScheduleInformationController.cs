using System;
using Application.Commands.ScheduleInfo;
using Application.Services.interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Application.Commands.ScheduleInfo;
using Application.Services.classes;

namespace Marina_Club.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ScheduleInformationController : ApiController
    {
        private readonly IScheduleInfoService _scheduleInfoService;
        public ScheduleInformationController(IScheduleInfoService scheduleInfoService)
        {
            _scheduleInfoService = scheduleInfoService;
        }

        [HttpPost]
        public void AddScheduleInfoAsync(AddScheduleInfoCommand command)
        {
            if (!command.Validate())
            { 
                BadReq(ApiMessage.WrongInformation);
            } 
            //_scheduleInfoService.AddScheduleInfoAsync(command);
        }


        /// <summary>
        /// ویرایش اطلاعات سانس
        /// </summary>
        [HttpPut("{id}/Update")]
        public async Task<IActionResult> UpdateScheduleInfoAsync(Guid id, UpdateScheduleInfoCommand command)
        {
            command.Id = id;
            if (!command.Validate())
            {
                return BadReq(ApiMessage.WrongInformation);
            }
            //await _scheduleInfoService.UpdateScheduleInfoAsync(command);

            return Ok(ApiMessage.Ok);
        }

        ///// <summary>
        ///// حذف اطلاعات سانس
        ///// </summary>
        //[HttpDelete("{id}/Delete")]
        //public async Task<IActionResult> DeleteScheduleInfoAsync(Guid id)
        //{
        //    _scheduleInfoService.DeleteScheduleInfoAsync(id);
        //    return OkResult(ApiController.ApiMessage.ScheduleInfoDeleted);
        //}

        ///// <summary>
        ///// دریافت همهاطلاعات سانس ها
        ///// </summary>
        //[HttpGet("GetAll")]
        //public async Task<IActionResult> GetAllScheduleInfoAsync()
        //{
        //    var result = await _scheduleInfoService.GetAllScheduleInfoAsync();
        //    return OkResult(ApiController.ApiMessage.AllScheduleInfoGetted, new { AllScheduleInfos = result });
        //}

        ///// <summary>
        ///// گرفتن یک اطلاعات سانس
        ///// </summary>
        //[HttpGet("{id}/GetOne")]
        //public async Task<IActionResult> GetOneScheduleInfoByIdAsync(Guid id)
        //{
        //    var result = await _scheduleInfoService.GetOneScheduleInfoAsync(id);
        //    return result == null ? BadReq(ApiController.ApiMessage.NotExistScheduleInfoId, new { Reason = $"ScheduleInfo not exist with this id. TryAgain!" })
        //        : OkResult(ApiController.ApiMessage.ScheduleInfoGetted, new { ScheduleInfoInfo = result });
        //}

        ///// <summary>
        ///// گرفتن اطلاعات سانس ها با اسم اطلاعات سانس
        ///// </summary>
        //[HttpGet("{name}/GetByName")]
        //public async Task<IActionResult> GetScheduleInfosWithScheduleInfoNameAsynch(string name)
        //{

        //    var result = await _scheduleInfoService.GetScheduleInfosWithScheduleInfoNameAsynch(name);
        //    return result == null ?
        //        BadReq(ApiController.ApiMessage.NotExistScheduleInfoType) :
        //        OkResult(ApiController.ApiMessage.ScheduleInfosByScheduleInfoTypeGetted, new { ScheduleInfos = result });
        //}


        ///// <summary>
        ///// غیرفعال کردن یک اطلاعات سانس
        ///// </summary>
        //[HttpPut("{id}/DisActive")]
        //public async Task<IActionResult> DisActiveScheduleInfoByIdAsynch(Guid id)
        //{
        //    var result = await _scheduleInfoService.DisActiveScheduleInfoByIdAsynch(id);
        //    return !result ? BadReq(ApiController.ApiMessage.ScheduleInfoNotDisActive, new { Reasons = $"1-eScheduleInfo already disActived, 2-wrong eScheduleInfo id" })
        //        : OkResult(ApiController.ApiMessage.ScheduleInfoDisActived, new { DisActived = result });
        //}

        ///// <summary>
        ///// دوباره فعال کردن یک اطلاعات سانس
        ///// </summary>
        //[HttpPut("{id}/ReActive")]
        //public async Task<IActionResult> ReActiveScheduleInfoByIdAsynch(Guid id)
        //{
        //    var result = await _scheduleInfoService.ReActiveScheduleInfoByIdAsynch(id);
        //    return !result ? BadReq(ApiController.ApiMessage.ScheduleInfoAllreadyReActive, new { Reasons = $"1-eScheduleInfo already Actived, 2-wrong eScheduleInfo id" })
        //        : OkResult(ApiController.ApiMessage.ScheduleInfoReActived, new { ReActived = result });
        //}

        ///// <summary>
        ///// دریافت همه اطلاعات سانس های فعال
        ///// </summary>
        //[HttpGet("GetAllActived")]
        //public async Task<IActionResult> GetAllActivedScheduleInfoAsynch()
        //{
        //    var result = await ScheduleInfoService.GetAllActivedScheduleInfoAsynch();
        //    return result == null ? BadReq(ApiController.ApiMessage.MarineNotHaveActiveScheduleInfoYet) :
        //        OkResult(ApiController.ApiMessage.AllActiveScheduleInfoGetted, new { ActiveScheduleInfos = result });
        //}

        ///// <summary>
        ///// دریافت همه اطلاعات سانس های غیر فعال
        ///// </summary>
        //[HttpGet("GetAllDisActived")]
        //public async Task<IActionResult> GetAllDisActivedScheduleInfoAsynch()
        //{
        //    var result = await _scheduleInfoService.GetAllDisActivedScheduleInfoAsynch();
        //    return result == null ? BadReq(ApiController.ApiMessage.MarineNotHaveDisActiveScheduleInfo) :
        //        OkResult(ApiController.ApiMessage.AllDisActiveScheduleInfoGetted, new { DisActiveScheduleInfos = result });
        //}

        ///// <summary>
        ///// دریافت تعداد همه اطلاعات سانس های فعال
        ///// </summary>
        //[HttpGet("GetAllActivedCount")]
        //public async Task<IActionResult> GetAllActivedScheduleInfoCountAsynch()
        //{
        //    var result = await _scheduleInfoService.GetAllActivedScheduleInfoAsynch();
        //    return result == null ? BadReq(ApiController.ApiMessage.MarineNotHaveActiveScheduleInfoYet) :
        //        OkResult(ApiController.ApiMessage.AllActiveScheduleInfoGetted, new { ActiveScheduleInfosCount = result.Count });
        //}

        ///// <summary>
        ///// دریافت تعداد همه اطلاعات سانس های غیر فعال
        ///// </summary>
        //[HttpGet("GetAllDisActivedCount")]
        //public async Task<IActionResult> GetAllDisActivedScheduleInfoCountAsynch()
        //{
        //    var result = await _scheduleInfoService.GetAllDisActivedScheduleInfoAsynch();
        //    return result == null ? BadReq(ApiController.ApiMessage.MarineNotHaveDisActiveScheduleInfo) :
        //        OkResult(ApiController.ApiMessage.AllDisActiveScheduleInfoGetted, new { DisActiveScheduleInfosCount = result.Count });
        //}
    }
}
