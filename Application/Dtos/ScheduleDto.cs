using System;
using Domain.Models.enums;

namespace Application.Dtos
{
    public class ScheduleDto
    {
        /// <summary>
        /// ID 
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// تنوع تفریح ها :
        /// </summary> 
        public EFunType EFunType { get; set; }

        /// <summary>
        /// زمان سانس : - به شمسی
        /// </summary>
        public string ExcutePersianDateTime { get; set; }

        /// <summary>
        /// قیمت تفریح :
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// فضای دردسترس :
        /// </summary>
        public decimal AvailableCapacity { get; set; }

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
    }
}
