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
        public FunsController(IFunService funService)
        {
            _funService = funService;
        }

        /// <summary>
        /// اضافه کردن تفریح
        /// </summary>
        [HttpPost("Add")]
        public async Task<IActionResult> AddFunAsync(AddFunCommand command)
        {
            if (!command.Validate())
            {
                return BadReq(ApiMessage.WrongFunInformation, new { Reason = $"Make a Problem When Fun Add. TryAgain!" });
            }
            _funService.AddFunAsync(command);
            return OkResult(ApiMessage.FunAdded);
        }

        /// <summary>
        /// ویرایش تفریح
        /// </summary>
        [HttpPut("{id}/Edit")]
        public async Task<IActionResult> EditFunAsync(Guid id, UpdateFunCommand command)
        {
            command.FunId = id;
            if (!command.Validate())
            {
                return BadReq(ApiMessage.WrongFunID, new { Reasons = $"1-wrong funID, 2-wrong command information" });
            }
            await _funService.UpdateFunAsync(command);
            return OkResult(ApiMessage.FunEdited);
        }

        /// <summary>
        /// حذف تفریح
        /// </summary>
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteFunAsync(Guid id)
        {
            _funService.DeleteFunAsync(id);
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
        [HttpGet("GetOne/{id}")]
        public async Task<IActionResult> GetOneFunByIdAsync(Guid id)
        {
            var result = await _funService.GetOneFunAsync(id);
            if (result == null)
                return BadReq(ApiMessage.NotExistFunId, new { Reason = $"Fun not exist with this id. TryAgain!" });
            return OkResult(ApiMessage.FunGetted, new { FunInfo = result });
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
            return !result ? BadReq(ApiMessage.FunNotReActive, new { Reasons = $"1-eFun already Actived, 2-wrong eFun id" })
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
