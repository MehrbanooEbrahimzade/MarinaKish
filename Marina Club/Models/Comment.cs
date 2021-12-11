using System;
using Marina_Club.Models.enums;

namespace Marina_Club.Models
{
    public class Comment
    {
        public Comment(string message, Guid funId, Guid userId)
        {
            Message = message;
            FunId = funId;
            UserId = userId;
            Like = 0;
            DisLike = 0;
            Status = EStatus.Waiting;
            SubmitDate = DateTime.Now;
        }

        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// پیام :
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// وضعیت کامنت
        /// </summary>
        public EStatus Status { get; set; }

        /// <summary>
        /// لایک
        /// </summary>
        public int Like { get; set; }

        /// <summary>
        /// نپسندیدن
        /// </summary>
        public int DisLike { get; set; }

        /// <summary>
        /// زمان فرستادن کامنت
        /// </summary>
        public DateTime SubmitDate { get; set; }

        /// <summary>
        /// نوع تفریح
        /// </summary>
        public FunType FunType { get; set; }

        /// <summary>
        /// شناسه مدل تفریح :
        /// </summary>
        public Guid FunId { get; set; }

        /// <summary>
        /// نام کاربری
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// شماره تلفن کاربر
        /// </summary>
        public string UserCellPhone { get; set; }

        /// <summary>
        /// شناسه کاربری
        /// </summary>
        public Guid UserId { get; set; }

        private Comment() {  }
    }
}
