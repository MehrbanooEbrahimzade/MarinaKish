using System;
using Domain.Models.enums;

namespace Domain.Models
{
    public class Ticket
    {
        public Ticket
           (FunType funType, DateTime scheduleMiladiTime, TimeSpan startTime, TimeSpan endTime, int numberOfTicket)
        {
            Id = Guid.NewGuid();
            FunType = funType;
            ScheduleMiladiTime = scheduleMiladiTime;
            StartTime = startTime;
            EndTime = endTime;
            Condition = ECondition.InActive;
            NumberOfTicket = numberOfTicket;
            TicketNumber = GenerateTicketNumber();
            SubmitDate = DateTime.Now;
            WhereBuy = EWhereBuy.Site;
        }

        /// <summary>
        /// ID
        /// </summary>
        public Guid Id { get;private set; }

        /// <summary>
        /// شماره تلفن همراه
        /// </summary>
        public string CellPhone { get; private set; }

        /// <summary>
        /// نام و نام خانوادگی
        /// </summary>
        public string FullName { get; private set; }

        /// <summary>
        /// نوع تفریح :
        /// </summary>
        public FunType FunType { get; private set; }
        public void FunTypeSet(FunType funType)
        {
            this.FunType = funType;
        }

        /// <summary>
        /// زمان برگزاری سانس - به میلادی
        /// </summary>
        public DateTime ScheduleMiladiTime { get; private set; } // badan bhash ye harekatayi bznm

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
        /// قیمت کل
        /// </summary>
        public decimal TotalPrice { get; private set; }
      
        /// <summary>
        /// آی دیه مدل تفریحات
        /// </summary>
        public Guid FunId { get; private set; }

        /// <summary>
        /// آی دیه مدل سانس ها
        /// </summary>
        public Guid ScheduleId { get; private set; }

        /// <summary>
        /// آیدی کاربر
        /// </summary>
        public Guid UserId { get; private set; }

        /// <summary>
        /// وضعیت
        /// </summary>
        public ECondition Condition { get; private set; }
        public void ConditionSet(ECondition eCondition)
        {
            this.Condition = eCondition;
        }

        /// <summary>
        /// تعداد بلیط
        /// </summary>
        public int NumberOfTicket { get; private set; }

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
            this.WhereBuy = eWhereBuy;
        }

        public string GenerateTicketNumber()
        {
            var milisecond = DateTime.Now.Millisecond.ToString();
            var second = DateTime.Now.Second.ToString();
            var minute = DateTime.Now.Minute.ToString();
            var randomNumber = new Random().Next(1000,9999).ToString();
            return "00" + milisecond + second + minute  + randomNumber;
        }

        public Ticket()
        {
        }
    }
}
