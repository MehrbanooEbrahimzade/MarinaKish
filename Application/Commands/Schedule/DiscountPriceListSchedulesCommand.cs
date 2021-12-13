using System;
using System.Collections.Generic;
using Application.Validators.Schedule;

namespace Application.Commands.Schedule
{
    public class DiscountPriceListSchedulesCommand : CommandBase
    {
        /// <summary>
        /// آیدی ها
        /// </summary>
        public List<Guid> IDs { get; set; }

        /// <summary>
        /// قیمت تخفیف
        /// </summary>
        public decimal DiscountPrice { get; set; }
        public decimal Price { get; internal set; }

        public override bool Validate()
        {
            return new DiscountPriceListSchedulesCommandValidator().Validate(this).IsValid;
        }
    }
}
