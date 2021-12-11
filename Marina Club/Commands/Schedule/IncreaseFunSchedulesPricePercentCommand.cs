using Marina_Club.Validators.Schedule;
using System;

namespace Marina_Club.Commands.Schedule
{
    public class IncreaseFunSchedulesPricePercentCommand : CommandBase
    {
        /// <summary>
        /// آیدی تفریح
        /// </summary>
        public Guid FunId { get; set; }

        /// <summary>
        /// درصد قیمت افزایشی
        /// </summary>
        public decimal IncreasePricePercent { get; set; }

        public override bool Validate()
        {
            return new IncreaseFunSchedulesPricePercentCommandValidator().Validate(this).IsValid;
        }
    }
}
