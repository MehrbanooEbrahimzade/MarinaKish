using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Application.Commands.Fun;
using Application.Services.interfaces;

namespace Marina_Club.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FunsController : ApiController
    {
        private readonly IFunService _funService;
        private readonly IScheduleInfoService _scheduleInfoService;
        public FunsController(IFunService funService, IScheduleInfoService scheduleInfoService)
        {
            _funService = funService;
            _scheduleInfoService = scheduleInfoService;
        }

        /// <summary>
        /// اضافه کردن تفریح و اطلاعات سانس و ساختن سانس
        /// </summary>
        [HttpPost("Add")]
        public IActionResult AddFunAsync(AddFunCommand command)
        {
            //if (!command.Validate())
            //{
            //    return BadReq(ApiMessage.WrongFunInformation);
            //}
            command.ScheduleInfo.FunId = _funService.AddFunAsync(command);
             _scheduleInfoService.AddScheduleInfoAsync(command.ScheduleInfo);
            return OkResult(ApiMessage.FunAdded);
        }

        /// <summary>
        /// ویرایش تفریح
        /// </summary>
        [HttpPut("{id}/Update")]
        public async Task<IActionResult> UpdateFunAsync(Guid id, UpdateFunCommand command)
        {
            command.FunId = id;
            if (!command.Validate())
            {
                return BadReq(ApiMessage.WrongInformation);
            }
            await _scheduleInfoService.UpdateScheduleInfoAsync(command.ScheduleInfo);
            await _funService.UpdateFunAsync(command);
            return OkResult(ApiMessage.FunEdited);
        }

        /// <summary>
        /// حذف تفریح
        /// </summary>
        [HttpDelete("{id}/Delete")]
        public async Task<IActionResult> DeleteFunAsync(Guid id)
        {
            await _funService.DeleteFunAsync(id);
            return OkResult(ApiMessage.FunDeleted);
        }

        /// <summary>
        /// دریافت همه تفریح ها
        /// </summary>
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllFunAsync()
        {
            var result = await _funService.GetAllFunAsync();
            return OkResult(ApiMessage.AllFunGetted, new { AllFuns = result });
        }

        /// <summary>
        /// گرفتن یک تفریح
        /// </summary>
        [HttpGet("{id}/GetOne")]
        public async Task<IActionResult> GetOneFunByIdAsync(Guid id)
        {
            var result = await _funService.GetOneFunAsync(id);
            return result == null ? BadReq(ApiMessage.NotExistFunId, new { Reason = $"Fun not exist with this id. TryAgain!" })
                : OkResult(ApiMessage.FunGetted, new { FunInfo = result });
        }

        /// <summary>
        /// گرفتن تفریح ها با اسم تفریح
        /// </summary>
        [HttpGet("{name}/GetByName")]
        public async Task<IActionResult> GetFunsWithFunNameAsynch(string name)
        {

            var result = await _funService.GetFunsWithFunNameAsynch(name);
            return result == null ?
                BadReq(ApiMessage.NotExistFunType) :
                OkResult(ApiMessage.FunsByFunTypeGetted, new { Funs = result });
        }


        /// <summary>
        /// غیرفعال کردن یک تفریح
        /// </summary>
        [HttpPut("{id}/DisActive")]
        public async Task<IActionResult> DisActiveFunByIdAsynch(Guid id)
        {
            var result = await _funService.DisActiveFunByIdAsynch(id);
            return !result ? BadReq(ApiMessage.FunNotDisActive, new { Reasons = $"1-eFun already disActived, 2-wrong eFun id" })
                : OkResult(ApiMessage.FunDisActived, new { DisActived = result });
        }

        /// <summary>
        /// دوباره فعال کردن یک تفریح
        /// </summary>
        [HttpPut("{id}/ReActive")]
        public async Task<IActionResult> ReActiveFunByIdAsynch(Guid id)
        {
            var result = await _funService.ReActiveFunByIdAsynch(id);
            return !result ? BadReq(ApiMessage.FunAllreadyReActive, new { Reasons = $"1-eFun already Actived, 2-wrong eFun id" })
                : OkResult(ApiMessage.FunReActived, new { ReActived = result });
        }

        /// <summary>
        /// دریافت همه تفریح های فعال
        /// </summary>
        [HttpGet("GetAllActived")]
        public async Task<IActionResult> GetAllActivedFunAsynch()
        {
            var result = await _funService.GetAllActivedFunAsynch();
            return result == null ? BadReq(ApiMessage.MarineNotHaveActiveFunYet) :
                OkResult(ApiMessage.AllActiveFunGetted, new { ActiveFuns = result });
        }

        /// <summary>
        /// دریافت همه تفریح های غیر فعال
        /// </summary>
        [HttpGet("GetAllDisActived")]
        public async Task<IActionResult> GetAllDisActivedFunAsynch()
        {
            var result = await _funService.GetAllDisActivedFunAsynch();
            return result == null ? BadReq(ApiMessage.MarineNotHaveDisActiveFun) :
                OkResult(ApiMessage.AllDisActiveFunGetted, new { DisActiveFuns = result });
        }

        /// <summary>
        /// دریافت تعداد همه تفریح های فعال
        /// </summary>
        [HttpGet("GetAllActivedCount")]
        public async Task<IActionResult> GetAllActivedFunCountAsynch()
        {
            var result = await _funService.GetAllActivedFunAsynch();
            return result == null ? BadReq(ApiMessage.MarineNotHaveActiveFunYet) :
                OkResult(ApiMessage.AllActiveFunGetted, new { ActiveFunsCount = result.Count });
        }

        /// <summary>
        /// دریافت تعداد همه تفریح های غیر فعال
        /// </summary>
        [HttpGet("GetAllDisActivedCount")]
        public async Task<IActionResult> GetAllDisActivedFunCountAsynch()
        {
            var result = await _funService.GetAllDisActivedFunAsynch();
            return result == null ? BadReq(ApiMessage.MarineNotHaveDisActiveFun) :
                OkResult(ApiMessage.AllDisActiveFunGetted, new { DisActiveFunsCount = result.Count });
        }
    }
}
