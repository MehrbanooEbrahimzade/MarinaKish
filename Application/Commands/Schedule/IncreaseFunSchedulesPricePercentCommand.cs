using Application.Validators.Schedule;
using System;

namespace Application.Commands.Schedule
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
