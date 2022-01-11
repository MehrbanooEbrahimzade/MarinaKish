using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Application.Commands.Comment;
using Application.Dtos;
using Application.Mappers;
using Application.Services.interfaces;
using Domain.Models;
using Domain.RepasitoryInterfaces;
using Domain.Enums;
using Domain.IConfiguration;
using Microsoft.Extensions.Logging;

namespace Application.Services.classes
{

    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public CommentService(ILogger<CommentService> logger, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;

        }

        /// <summary>
        /// اضافه کردن کامنت
        /// </summary>
        public async Task<CommentDto> AddCommentToFun(AddCommentCommand command)
        {
            var user = await _unitOfWork.Users.GetUserById(command.UserId);//اینو بنداز روی یونیت اف ورگ
            if (user == null)
                throw new NullReferenceException("چنین کاربری یافت نشد");

            var fun = await _unitOfWork.Funs.GetActiveFunByIdAsynch(command.FunId); //اینو بنداز روی یونیت اف ورگ
            if (fun == null)
                throw new NullReferenceException("چنین تفریحی یافت نشد");

            command.FullName = user.FullName;
            var commentObj = new Comment(command.Message, command.FunId, command.UserId, command.FullName);

            var addCommentResult = await _unitOfWork.comment.AddAsync(commentObj);
            if (addCommentResult == false)
                throw new Exception("عملیات ادد انجام نشد");

            await _unitOfWork.CompleteAsync();

            return commentObj.ToDto();
        }

        /// <summary>
        /// تایید شدن لیستی از کامنت ها
        /// </summary>
        public async Task<bool> OkStatusCommentList(ChangeStatusCommentListCommand command)
        {
            foreach (var guid in command.IDs)
            {
                var comment = await _unitOfWork.comment.GetByIdAsync(guid);
                if (comment == null)
                    throw new Exception("چنین کامنتی یافت نشد");

                comment.Switching(Status.Accepted);
            }
            await _unitOfWork.CompleteAsync();
            return true;
        }

        /// <summary>
        /// تایید نشدن لیستی از کامنت ها
        /// </summary>
        public async Task<bool> NotOkStatusCommentList(ChangeStatusCommentListCommand command)
        {
            foreach (var guid in command.IDs)
            {
                var comment = await _unitOfWork.comment.GetByIdAsync(guid);
                if (command == null)
                    throw new Exception(" کامنت یا یکی از کامت های ورودی یافت نشد");

                comment.Switching(Status.Declined);
            }
            await _unitOfWork.CompleteAsync();
            return true;
        }



        /// <summary>
        /// گرفتن همه کامنت های  یک تفریح با حالات مختلف
        /// </summary>
        public async Task<List<CommentDto>> GetAllAcceptedCommentsForFun(GetAllCommand command)
        {
            var comments = await _unitOfWork.comment.GetFunCommentsByStatus(command.Funid, command.status); //یونیت اف ورک اینو میتونی بسازی
            if (comments == null)
                throw new Exception("کامنتی با چنین ایدیی یافت نشد");

            return comments.ToDto();
        }

        /// <summary>
        /// افزایش لایک کامنت
        /// </summary>
        public async Task<bool> IncreaseLikeComment(Guid id)
        {
            var comment = await _unitOfWork.comment.GetByIdAsync(id);
            if (comment == null)
                throw new Exception("چنین کامنتی یافت نشد");

            comment.UpdateCommentLikes();
            await _unitOfWork.CompleteAsync();
            return true;
        }

        /// <summary>
        /// کاهش لایک کامنت
        /// </summary>
        public async Task<bool> DecreaseLikeComment(Guid id)
        {
            var comment = await _unitOfWork.comment.GetByIdAsync(id);
            if (comment == null)
                throw new Exception("چنین کامنتی یافت نشد");

            comment.UpdateCommentDislikes();
            await _unitOfWork.CompleteAsync();
            return true;
        }



        //        /// <summary>
        //        /// تغییر وضعیت دادن یک کامنت با آیدی
        //        /// </summary>
        //        public async Task<CommentDto> ChangeStatusComment(Guid id, Status status)
        //        {
        //            var comment = await _commentRepository.GetById(id);

        //            if (comment == null)
        //                return null;
        //            comment.SetStatus(status);

        //            var save = await _commentRepository.SaveChangeAsync();
        //            if (!save)
        //                return null;
        //            return comment.ToDto();
        //        }


        //        /// <summary>
        //        /// دریافت کامنت های یک وضعیت خاص یک تفریح با فان آیدی
        //        /// </summary>
        //        public async Task<List<CommentDto>> GetAllCommentsForFunWithStatus(Guid funId, Status status)
        //        {
        //            var funComments = await _commentRepository.GetFunCommentsByStatus(funId,status);

        //            return funComments?.ToDto();
        //        }
    }
}