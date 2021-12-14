using System;
using Domain.Models.enums;

namespace Domain.Models
{
    public class Comment: Writing
    {
        public Comment(string text, Guid funId, Guid userId, FunType funType , string userPhoneNumber,string username)
        {
            Id = Guid.NewGuid(); 
            Text = text;
            FunId = funId;
            UserId = userId;
            FunType = funType;
            UserPhoneNumber = userPhoneNumber;
            UserName = username; 
            Like = 0;
            DisLike = 0;
            Status = EStatus.Waiting;
            SubmitDate = DateTime.Now;
        }
        
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
        /// نوع تفریح
        /// </summary>
        public FunType FunType { get; private set; }

        /// <summary>
        /// شناسه مدل تفریح :
        /// </summary>
        public Guid FunId { get; private set; }

        /// <summary>
        /// شماره تلفن کاربر
        /// </summary>
        public string UserPhoneNumber { get; private set; }

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

        #region Methods

        /// <summary>
        /// افزایش تعداد لایک ها 
        /// </summary>
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

        #endregion
      

        public  Comment() {  }
    }
}
