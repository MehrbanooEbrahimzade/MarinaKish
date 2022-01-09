using System;
using Domain.Enums;

namespace Application.Dtos
{
    public class CommentDto
    { 
        /// <summary>
        /// commentId 
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// پیام :
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// وضعیت کامنت
        /// </summary>
        public Status Status { get; set; }

        /// <summary>
        /// لایک
        /// </summary>
        public int Like { get; set; }

        /// <summary>
        /// نپسندیدن
        /// </summary>
        public int DisLike { get; set; }

        /// <summary>
        /// زمان فرستادن کامنت - به شمسی
        /// </summary>
        public string SubmitDate { get; set; }

        /// <summary>
        /// نوع تفریح
        /// </summary>
        public FunType FunType { get; set; }

        /// <summary>
        /// شناسه مدل تفریح :
        /// </summary>
        public Guid FunId { get; set; }

        /// <summary>
        /// نام کاربر
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// شناسه کاربری
        /// </summary>
        public Guid UserId { get; set; }
    }
}
