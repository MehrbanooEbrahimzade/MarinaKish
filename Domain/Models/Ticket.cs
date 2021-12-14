using System;
using Domain.Models.enums;

namespace Domain.Models
{
    public class Ticket
    {
        public Ticket(FunType funType, DateTime scheduleMiladiTime, TimeSpan startTime, TimeSpan endTime, int numberOfTicket)
        {
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
        public Guid Id { get; set; }

        /// <summary>
        /// شماره تلفن همراه
        /// </summary>
        public string CellPhone { get; set; }

        /// <summary>
        /// نام و نام خانوادگی
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// نوع تفریح :
        /// </summary>
        public enums.FunType FunType { get; set; }

        /// <summary>
        /// زمان برگزاری سانس - به میلادی
        /// </summary>
        public DateTime ScheduleMiladiTime { get; set; } // badan bhash ye harekatayi bznm //🎤عالی نواختی

        /// <summary>
        /// زمان شروع
        /// </summary>
        public TimeSpan StartTime { get; set; } 

        /// <summary>
        /// زمان پایان
        /// </summary>
        public TimeSpan EndTime { get; set; }

        /// <summary>
        /// شماره بلیط
        /// </summary>
        public string TicketNumber { get; set; }

        /// <summary>
        /// قیمت کل
        /// </summary>
        public decimal TotalPrice { get; set; }  //اینجا price باشه

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
        public Guid UserId { get; set; }  //حذف شه   //nationalid بیاد تو

        /// <summary>
        /// وضعیت
        /// </summary>
        public ECondition Condition { get; set; }

        /// <summary>
        /// تعداد بلیط
        /// </summary>
        public int NumberOfTicket { get; set; } //غلطه اسمش

        /// <summary>
        /// زمان فروش بلیط
        /// </summary>
        public DateTime SubmitDate { get; set; }

        /// <summary>
        /// کجا خریداری شده
        /// </summary>
        public EWhereBuy WhereBuy { get; set; }



        public string GenerateTicketNumber()
        {
            var milisecond = DateTime.Now.Millisecond.ToString();
            var second = DateTime.Now.Second.ToString();
            var minute = DateTime.Now.Minute.ToString();
            var randomNumber = new Random().Next(1000,9999).ToString();
            return "00" + milisecond + second + minute  + randomNumber;
        }

        private Ticket()
        {

        }
    }
}
