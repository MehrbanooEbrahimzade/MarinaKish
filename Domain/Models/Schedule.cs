using System;

namespace Domain.Models
{
    public class Schedule
    {
        public Schedule
            (DateTime date, TimeSpan start, TimeSpan end, decimal price)
        {
            Price = price;
            Id = Guid.NewGuid();
            Start = AddTimeToDate(start, date);
            End = AddTimeToDate(end, date);
            Discount = Percent.Empty;
            IsExist = true;
        }

        private Schedule() { }

        public DateTime AddTimeToDate(TimeSpan time , DateTime date)
        {
            return date.Add(time);
        }

        public Guid Id { get; private set; }

        /// <summary>
        /// تخفیف
        /// </summary>
        public Percent Discount { get; private set; }

        /// <summary>
        ///  شروع سانس
        /// </summary>
        public DateTime Start { get; private set; }

        /// <summary>
        /// پایان سانس
        /// </summary>
        public DateTime End { get; private set; }

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
            if (value > 100 || value < 0)
                throw new Exception();
        }



        public static Percent operator +(Percent p1, Percent p2)
        {
            return new Percent(p1.Value + p2.Value);
        }

    }
}
