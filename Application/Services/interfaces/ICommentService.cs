using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Commands.Comment;
using Application.Dtos;

namespace Application.Services.interfaces
{
    public interface ICommentService
    {
        /// <summary>
        /// اضافه کردن کامنت
        /// </summary>
        Task<CommentDto> AddCommentToFun(AddCommentCommand command);
        //public async Task<CommentDto> BlockingComment(Guid id)
        //public async Task<int> BlockAllUserComments(Guid id)
        /// <summary>
        /// تایید شدن یا نشدن کامنت
        /// </summary>
        Task<bool> ChangeCommentStatus(ChangeCommentStatusCommand command);

        /// <summary>
        /// تایید شدن یا نشدن لیستی از کامنت ها
        /// </summary>
        Task<bool> ChangeStatusCommentList(ChangeStatusCommentListCommand command);

        /// <summary>
        /// گرفتن همه کامنت های قبول شده برای یک تفریح
        /// </summary>
        Task<List<CommentDto>> GetAllAcceptedCommentsForFun(Guid id);

        /// <summary>
        /// افزایش لایک
        /// </summary>
        Task<bool> IncreaseLikeComment(Guid id);

        /// <summary>
        /// کاهش لایک
        /// </summary>
        Task<bool> DecreaseLikeComment(Guid id);


        /// <summary>
        /// قبول کردن یک کامنت با آیدی
        /// </summary>
        Task<CommentDto> AcceptingComment(Guid id);

        /// <summary>
        /// رد کردن یک کامنت با آیدی
        /// </summary>
        Task<CommentDto> DecliningComment(Guid id);

   

        /// <summary>
        /// دریافت کامنت های درحال انتظار یک تفریح با آیدی
        /// </summary>
        Task<List<CommentDto>> GetAllWaitingCommentsForFun(Guid id);

        /// <summary>
        /// دریافت کامنت های رد شده یک تفریح با آیدی
        /// </summary>
        Task<List<CommentDto>> GetAllDeclinedCommentsForFun(Guid id);

        /// <summary>
        /// دریافت کامنت های بلاک شده یک تفریح با آیدی
        /// </summary>
        Task<List<CommentDto>> GetAllBlockedCommentsForFun(Guid id);
    }
}
