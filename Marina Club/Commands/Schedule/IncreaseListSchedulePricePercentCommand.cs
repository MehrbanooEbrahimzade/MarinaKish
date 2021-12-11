using Marina_Club.Validators.Schedule;
using System;
using System.Collections.Generic;

namespace Marina_Club.Commands.Schedule
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

        public override bool Validate()
        {
            return new IncreaseListSchedulePricePercentCommandValidator().Validate(this).IsValid;
        }
    }
}
