using System;

namespace Marina_Club.Models
{
    public class Schedule
    {
        public Schedule(string systemFunCode, enums.FunType funType, DateTime excuteMiladiDateTime, decimal price, TimeSpan startTime, TimeSpan endTime)
        {
            SystemFunCode = systemFunCode;
            FunType = funType;
            ExcuteMiladiDateTime = excuteMiladiDateTime;
            Price = price;
            StartTime = startTime;
            EndTime = endTime;
            IsExist = true;
        }

        /// <summary>
        /// ID
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// آی دیه مدل Fun :
        /// </summary>
        public string SystemFunCode { get; set; }

        /// <summary>
        /// تنوع تفریح ها :
        /// </summary> 
        public enums.FunType FunType { get; set; }

        /// <summary>
        /// زمان سانس : - به میلادی
        /// </summary>
        public DateTime ExcuteMiladiDateTime { get; set; }
        
        /// <summary>
        /// قیمت تفریح :
        /// </summary>
        public decimal Price { get; set; }
        
        /// <summary>
        /// فضای دردسترس :
        /// </summary>
        public decimal AvailableCapacity { get; set; }
        
        /// <summary>
        /// چک کننده ی وجود داشتن سانس :
        /// </summary>
        public bool IsExist { get; set; }
        
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

        private Schedule()
        {

        }
    }
}
