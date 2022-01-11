using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Application.Commands.Comment;
using Application.Services.interfaces;
using Domain.Enums;

namespace Marina_Club.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ApiController
    {
        private readonly ICommentService _commentService;
        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        /// <summary>
        /// اضافه کردن کامنت
        /// </summary>
        [HttpPost("{id}/AddComment")] // funId 
        public async Task<IActionResult> AddCommentToFun(Guid id, AddCommentCommand command)
        {
            command.FunId = id;
            if (!command.Validate())
                return BadReq(ApiMessage.WrongFunID, new { Reasons = $"1-enter funID, 2-enter message, 3-enter userID, 4-eFunType & Username & UserPhoneNumber must null" });

            var result = await _commentService.AddCommentToFun(command);
            if (result == null)
                return BadReq(ApiMessage.BadRequest, new { Reasons = $"1-any active eFun not found, 2-any active user not found, 3-there is a problem when comment adding. TryAgain!" });
            return OkResult(ApiMessage.CommentAddedPlsWait, new { CommentObj = result });
        }

        /// <summary>
        /// تغییر وضعیت لیستی از کامنت ها
        /// </summary>
        [HttpPut("OkStatusList")]
        public async Task<IActionResult> ChangeVerifyingOkCommentList(ChangeStatusCommentListCommand command)
        {
            var result = await _commentService.OkStatusCommentList(command);
            if (!result)
                return BadReq(ApiMessage.CommentsStatusNotChanged, new { Reasons = $"1-any comment not found, 2-comments already in this status" });
            return OkResult(ApiMessage.CommentsStatusChanged);
        }

        /// <summary>
        /// تغییر وضعیت لیستی از کامنت ها
        /// </summary>
        [HttpPut("NotOkStatusList")]
        public async Task<IActionResult> ChangeVerifyingNotOkCommentList(ChangeStatusCommentListCommand command)
        {
            var result = await _commentService.NotOkStatusCommentList(command);
            if (!result)
                return BadReq(ApiMessage.CommentsStatusNotChanged, new { Reasons = $"1-any comment not found, 2-comments already in this status" });
            return OkResult(ApiMessage.CommentsStatusChanged);
        }




        /// <summary>
        ///  گرفتن همه کامنت های  برای یک تفریح با حالات مختلف
        /// </summary>
        [HttpGet("GetAllComment")]
        public async Task<IActionResult> GetAllWaitingCommentsForFun(GetAllCommand command)
        {
            if (!command.Validate())
                return BadReq(ApiMessage.FunCommentsNotFound, new { Reasons = $"1-مقدار ورودیه وضعیت صحیح نمیباشد" });


            var result = await _commentService.GetAllAcceptedCommentsForFun(command);
            if (result == null)

                return BadReq(ApiMessage.FunNotHaveAnyAcceptedComment, new { Reasons = $"1-eFun not have waiting comments, 2-check funID and TryAgain!" });
            return OkResult(ApiMessage.WaitingFunCommentsGetted, new { LatestComments = result });
        }

        /// <summary>
        /// افزایش لایک کامنت
        /// </summary>
        [HttpPut("{id}/IncreaseLike")]
        public async Task<IActionResult> IncreaseLikeComment(Guid id)
        {
            var result = await _commentService.IncreaseLikeComment(id);
            if (!result)
                return BadReq(ApiMessage.IncreaseLikeFaild, new { Reasons = $"1-comment not found, 2-there is a problem when saveChanges. TryAgain!" });
            return OkResult(ApiMessage.IncreasedLike, new { Result = $"1 like increased to comment" });
        }

        /// <summary>
        /// کاهش لایک کامنت
        /// </summary>
        [HttpPut("{id}/DecreaseLike")]
        public async Task<IActionResult> DecreaseLikeComment(Guid id)
        {
            var result = await _commentService.DecreaseLikeComment(id);
            if (!result)
                return BadReq(ApiMessage.DecreaseLikeFaild, new { Reasons = $"1-comment not found, 2-there is a problem when saveChanges. TryAgain!" });
            return OkResult(ApiMessage.DecreasedLike, new { Result = $"1 like decreased to comment" });
        }

     




        ///// <summary>
        ///// قبول کردن یک کامنت با آیدی
        ///// </summary>
        //[HttpPut("Accepting/{id}")] 
        //public async Task<IActionResult> AcceptingComment(Guid id )
        //{
        //    var result = await _commentService.ChangeStatusComment(id, Status.Accepted);
        //    if (result == null)
        //        return BadReq(ApiMessage.CommentNotFound, new { Reason = $"1-comment isn't in waiting list, 2-there is a problem when saveChanges.TryAgain!" });
        //    return OkResult(ApiMessage.CommentAccepted, new { Comment = result });
        //}

        ///// <summary>
        ///// رد کردن یک کامنت با آیدی
        ///// </summary>
        //[HttpPut("Declining/{id}")] 
        //public async Task<IActionResult> DecliningComment(Guid id)
        //{
        //    var result = await _commentService.ChangeStatusComment(id, Status.Declined);
        //    if (result == null)
        //        return BadReq(ApiMessage.CommentNotFound, new { Reason = $"1-comment isn't in waiting list, 2-there is a problem when saveChanges.TryAgain!" });
        //    return OkResult(ApiMessage.CommentDeclined, new { Comment = result });
        //}





    }
}
