using System;
using Domain.Models.enums;

namespace Application.Dtos
{
    public class TicketDto
    {
        /// <summary>
        /// ID 
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// نوع تفریح :
        /// </summary>
        public FunType FunType { get; set; }

        /// <summary>
        /// شماره تلفن همراه
        /// </summary>
        public string CellPhone { get; set; }

        /// <summary>
        /// نام و نام خانوادگی
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// زمان برگزاری
        /// </summary>
        public string ExecutePersianDate { get; set; }

        /// <summary>
        /// زمان شروع
        /// </summary>
        public TimeSpan StartTime { get; set; }

        /// <summary>
        /// زمان پایان
        /// </summary>
        public TimeSpan EndTime { get; set; }

        /// <summary>
        /// قیمت کل
        /// </summary>
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// زمان فروش بلیط - به شمسی
        /// </summary>
        public string SubmitPersianDate { get; set; }

        /// <summary>
        /// شماره بلیط
        /// </summary>
        public string TicketNumber { get; set; }

        /// <summary>
        /// وضعیت
        /// </summary>
        public ECondition Condition { get; set; }

        /// <summary>
        /// آی دیه مدل تفریحات
        /// </summary>
        public Guid FunId { get; set; }

        /// <summary>
        /// آی دیه مدل سانس ها
        /// </summary>
        public Guid ScheduleId { get; set; }

        /// <summary>
        /// آیدی کاربر
        /// </summary>
        public Guid UserId { get; set; }
    }
}
