using Domain.Models.enums;
using System;

namespace Domain.Models
{
    public class Schedule
    {
        public Schedule
            (enums.FunType funType, DateTime executeDateTime, decimal price,
            decimal availableCapacity, TimeSpan startTime, TimeSpan endTime)
        {
            Id = Guid.NewGuid();
            SystemFunCode = GenerateScheduleCode();
            FunType = funType;
            ExecuteDateTime = executeDateTime;
            Price = price;
            AvailableCapacity = availableCapacity;
            StartTime = startTime;
            EndTime = endTime;
            IsExist = true;
        }

        /// <summary>
        /// ID
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// آی دیه مدل Fun :
        /// </summary>
        public string SystemFunCode { get;private  set; }

        /// <summary>
        /// تنوع تفریح ها :
        /// </summary> 
        public FunType FunType { get; private set; }

        /// <summary>
        /// زمان سانس : - به میلادی
        /// </summary>
        public DateTime ExecuteDateTime { get; private set; }
        
        /// <summary>
        /// قیمت تفریح :
        /// </summary>
        public decimal Price { get; private set; }
        
        /// <summary>
        /// فضای دردسترس :
        /// </summary>
        public decimal AvailableCapacity { get; private set; }
        
        /// <summary>
        /// چک کننده ی وجود داشتن سانس :
        /// </summary>
        public bool IsExist { get; set; }
        
        /// <summary>
        /// ساعت شروع :
        /// </summary>
        public TimeSpan StartTime { get; private set; }
        
        /// <summary>
        /// ساعت پایان :
        /// </summary>
        public TimeSpan EndTime { get; private set; }

        /// <summary>
        /// آیدی تفریح
        /// </summary>
        public Guid FunId { get; private set; }//TODO:CHANGE
        public void FunTypeSet(FunType funType)
        {
            this.FunType = funType;
        }

        public string GenerateScheduleCode()
        {
            var millisecond = DateTime.Now.Millisecond.ToString();
            var randomCode = new Random().Next(10000, 99999).ToString();
            return millisecond  + "" + randomCode; 
        }

        public Schedule()
        {
        }
    }
}
