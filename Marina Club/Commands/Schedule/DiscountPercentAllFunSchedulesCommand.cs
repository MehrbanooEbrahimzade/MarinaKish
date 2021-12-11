using Marina_Club.Validators.Schedule;
using System;

namespace Marina_Club.Commands.Schedule
{
    public class DiscountPercentAllFunSchedulesCommand : CommandBase
    {
        /// <summary>
        /// آیدی تفریح
        /// </summary>
        public Guid FunId { get; set; }

        /// <summary>
        /// درصد تخفیف
        /// </summary>
        public decimal DiscountPercent { get; set; }

        public override bool Validate()
        {
            return new DiscountPercentAllFunSchedulesCommandValidator().Validate(this).IsValid;
        }
    }
}
