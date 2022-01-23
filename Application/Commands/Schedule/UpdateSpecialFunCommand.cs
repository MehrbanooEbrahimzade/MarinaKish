using System;

namespace Application.Commands.Schedule
{
    public class UpdateSpecialFunCommand
    {
        /// <summary>
        /// آی دیه سانس
        /// </summary>
        public Guid ShceduleId { get; set; }

        /// <summary>
        /// قیمت با تخفیف موجود
        /// </summary>
        public decimal Price { get; set; } //اینو وارد نکن خودش وارد میشه

        /// <summary>
        /// مقدار تخفیف
        /// </summary>
        public AddPercentCommand AddPercent { get; set; }
    }
}
