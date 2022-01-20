using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using System.Globalization;
using Application.Commands;
using Application.Commands.Schedule;
using Application.Services.interfaces;
using Microsoft.AspNetCore.Razor.Language.CodeGeneration;

namespace Marina_Club.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulesController : ApiController
    {
        private readonly IScheduleService _scheduleService;
        public SchedulesController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        /// <summary>
        /// ساخت پیشنهاد های ویژه
        /// </summary> 
        [HttpPost("AddSpecialOffer")]
        public async Task<IActionResult> AddSpecialOffer(AddSpecialOfferCommand command)
        {
            if (!command.Validate())
                return BadReq(ApiMessage.BadRequest,
                    new { Request = "1-مقدار تخفیف درست وارد نشده 2-ای دی تفریح وارد نشده" });

            var result = _scheduleService.AddSpecialOffer(command);
            if (result == null)
                return BadReq(ApiMessage.BadRequest);

            return OkResult("تخفیف با موفقیت اضافه شد");

        }


        /// <summary>
        /// گرفتن یک سانس با ایدی سانس
        /// </summary>
        [HttpGet("{id}/GetById")]
        public async Task<IActionResult> GetScheduleById(Guid id)
        {
            var Schedule = await _scheduleService.GetScheduleById(id);
            if (Schedule == null)
                BadReq(ApiMessage.SchedulesNotExist);

            return OkResult(ApiMessage.GetScheduleById, Schedule);

        }

        /// <summary>
        /// گرفتن همه سانس ها
        /// </summary>
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllSchedule()
        {
            var getall = await _scheduleService.GetAllSchedule();

            return OkResult(ApiMessage.GetAllScheduleForFun, getall);
        }


        /// <summary>
        /// گرفتن همه سانس های یک تفریح
        /// </summary>
        [HttpGet("{funId}/SchedulesForFun")]
        public async Task<IActionResult> GetSchedulesForFun(Guid funId)
        {
            var getall = await _scheduleService.GetSchedulesForFun(funId);

            return OkResult(ApiMessage.GetAllScheduleForFun, getall);
        }

        
        /// <summary>
        /// حذف کردن سانس
        /// </summary>
        [HttpDelete("{id}/Delete")]
        public async Task<IActionResult> DeleteSchedule(Guid id)
        {
            await _scheduleService.DeleteSchedule(id);

            return OkResult(ApiMessage.Ok);
        }
    }
}
