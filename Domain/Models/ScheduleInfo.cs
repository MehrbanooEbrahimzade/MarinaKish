using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class ScheduleInfo
    {
        public ScheduleInfo(TimeSpan startTime, TimeSpan endTime, int gapTime, int duration,
            int totalCapacity, int presenceCapacity, int onlineCapacity, decimal amount)
        {
            Id = Guid.NewGuid();
            StartTime = startTime;
            EndTime = endTime;
            GapTime = gapTime;
            Duration = duration;
            TotalCapacity = totalCapacity;
            PresenceCapacity = presenceCapacity;
            OnlineCapacity = onlineCapacity;
            Amount = amount;
        }

        public Guid Id { get; private set; }

        /// <summary>
        /// ساعت شروع سانس ها
        /// </summary>
        public TimeSpan StartTime { get; private set; }

        /// <summary>
        /// ساعت پایان سانس ها
        /// </summary>
        public TimeSpan EndTime { get; private set; }

        /// <summary>
        /// زمان استراحت هر سانس
        /// </summary>
        public int GapTime { get; private set; }

        /// <summary>
        /// مدت زمان هر سانس 
        /// </summary>
        public int Duration { get; private set; }

        /// <summary>
        /// ظرفیت کل 
        /// </summary>
        public int TotalCapacity { get; private set; }

        /// <summary>
        /// ظرفیت فروش حضوری
        /// </summary>
        public int PresenceCapacity { get; private set; }

        /// <summary>
        /// ظرفیت فروش مجازی
        /// </summary>
        public int OnlineCapacity { get; private set; }

        /// <summary>
        /// قیمت
        /// </summary>
        public decimal Amount { get;private set; }


        public void UpdateScheduleInfo(TimeSpan startTime, TimeSpan endTime, int gapTime, int duration,
             int totalCapacity, int presenceCapacity, int onlineCapacity, decimal amount)
        {
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.GapTime = gapTime;
            this.Duration = duration;
            this.TotalCapacity = totalCapacity;
            this.PresenceCapacity = presenceCapacity;
            this.OnlineCapacity = onlineCapacity;
            this.Amount = amount;
        }
        private ScheduleInfo()
        {
        }
    }
}