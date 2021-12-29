using System;
using System.Collections.Generic;
using System.Text;
using Application.Validators.Schedule;
using Domain.Models;

namespace Application.Commands.Schedule
{
    public class AddSpecialOfferCommand : CommandBase
    {

        /// <summary>
        /// نام تفریح
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// آی دیه تفریح
        /// </summary>
        public Guid FunId { get; set; } 
        /// <summary>
        /// ساعت شروع سانس
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
        /// قیمت با تخفیف موجود
        /// </summary>
        public decimal Price { get; set; } //اینو وارد نکن خودش وارد میشه

        /// <summary>
        /// مقدار تخفیف
        /// </summary>
        public AddPercentCommand AddPercent { get; set; }

        public override bool Validate()
        {
            return new AddSpecialOfferCommandVlidator().Validate(this).IsValid;

        }
    }
}
