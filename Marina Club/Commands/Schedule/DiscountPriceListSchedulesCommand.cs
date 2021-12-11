using System;
using System.Collections.Generic;
using Marina_Club.Validators.Schedule;

namespace Marina_Club.Commands.Schedule
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

        public override bool Validate()
        {
            return new DiscountPriceListSchedulesCommandValidator().Validate(this).IsValid;
        }
    }
}
