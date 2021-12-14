using Application.Validators.Schedule;
using System;
using System.Collections.Generic;

namespace Application.Commands.Schedule
{
    public class DiscountPercentListSchedulesCommand : CommandBase
    {
        /// <summary>
        /// آیدی ها
        /// </summary>
        public List<Guid> IDs { get; set; }

        /// <summary>
        /// درصد تخفیف
        /// </summary>
        public decimal DiscountPercent { get; set; }
        public decimal Price { get; internal set; }

        public override bool Validate()
        {
            return new DiscountPercentScheduleCommandValidator().Validate(this).IsValid;
        }
    }
}
