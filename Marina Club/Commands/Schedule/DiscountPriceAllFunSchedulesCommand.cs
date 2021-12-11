using Marina_Club.Validators.Schedule;
using System;

namespace Marina_Club.Commands.Schedule
{
    public class DiscountPriceAllFunSchedulesCommand : CommandBase
    {
        /// <summary>
        /// آیدی تفریح
        /// </summary>
        public Guid FunId { get; set; }

        /// <summary>
        /// قیمت تخفیف
        /// </summary>
        public decimal DiscountPrice { get; set; }

        public override bool Validate()
        {
            return new DiscountPriceAllFunSchedulesCommandValidator().Validate(this).IsValid;
        }
    }
}
