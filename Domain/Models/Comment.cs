using System;
using System.Collections.Generic;
using Domain.Models.enums;

namespace Domain.Models
{
    public class Comment: Writing
    {
        public Comment(string text, Guid funId , string userPhoneNumber,string userName)
        {
            Id = Guid.NewGuid(); 
            Text = text;
            FunId = funId;
            UserPhoneNumber = userPhoneNumber;
            UserName = userName;
            Status= EStatus.Waiting;
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
        /// شناسه مدل تفریح 
        /// </summary>
        public Guid FunId { get; private set; }

        /// <summary>
        /// شماره تلفن کاربر
        /// </summary>
        public string UserPhoneNumber { get; private set; }


        #region SetMethod

        /// <summary>
        /// آپدیت کردن Status کامنت 
        /// </summary>
        public void SetStatus(EStatus status)
        {
            this.Status = status;
        }


        #endregion

        #region Methods

        /// <summary>
        /// افزایش تعداد لایک ها 
        /// </summary>
        public void UpdateCommentLikes()
        {
            this.Like += 1;
        }

        /// <summary>
        /// کاهش تعداد لایک ها 
        /// </summary>
        public void UpdateCommentDislikes()
        {
            this.Like -= 1;
        }

        #endregion
      

        public Comment() {  }
    }
}
