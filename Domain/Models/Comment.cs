using System;
using Domain.Models.enums;

namespace Domain.Models
{
    public class Comment
    {
        public Comment(string message, Guid funId, Guid userId
            , FunType funtype , string usercellphone
            ,string username)
        {
            Id = Guid.NewGuid(); 
            Message = message;
            FunId = funId;
            UserId = userId;
            FunType = funtype;
            UserCellPhone = usercellphone;
            UserName = username; 
            Like = 0;
            DisLike = 0;
            Status = EStatus.Waiting;
            SubmitDate = DateTime.Now;
        }

        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// پیام :
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// وضعیت کامنت
        /// </summary>
        public EStatus Status { get; private set; }

        /// <summary>
        /// لایک
        /// </summary>
        public int Like { get; private set; }

        /// <summary>
        /// نپسندیدن
        /// </summary>
        public int DisLike { get; private set; }

        /// <summary>
        /// زمان فرستادن کامنت
        /// </summary>
        public DateTime SubmitDate { get; private set; }

        /// <summary>
        /// نوع تفریح
        /// </summary>
        public FunType FunType { get; private set; }

        /// <summary>
        /// شناسه مدل تفریح :
        /// </summary>
        public Guid FunId { get; private set; }

        /// <summary>
        /// نام کاربری
        /// </summary>
        public string UserName { get; private set; }

        /// <summary>
        /// شماره تلفن کاربر
        /// </summary>
        public string UserCellPhone { get; private set; }

        /// <summary>
        /// شناسه کاربری
        /// </summary>
        public Guid UserId { get; private set; }

        /// <summary>
        /// آپدیت کردن Status کامنت 
        /// </summary>
        /// <param name="status"></param>
        public void UpdateCommentStatus(EStatus status)
        {
            this.Status = status;
        }

        /// <summary>
        /// آپدیت لایک ها 
        /// </summary>
        /// <param name="like"></param>
        public void UpdateCommentLikes(int like)
        {
            this.Like += like; 
        }

        /// <summary>
        /// کاهش تعداد لایک ها 
        /// </summary>
        public void UpdateCommentDislikes(int dislike)
        {
            this.Like -= dislike;
        }
        public  Comment() {  }
    }
}
