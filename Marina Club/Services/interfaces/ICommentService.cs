using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Marina_Club.Commands.Comment;
using Marina_Club.Dtos;

namespace Marina_Club.Services.interfaces
{
    public interface ICommentService
    {
        /// <summary>
        /// اضافه کردن کامنت
        /// </summary>
        Task<CommentDto> AddCommentToFun(AddCommentCommand command);

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
        /// بلاک کردن کل کامنت های یک کاربر
        /// </summary>
        Task<int> BlockAllUserComments(Guid id);

        /// <summary>
        /// قبول کردن یک کامنت با آیدی
        /// </summary>
        Task<CommentDto> AcceptingComment(Guid id);

        /// <summary>
        /// رد کردن یک کامنت با آیدی
        /// </summary>
        Task<CommentDto> DecliningComment(Guid id);

        /// <summary>
        /// بلاک کردن یک کامنت با آیدی
        /// </summary>
        Task<CommentDto> BlockingComment(Guid id);

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
