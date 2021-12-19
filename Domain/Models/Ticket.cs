using System;
using Domain.Enums;

namespace Domain.Models
{
    public class Ticket
    {
        public Ticket(string funType, string phoneNumber, WhereBuy whereBuy, Gender gender)
        {
            Id = Guid.NewGuid();
            FunType = funType;
            Condition = Condition.Reservation;
            SubmitDate = DateTime.Now;
            WhereBuy = whereBuy;
            Gender = gender;
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
