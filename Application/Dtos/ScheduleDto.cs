using System;
using Domain.Enums;
using Domain.Models;

namespace Application.Dtos
{
    public class ScheduleDto
    {
        /// <summary>
        /// commentId 
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// تاریخ سانس 
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// قیمت تفریح :
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// ساعت شروع :
        /// </summary>
        public TimeSpan StartTime { get; set; }

        /// <summary>
        /// ساعت پایان :
        /// </summary>
        public TimeSpan EndTime { get; set; }

        /// <summary>
        /// آیدی تفریح
        /// </summary>
        public Guid FunId { get; set; }

        /// <summary>
        /// تخفیف
        /// </summary>
        public Percent Discount{ get; set; }

        /// <summary>
        /// عدد روز هفته
        /// </summary>
        public int? DayOfWeek { get; set; }
    }
}
