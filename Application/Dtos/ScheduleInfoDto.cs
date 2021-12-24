using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos
{
    public class ScheduleInfoDto
    {
        public Guid Id { get; set; }

        /// <summary>
        /// ساعت شروع سانس ها
        /// </summary>
        public TimeSpan StartTime { get; set; }

        /// <summary>
        /// ساعت پایان سانس ها
        /// </summary>
        public TimeSpan EndTime { get; set; }

        /// <summary>
        /// زمان استراحت هر سانس
        /// </summary>
        public int GapTime { get; set; }

        /// <summary>
        /// مدت زمان هر سانس 
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// ظرفیت کل 
        /// </summary>
        public int TotalCapacity { get; set; }

        /// <summary>
        /// ظرفیت فروش حضوری
        /// </summary>
        public int PresenceCapacity { get; set; }

        /// <summary>
        /// ظرفیت فروش مجازی
        /// </summary>
        public int OnlineCapacity { get; set; }

        /// <summary>
        /// قیمت
        /// </summary>
        public decimal Amount { get; set; }
    }
}
