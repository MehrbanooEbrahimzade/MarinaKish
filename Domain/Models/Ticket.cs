using System;
using Domain.Enums;

namespace Domain.Models
{
    public class Ticket
    {
        public Ticket(FunType funType, DateTime scheduleTime, TimeSpan startTime, TimeSpan endTime, decimal discount, Guid itemId, string phoneNumber)
        {
            Id = Guid.NewGuid();
            EFunType = funType;
            ScheduleTime = scheduleTime;
            StartTime = startTime;
            EndTime = endTime;
            Discount = discount;
            ItemId = itemId;
            PhoneNumber = phoneNumber;
            ECondition = Condition.InActive;
            TicketNumber = GenerateTicketNumber();
            SubmitDate = DateTime.Now;
            EWhereBuy = WhereBuy.Site;
        }

        private Ticket() { }

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
        public FunType EFunType { get; private set; }
       
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
        public Condition ECondition { get; private set; }
        public void ConditionSet(Condition condition)
        {
            ECondition = condition;
        }


        /// <summary>
        /// زمان فروش بلیط
        /// </summary>
        public DateTime SubmitDate { get; private set; }

        /// <summary>
        /// کجا خریداری شده
        /// </summary>
        public WhereBuy EWhereBuy { get; private set; }
        public void WhereBuySet(WhereBuy whereBuy)
        {
            EWhereBuy = whereBuy;
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
