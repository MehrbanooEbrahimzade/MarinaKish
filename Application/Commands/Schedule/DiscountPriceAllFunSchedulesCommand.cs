using Application.Validators.Schedule;
using System;

namespace Application.Commands.Schedule
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
        public decimal Price { get; internal set; }

        public override bool Validate()
        {
            return new DiscountPriceAllFunSchedulesCommandValidator().Validate(this).IsValid;
        }
    }
}
