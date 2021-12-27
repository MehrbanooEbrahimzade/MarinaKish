using System;
using Domain.Enums;

namespace Domain.Models
{
    public class Ticket
    {
        public Ticket(string funType, WhereBuy whereBuy, Gender gender, User user, Schedule schedule)
        {
            this.Id = Guid.NewGuid();
            this.FunType = funType;
            this.Condition = Condition.Reservation;
            this.SubmitDate = DateTime.Now;
            this.WhereBuy = whereBuy;
            this.Gender = gender;
            this.User = user;
            this.Schedule = schedule;
        }

        private Ticket() { }
        public User User { get; private set; }
        public Schedule Schedule { get; private set; }

        public Guid Id { get; private set; }

        /// <summary>
        /// نوع تفریح :
        /// </summary>
        public string FunType { get; private set; }

        /// <summary>
        /// وضعیت
        /// </summary>
        public Condition Condition { get; private set; }

        /// <summary>
        /// زمان فروش بلیط
        /// </summary>
        public DateTime SubmitDate { get; private set; }

        /// <summary>
        /// کجا خریداری شده
        /// </summary>
        public WhereBuy WhereBuy { get; private set; }

        /// <summary>
        /// جنسیت
        /// </summary>
        public Gender Gender { get;private set; }
    }
}
