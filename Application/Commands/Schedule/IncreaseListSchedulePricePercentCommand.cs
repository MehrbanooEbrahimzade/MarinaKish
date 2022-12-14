using Application.Validators.Schedule;
using System;
using System.Collections.Generic;

namespace Application.Commands.Schedule
{
    public class IncreaseListSchedulePricePercentCommand : CommandBase
    {
        /// <summary>
        /// آیدی ها
        /// </summary>
        public List<Guid> IDs { get; set; }

        /// <summary>
        /// درصد قیمت افزایشی
        /// </summary>
        public decimal IncreasePricePercent { get; set; }
        public decimal Price { get; internal set; }

        public override bool Validate()
        {
            return new IncreaseListSchedulePricePercentCommandValidator().Validate(this).IsValid;
        }
    }
}
