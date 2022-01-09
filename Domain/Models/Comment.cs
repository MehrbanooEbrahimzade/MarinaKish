using System;
using Domain.Enums;


namespace Domain.Models
{
    public class Comment : Writ
    {
        //public Comment(string text, Guid funId, string userPhoneNumber, string userName) : base(text, userName)
        //{
        //    Id = Guid.NewGuid();

        //    Text = text;

        //    FunId = funId;

        //    UserPhoneNumber = userPhoneNumber;

        //    UserName = userName;

        //    Status = Status.Waiting;

        //    SubmitDate = DateTime.Now;
        //}

        public Comment(string text, Guid funId, string userId, string fullname) : base(text, fullname)
        {
            Id = Guid.NewGuid();

            Text = text;

            FunId = funId;

            UserId = userId;

            Status = Status.Waiting;

            SubmitDate = DateTime.Now;

        }


        private Comment() : base() { }

        /// <summary>
        /// ای دیه کاربر
        /// </summary>
        public string UserId { get; private set; }

        /// <summary>
        /// ای دیه تفریح 
        /// </summary>
        public Guid FunId { get; private set; }

        /// <summary>
        /// وضعیت کامنت
        /// </summary>
        public Status Status { get; private set; }

        /// <summary>
        /// لایک
        /// </summary>
        public int Like { get; private set; }

        /// <summary>
        /// نپسندیدن
        /// </summary>
        public int DisLike { get; private set; }

        /// <summary>
        /// شماره تلفن کاربر
        /// </summary>
        public string UserPhoneNumber { get; private set; } //فعلا کاربردی توش ندیدم

        #region + -

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
            DisLike += 1;
        }

        public void Switching(Status status)
        {
            this.Status = status;
        }

        #endregion


    }
}
