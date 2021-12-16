using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Commands.Comment;
using Application.Dtos;
using Domain.Models.enums;

namespace Application.Services.interfaces
{
    public interface ICommentService
    {
        ///// <summary>
        ///// اضافه کردن کامنت
        ///// </summary>
        //Task<CommentDto> AddCommentToFun(AddCommentCommand command);
        ////public async Task<CommentDto> BlockingComment(Guid id)
        ////public async Task<int> BlockAllUserComments(Guid id)
        ///// <summary>
        ///// تایید شدن یا نشدن کامنت
        ///// </summary>
        //Task<bool> ChangeCommentStatus(ChangeCommentStatusCommand command);

        ///// <summary>
        ///// تایید شدن یا نشدن لیستی از کامنت ها
        ///// </summary>
        //Task<bool> ChangeStatusCommentList(ChangeStatusCommentListCommand command);


        ///// <summary>
        ///// گرفتن همه کامنت های قبول شده برای یک تفریح
        ///// </summary>
        //Task<List<CommentDto>> GetAllAcceptedCommentsForFun(Guid funId, EStatus status);
    
        ///// <summary>
        ///// افزایش لایک
        ///// </summary>
        //Task<bool> IncreaseLikeComment(Guid id);

        ///// <summary>
        ///// کاهش لایک
        ///// </summary>
        //Task<bool> DecreaseLikeComment(Guid id);


        ///// <summary>
        ///// تغییر وضعیت دادن یک کامنت با آیدی
        ///// </summary>
        //Task<CommentDto> ChangeStatusComment(Guid id, EStatus status);


        ///// <summary>
        ///// دریافت کامنت های یک وضعیت خاص یک تفریح با فان آیدی
        ///// </summary>
        //Task<List<CommentDto>> GetAllCommentsForFunWithStatus(Guid funId, EStatus status);
        
    }
}
