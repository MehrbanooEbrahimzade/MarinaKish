using System;
using Domain.Enums;

namespace Domain.Models
{
    public class Schedule
    {
        public Schedule
            ( DateTime executeDate, TimeSpan startTime, TimeSpan endTime, Gender gender)
        {
            Id = Guid.NewGuid();
            
            EGender = gender;
            
            StartTime = startTime;
            
            EndTime = endTime;

            ExecuteDate = executeDate;

            Discount = default;

            IsExist = true;
        }

        private Schedule() { }


        public Guid Id { get; private set; }

        /// <summary>
        /// جنسیت
        /// </summary>
        public Gender EGender { get; private set; }

        /// <summary>
        /// تخفیف
        /// </summary>
        public decimal? Discount { get; private set; } 

        /// <summary>
        /// ساعت شروع سانس
        /// </summary>
        public TimeSpan StartTime { get; private set; }

        /// <summary>
        /// ساعت پایان سانس
        /// </summary>
        public TimeSpan EndTime { get; private set; }

        /// <summary>
        /// تاریخ سانس
        /// </summary>
        public DateTime ExecuteDate { get; private set; }

        /// <summary>
        /// وجود داشتن سانس 
        /// </summary>
        public bool IsExist { get; private set; }

    }
}
