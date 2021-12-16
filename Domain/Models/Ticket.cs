using System;
using Domain.Models.enums;

namespace Domain.Models
{
    public class Ticket
    {
        public Ticket(EFunType eFunType, DateTime scheduleTime, TimeSpan startTime, TimeSpan endTime, decimal discount, Guid itemId, string phoneNumber)
        {
            Id = Guid.NewGuid();
            EFunType = eFunType;
            ScheduleTime = scheduleTime;
            StartTime = startTime;
            EndTime = endTime;
            Discount = discount;
            ItemId = itemId;
            PhoneNumber = phoneNumber;
            Condition = ECondition.InActive;
            TicketNumber = GenerateTicketNumber();
            SubmitDate = DateTime.Now;
            WhereBuy = EWhereBuy.Site;
        }

        public Ticket() { }

        public Guid ItemId { get; private set; }

        /// <summary>
        /// ID
        /// </summary>
        public decimal Discount { get; private set; }

        /// <summary>
        /// شماره تلفن همراه
        /// </summary>
        public string PhoneNumber { get; private set; }

        /// <summary>
        /// تخفیف
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// نوع تفریح :
        /// </summary>
        public EFunType EFunType { get; private set; }
       
        /// <summary>
        /// زمان برگزاری سانس - به میلادی
        /// </summary>
        public DateTime ScheduleTime { get; private set; }

        /// <summary>
        /// زمان شروع
        /// </summary>
        public TimeSpan StartTime { get; private set; }

        /// <summary>
        /// زمان پایان
        /// </summary>
        public TimeSpan EndTime { get; private set; }

        /// <summary>
        /// شماره بلیط
        /// </summary>
        public string TicketNumber { get; private set; }


        /// <summary>
        /// آی دیه مدل تفریحات
        /// </summary>
        public Guid FunId { get; private set; }

        /// <summary>
        /// آی دیه مدل سانس ها
        /// </summary>
        public Guid ScheduleId { get; private set; }

        /// <summary>
        /// وضعیت
        /// </summary>
        public ECondition Condition { get; private set; }
        public void ConditionSet(ECondition eCondition)
        {
            Condition = eCondition;
        }


        /// <summary>
        /// زمان فروش بلیط
        /// </summary>
        public DateTime SubmitDate { get; private set; }

        /// <summary>
        /// کجا خریداری شده
        /// </summary>
        public EWhereBuy WhereBuy { get; private set; }
        public void WhereBuySet(EWhereBuy eWhereBuy)
        {
            WhereBuy = eWhereBuy;
        }

        public string GenerateTicketNumber()
        {
            var milisecond = DateTime.Now.Millisecond.ToString();
            var second = DateTime.Now.Second.ToString();
            var minute = DateTime.Now.Minute.ToString();
            var randomNumber = new Random().Next(1000, 9999).ToString();
            return "00" + milisecond + second + minute + randomNumber;
        }
    }
}
