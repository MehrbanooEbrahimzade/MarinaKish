using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Application.Commands.Comment;
using Application.Dtos;
using Application.Mappers;
using Application.Services.interfaces;
using Domain.Models;
using Domain.Models.enums;
using Infrastructure.Repository.interfaces;

namespace Application.Services.classes
{

    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        /// <summary>
        /// اضافه کردن کامنت
        /// </summary>
        public async Task<CommentDto> AddCommentToFun(AddCommentCommand command)
        {
            var user = await _commentRepository.GetActiveUserById(command.UserId);
            var fun = await _commentRepository.GetActiveFunById(command.FunId);

            if (user == null || fun == null)
                return null;

            var commentObj = new Comment(command.Message, command.FunId, command.UserId, fun.FunType, user.CellPhone, user.UserName);
            
            var addCommentResult = await _commentRepository.AddCommentAsync(commentObj);

            if (!addCommentResult)
                return null;
            return commentObj.ToDto();

        }

        /// <summary>
        /// تایید شدن یا نشدن کامنت
        /// </summary>
        public async Task<bool> ChangeCommentStatus(ChangeCommentStatusCommand command)
        {
            var comment = await _commentRepository.GetCommentById(command.Id);
            comment.UpdateCommentStatus(command.Status);

            return await _commentRepository.SaveChangeCommentAsync();
        }

        /// <summary>
        /// تایید شدن یا نشدن لیستی از کامنت ها
        /// </summary>
        public async Task<bool> ChangeStatusCommentList(ChangeStatusCommentListCommand command)
        {
            foreach (var guid in command.IDs)
            {
                var comment = await _commentRepository.GetCommentById(guid);
                comment.UpdateCommentStatus(command.Status);
            }
            return await _commentRepository.SaveChangeCommentAsync();
        }

        /// <summary>
        /// گرفتن همه کامنت های قبول شده برای یک تفریح
        /// </summary>
        public async Task<List<CommentDto>> GetAllAcceptedCommentsForFun(Guid id)
        {
            var comments = await _commentRepository.GetAllAcceptedCommentsForFun(id);
            if (comments == null)
                return null;
            return comments.ToDto();
        }

        /// <summary>
        /// افزایش لایک کامنت
        /// </summary>
        public async Task<bool> IncreaseLikeComment(Guid id)
        {
            var comment = await _commentRepository.GetCommentById(id);
            if (comment == null)
                return false;

            comment.UpdateCommentLikes(1);
            return await _commentRepository.SaveChangeCommentAsync();
        }

        /// <summary>
        /// کاهش لایک کامنت
        /// </summary>
        public async Task<bool> DecreaseLikeComment(Guid id)
        {
            var comment = await _commentRepository.GetCommentById(id);
            if (comment == null)
                return false;

            comment.UpdateCommentDislikes(1);
            return await _commentRepository.SaveChangeCommentAsync();
        }
        //public async Task<int> BlockAllUserComments(Guid id)
        //{
        //    var userComments = await _commentRepository.GetAllAcceptedUserComments(id);
        //    if (userComments == null)
        //        return 404;

        //    foreach (var comment in userComments)
        //    {
        //        comment.UpdateCommentStatus(EStatus.Blocked);
        //    }
        //    var save = await _commentRepository.SaveChangeCommentAsync();
        //    if (!save)
        //        return 503;
        //    return userComments.Count;
        //}

        /// <summary>
        /// قبول کردن یک کامنت با آیدی
        /// </summary>
        public async Task<CommentDto> AcceptingComment(Guid id)
        {
            var comment = await _commentRepository.GetWaitingCommentById(id);
            if (comment == null)
                return null;
            comment.UpdateCommentStatus(EStatus.Accepted);

            var save = await _commentRepository.SaveChangeCommentAsync();
            if (!save)
                return null;
            return comment.ToDto();
        }

        /// <summary>
        /// رد کردن یک کامنت با آیدی
        /// </summary>
        public async Task<CommentDto> DecliningComment(Guid id)
        {
            var comment = await _commentRepository.GetWaitingCommentById(id);
            if (comment == null)
                return null;
            comment.UpdateCommentStatus(EStatus.Declined);

            var save = await _commentRepository.SaveChangeCommentAsync();
            if (!save)
                return null;
            return comment.ToDto();
        }

        /// <summary>
        /// بلاک کردن یک کامنت با آیدی
        /// </summary>
        //public async Task<CommentDto> BlockingComment(Guid id)
        //{
        //    var comment = await _commentRepository.GetNotBlockedCommentById(id);
        //    if (comment == null)
        //        return null;
        //    comment.UpdateCommentStatus(EStatus.Blocked);

        //    var save = await _commentRepository.SaveChangeCommentAsync();
        //    if (!save)
        //        return null;
        //    return comment.ToDto();
        //}

        /// <summary>
        /// دریافت کامنت های درحال انتظار یک تفریح با آیدی
        /// </summary>
        public async Task<List<CommentDto>> GetAllWaitingCommentsForFun(Guid id)
        {
            var funComments = await _commentRepository.GetAllWaitingCommentsForFun(id);
            if (funComments == null)
                return null;
            return funComments.ToDto();
        }

        /// <summary>
        /// دریافت کامنت های رد شده یک تفریح با آیدی
        /// </summary>
        public async Task<List<CommentDto>> GetAllDeclinedCommentsForFun(Guid id)
        {
            var funComments = await _commentRepository.GetAllDeclinedCommentsForFun(id);
            if (funComments == null)
                return null;
            return funComments.ToDto();
        }

        /// <summary>
        /// دریافت کامنت های بلاک شده یک تفریح با آیدی
        /// </summary>
        public async Task<List<CommentDto>> GetAllBlockedCommentsForFun(Guid id)
        {
            var funComments = await _commentRepository.GetAllBlockedCommentsForFun(id);
            if (funComments == null)
                return null;
            return funComments.ToDto();
        }
    }
}