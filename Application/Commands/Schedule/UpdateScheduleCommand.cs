using System;
using System.Collections.Generic;
using System.Text;
using Application.Validators.Schedule;

namespace Application.Commands.Schedule
{
    public class UpdateScheduleCommand : CommandBase
    {

        /// <summary>
        ///  ساعت شروع سانس
        /// </summary>

        public Guid ScheduleId { get; set; }

        /// <summary>
        ///  ساعت شروع سانس
        /// </summary>
        public TimeSpan StartTime { get; set; }

        /// <summary>
        /// ساعت پایان سانس
        /// </summary>
        public TimeSpan EndTime { get; set; }

        /// <summary>
        ///  تاریخ سانس
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// قیمت
        /// </summary>
        public decimal Price { get; set; }


        public override bool Validate()
        {
            return new UpdateScheduleCommandValidator().Validate(this).IsValid;
        }
    }
}
