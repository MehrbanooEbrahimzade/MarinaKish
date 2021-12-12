﻿using Microsoft.AspNetCore.Mvc;
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
        [HttpPost("Add-Fun")]
        public async Task<IActionResult> AddFunAsync(AddFunCommand command)
        {
            if (!command.Validate())
                return BadReq(ApiMessage.WrongFunInformation);

            var result = await _funService.AddFunAsync(command);
            if (result == null)
                return BadReq(ApiMessage.FunNotAdded, new { Reason = $"Make a Problem When Fun Add. TryAgain!" });
            return OkResult(ApiMessage.FunAdded, new { FunID = result });
        }

        /// <summary>
        /// ویرایش تفریح
        /// </summary>
        [HttpPut("Edit-Fun/{id}")]
        public async Task<IActionResult> EditFunAsync(Guid id, UpdateFunCommand command)
        {
            command.FunId = id;
            if (!command.Validate())
                return BadReq(ApiMessage.WrongFunID, new { Reasons = $"1-wrong funID, 2-wrong command information" });
            
            var result = await _funService.UpdateFunAsync(command);
            if (result == null)
                return BadReq(ApiMessage.NotFunEdited, new { Reasons = $"1-fun not found, 2-There is a problem when save changes. TryAgain!" });
            return OkResult(ApiMessage.FunEdited, new { FunInfo = result });
        }

        /// <summary>
        /// حذف تفریح
        /// </summary>
        [HttpDelete("Delete-Fun/{id}")]
        public async Task<IActionResult> DeleteFunAsync(Guid id)
        {
            var result = await _funService.DeleteFunAsync(id);
            if (result)
                return OkResult(ApiMessage.FunDeleted, new { IsDelete = $"{result}" });
            return BadReq(ApiMessage.NotExistFunId, new { Reasons = $"1-Not Exist Fun With This Id, 2-make a problem when fun deleting. TryAgain!"});
        }

        /// <summary>
        /// دریافت همه تفریح ها
        /// </summary>
        [HttpGet("Get-All")]
        public async Task<IActionResult> GetAllFunAsync()
        {
            var result = await _funService.GetAllFunAsync();
            return OkResult(ApiMessage.AllFunGetted, new { AllFuns = result });
        }

        /// <summary>
        /// گرفتن یک تفریح
        /// </summary>
        [HttpGet("GetOne/{id}")]
        public async Task<IActionResult> GetOneFunAsync(Guid id)
        {
            var result = await _funService.GetOneFunAsync(id);
            if (result == null)
                return BadReq(ApiMessage.NotExistFunId, new { Reason = $"Fun not exist with this id. TryAgain!" });
            return OkResult(ApiMessage.FunGetted, new { FunInfo = result });
        }

        /// <summary>
        /// گرفتن تفریح ها با نوع تفریح
        /// </summary>
        [HttpGet("GetAllBy-FunType")]
        public async Task<IActionResult> GetFunsWithFunType(GetFunWithFunTypeCommand command)
        {
            if (!command.Validate())
                return BadReq(ApiMessage.WrongFunType, new { Reasons = $"1-enter funType, 2-funType not exist" });

            var result = await _funService.GetFunsWithFunType(command);
            if (result == null)
                return BadReq(ApiMessage.NotExistFunType);
            return OkResult(ApiMessage.FunsByFunTypeGetted, new { Funs = result });
        }

        /// <summary>
        /// اضافه کردن عکس پس زمینه تفریح
        /// </summary>
        [HttpPut("AddBackgroundPicture/{id}")]
        public async Task<IActionResult> AddFunBackgroundPicture(Guid id, AddFileToFunCommand command)
        {
            command.FunId = id;
            if (!command.Validate())
                return BadReq(ApiMessage.WrongFunIDOrFileID, new { Reasons = $"1-enter funID, 2-enter fileID" });

            var result = await _funService.AddFunBackgroundPicture(command);
            if (result == null)
                return BadReq(ApiMessage.NotBackgroundPictureAdded, new { Reasons = $"1-Fun not exist with this id 2-file not exist with this id" });
            return OkResult(ApiMessage.BackgroundPictureAdded, new { FunBackgroundPicture = $"{result}" });
        }

        /// <summary>
        /// اضافه کردن آیکون تفریح
        /// </summary>
        [HttpPut("AddIcon/{id}")]
        public async Task<IActionResult> AddFunIcon(Guid id, AddFileToFunCommand command)
        {
            command.FunId = id;
            if (!command.Validate())
                return BadReq(ApiMessage.WrongFunIDOrFileID, new { Reasons = $"1-enter funID, 2-enter fileID" });

            var result = await _funService.AddFunIcon(command);
            if (result == null)
                return BadReq(ApiMessage.NoticonAdded, new { Reasons = $"1-Fun not found, 2-file not found" });
            return OkResult(ApiMessage.iconAdded, new { FunIcon = $"{result}" });
        }

        /// <summary>
        /// غیرفعال کردن یک تفریح
        /// </summary>
        [HttpPut("DisActive/{id}")]
        public async Task<IActionResult> DisActiveFunById(Guid id)
        {
            var result = await _funService.DisActiveFunById(id);
            if (!result)
                return BadReq(ApiMessage.FunNotDisActive, new { Reasons = $"1-fun already disActived, 2-wrong fun id" });
            return OkResult(ApiMessage.FunDisActived, new { DisActived = result });
        }

        /// <summary>
        /// دوباره فعال کردن یک تفریح
        /// </summary>
        [HttpPut("ReActive/{id}")]
        public async Task<IActionResult> ReActiveFunById(Guid id)
        {
            var result = await _funService.ReActiveFunById(id);
            if (!result)
                return BadReq(ApiMessage.FunNotReActive, new { Reasons = $"1-fun already Actived, 2-wrong fun id" });
            return OkResult(ApiMessage.FunReActived, new { ReActived = result });
        }

        /// <summary>
        /// دریافت همه تفریح های فعال
        /// </summary>
        [HttpGet("GetAllActived")]
        public async Task<IActionResult> GetAllActivedFun()
        {
            var result = await _funService.GetAllActivedFun();
            if (result == null)
                return BadReq(ApiMessage.MarineNotHaveActiveFunYet);
            return OkResult(ApiMessage.AllActiveFunGetted, new { ActiveFuns = result });
        }

        /// <summary>
        /// دریافت همه تفریح های غیر فعال
        /// </summary>
        [HttpGet("GetAllDisActived")]
        public async Task<IActionResult> GetAllDisActivedFun()
        {
            var result = await _funService.GetAllDisActivedFun();
            if (result == null)
                return BadReq(ApiMessage.MarineNotHaveDisActiveFun);
            return OkResult(ApiMessage.AllDisActiveFunGetted, new { DisActiveFuns = result });
        }

        /// <summary>
        /// دریافت تعداد همه تفریح های فعال
        /// </summary>
        [HttpGet("GetAllActived-Count")]
        public async Task<IActionResult> GetAllActivedFunCount()
        {
            var result = await _funService.GetAllActivedFun();
            if (result == null)
                return BadReq(ApiMessage.MarineNotHaveActiveFunYet);
            return OkResult(ApiMessage.AllActiveFunGetted, new { ActiveFunsCount = result.Count });
        }

        /// <summary>
        /// دریافت تعداد همه تفریح های غیر فعال
        /// </summary>
        [HttpGet("GetAllDisActived-Count")]
        public async Task<IActionResult> GetAllDisActivedFunCount()
        {
            var result = await _funService.GetAllDisActivedFun();
            if (result == null)
                return BadReq(ApiMessage.MarineNotHaveDisActiveFun);
            return OkResult(ApiMessage.AllDisActiveFunGetted, new { DisActiveFunsCount = result.Count });
        }

    }
}
