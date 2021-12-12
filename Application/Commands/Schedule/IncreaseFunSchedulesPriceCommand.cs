using Application.Validators.Schedule;
using System;

namespace Application.Commands.Schedule
{
    public class IncreaseFunSchedulesPriceCommand : CommandBase
    {
        /// <summary>
        /// آیدی تفریح
        /// </summary>
        public Guid FunId { get; set; }

        /// <summary>
        /// قیمت افزایشی
        /// </summary>
        public decimal IncreasePrice { get; set; }

        public override bool Validate()
        {
            return new IncreaseFunSchedulesPriceCommandValidator().Validate(this).IsValid;
        }
    }
}
