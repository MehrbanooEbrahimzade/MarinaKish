using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using System.Globalization;
using Application.Commands;
using Application.Commands.Schedule;
using Application.Services.interfaces;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Microsoft.AspNetCore.Razor.Language.CodeGeneration;
using Infrastructure.Extensions;

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
        [HttpPut("{id}/Update")]
        public async Task<IActionResult> UpdateSpecialOffer(Guid id,UpdateSpecialFunCommand command)
        {
            command.ShceduleId = id;
            await _scheduleService.UpdateSpecialOff(command);
            return OkResult(ApiMessage.Ok);
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
        [HttpPost("GetAll")]
        public async Task<IActionResult> GetAllSchedule(GetAllByDateTimeCommand command)
        {
            var getAll = await _scheduleService.GetAllSchedule(command);

            return OkResult(ApiMessage.GetAllScheduleForFun, getAll);
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
        /// حذف لیستی از سانس ها
        /// </summary>
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteSchedule(DeleteListCommand command)
        {
            await _scheduleService.DeleteSchedule(command);

            return OkResult(ApiMessage.Ok);
        }


        /// <summary>
        /// ویرایش سانس
        /// </summary>
        [HttpPut("{id}/ScheduleUpdate")]

        public async Task<IActionResult> UpdateSchedule(Guid id,UpdateScheduleCommand command)
        {
            command.ScheduleId = id;

            if (!command.Validate())
            {
                return BadReq(ApiMessage.BadRequest, new {Request = "1-ای دیه سانس را وارد کنید"});
            }

            var result = await _scheduleService.UpdateSchedule(command);
            if (result == false)
                throw new Exception(ApiMessage.BadRequest);

            return OkResult(ApiMessage.UpdateSchedule);

        }

        /// <summary>
        /// گرفتن اخرین زمان سانس یک تفریح 
        /// </summary>
        [HttpGet("{id}/getdate")]
        public async Task<IActionResult> GetEndDate(Guid id)
        {
            var result = await _scheduleService.GetTimeAndId(id);

            if (result == null)
                throw new Exception("عملیات با خطا مواجه شد");

            return OkResult(ApiMessage.Ok, new {result});
        }

    }
}
