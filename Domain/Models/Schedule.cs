using System;

namespace Domain.Models
{
    public class Schedule
    {
        public Schedule
            (DateTime executeDate, TimeSpan startTime, TimeSpan endTime)
        {
            Id = Guid.NewGuid();
            StartTime = startTime;
            EndTime = endTime;
            ExecuteDate = executeDate;
            Discount = Percent.Empty;
            IsExist = true;
        }

        private Schedule() { }


        public Guid Id { get; private set; }

        /// <summary>
        /// تخفیف
        /// </summary>
        public Percent Discount { get; private set; }

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
        /// قیمت
        /// </summary>
        public decimal Price { get; private set; }

        /// <summary>
        /// وجود داشتن سانس 
        /// </summary>
        public bool IsExist { get; private set; }
    }

    public class Percent
    {

        public static Percent Empty => new Percent(0);

        public Percent(int value)
        {
            Validate(value);
            Value = value;
            Id=Guid.NewGuid();
        }

        public Guid Id { get; private set; }
        public int Value { get; private set; }


        public void Validate(int value)
        {
            if (value > 100 || value <= 0)
                throw new Exception();
        }



        public static Percent operator +(Percent p1, Percent p2)
        {
            return new Percent(p1.Value + p2.Value);
        }

    }
}
