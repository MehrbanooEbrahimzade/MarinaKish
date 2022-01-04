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
        /// آی دیه سانس
        /// </summary>
        public Guid ShceduleId { get; set; }

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
