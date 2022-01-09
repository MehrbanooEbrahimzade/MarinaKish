﻿using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Application.Commands.Comment;
using Application.Dtos;
using Application.Mappers;
using Application.Services.interfaces;
using Domain.Models;
using Domain.RepasitoryInterfaces;

namespace Application.Services.classes
{

    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IUserRepository _userRepository;
        private readonly IFunRepository _funRepository;


        public CommentService(ICommentRepository commentRepository, IUserRepository userRepository, IFunRepository funRepository)
        {
            _commentRepository = commentRepository;
            _userRepository = userRepository;
            _funRepository = funRepository;
        }

        /// <summary>
        /// اضافه کردن کامنت
        /// </summary>
        public async Task<CommentDto> AddCommentToFun(AddCommentCommand command)
        {
            var user = await _userRepository.GetUserById(command.UserId);
            if (user == null)
                throw new NullReferenceException("چنین کاربری یافت نشد");

            var fun = await _funRepository.GetActiveFunByIdAsynch(command.FunId);
            if (fun == null)
                throw new NullReferenceException("چنین تفریحی یافت نشد");


            var commentObj = new Comment(command.Message, command.FunId,command.UserId,command.FullName);

            var addCommentResult = await _commentRepository.AddAsync(commentObj);

            if (!addCommentResult)
                return null;
            return commentObj.ToDto();

        }

        //        /// <summary>
        //        /// تایید شدن یا نشدن کامنت
        //        /// </summary>
        //        public async Task<bool> ChangeCommentStatus(ChangeCommentStatusCommand command)
        //        {
        //            var comment = await _commentRepository.GetById(command.Id);
        //            comment.SetStatus(command.Status);

        //            return await _commentRepository.SaveChangeAsync();
        //        }


        //        /// <summary>
        //        /// تایید شدن یا نشدن لیستی از کامنت ها
        //        /// </summary>
        //        public async Task<bool> ChangeStatusCommentList(ChangeStatusCommentListCommand command)
        //        {
        //            foreach (var guid in command.IDs)
        //            {
        //                var comment = await _commentRepository.GetById(guid);
        //                comment.SetStatus(command.Status);
        //            }
        //            return await _commentRepository.SaveChangeAsync();
        //        }

        //        /// <summary>
        //        /// گرفتن همه کامنت های قبول شده برای یک تفریح
        //        /// </summary>
        //        public async Task<List<CommentDto>> GetAllAcceptedCommentsForFun(Guid funId, Status status)
        //        {
        //            var comments = await _commentRepository.GetFunCommentsByStatus(funId, status);

        //            return comments?.ToDto();
        //        }

        //        /// <summary>
        //        /// افزایش لایک کامنت
        //        /// </summary>
        //        public async Task<bool> IncreaseLikeComment(Guid id)
        //        {
        //            var comment = await _commentRepository.GetById(id);
        //            if (comment == null)
        //                return false;

        //            comment.UpdateCommentLikes();
        //            return await _commentRepository.SaveChangeAsync();
        //        }
        //        //این دو متد مشابه (لایک) باهم  ترکیب شوند!!

        //        /// <summary>
        //        /// کاهش لایک کامنت
        //        /// </summary>
        //        public async Task<bool> DecreaseLikeComment(Guid id)
        //        {
        //            var comment = await _commentRepository.GetById(id);
        //            if (comment == null)
        //                return false;

        //            comment.UpdateCommentDislikes();
        //            return await _commentRepository.SaveChangeAsync();
        //        }

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