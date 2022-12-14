using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Commands.Comment;
using Application.Dtos;
using Domain.Enums;

namespace Application.Services.interfaces
{
    public interface ICommentService
    {
        /// <summary>
        /// اضافه کردن کامنت
        /// </summary>
        Task<CommentDto> AddCommentToFun(AddCommentCommand command);

        /// <summary>
        /// تایید شدن لیستی از کامنت ها
        /// </summary>
        Task<bool> OkStatusCommentList(ChangeStatusCommentListCommand command);

        /// <summary>
        /// تایید شدن لیستی از کامنت ها
        /// </summary>
        Task<bool> NotOkStatusCommentList(ChangeStatusCommentListCommand command);

        /// <summary>
        /// گرفتن همه کامنت های  یک تفریح با حالات مختلف
        /// </summary>
        Task<List<CommentDto>> GetAllAcceptedCommentsForFun(GetAllCommand command);


        /// <summary>
        /// افزایش لایک
        /// </summary>
        Task<bool> IncreaseLikeComment(Guid id);

        /// <summary>
        /// کاهش لایک
        /// </summary>
        Task<bool> DecreaseLikeComment(Guid id);



        //public async Task<CommentDto> BlockingComment(Guid id)
        //public async Task<int> BlockAllUserComments(Guid id)
        ///// <summary> 




        ///// <summary>
        ///// تغییر وضعیت دادن یک کامنت با آیدی
        ///// </summary>
        //Task<CommentDto> ChangeStatusComment(Guid id, Status status);


        ///// <summary>
        ///// دریافت کامنت های یک وضعیت خاص یک تفریح با فان آیدی
        ///// </summary>
        //Task<List<CommentDto>> GetAllCommentsForFunWithStatus(Guid funId, Status status);

    }
}
