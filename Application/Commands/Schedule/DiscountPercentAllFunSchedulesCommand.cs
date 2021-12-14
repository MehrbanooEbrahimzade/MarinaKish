using Application.Validators.Schedule;
using System;

namespace Application.Commands.Schedule
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

        /// <summary>
        /// قیمت تفریح
        /// </summary>
        public decimal Price { get; set; }

        public override bool Validate()
        {
            return new DiscountPercentAllFunSchedulesCommandValidator().Validate(this).IsValid;
        }
    }
}
