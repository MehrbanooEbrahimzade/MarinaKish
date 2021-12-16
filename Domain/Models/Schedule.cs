using Domain.Models.enums;
using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Schedule
    {
        public Schedule
            (EFunType eFunType, DateTime executeDateTime,
            decimal availableCapacity, TimeSpan startTime, TimeSpan endTime, Guid funId, DateTime sansDate, int quantityInStock)
        {
            Id = Guid.NewGuid();
            EFunType = eFunType;
            ExecuteDateTime = executeDateTime;
            AvailableCapacity = availableCapacity;
            StartTime = startTime;
            EndTime = endTime;
            FunId = funId;
            SansDate = sansDate;
            QuantityInStock = quantityInStock;
            IsExist = true;
        }

        public Schedule() { }

        public List<TicketItem> Items { get; set; }
        public Guid FunId { get; private set; }



        /// <summary>
        /// ID
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// تاریخ سانس
        /// </summary>
        public DateTime SansDate { get; private set; }

        /// <summary>
        /// ساعت شروع :
        /// </summary>
        public TimeSpan StartTime { get; private set; }

        /// <summary>
        /// ساعت پایان :
        /// </summary>
        public TimeSpan EndTime { get; private set; }

        /// <summary>
        /// مدت زمان : 
        /// </summary>
        private TimeSpan _sansDuration;

        public TimeSpan SansDuration {
            get => _sansDuration;
            private set
            {
                value = EndTime - StartTime;
                _sansDuration = value;
            }
        }


        /// <summary>
        /// تنوع تفریح ها :
        /// </summary> 
        public EFunType EFunType { get; private set; }

        /// <summary>
        /// زمان سانس : - به میلادی
        /// </summary>
        public DateTime ExecuteDateTime { get; private set; }

        /// <summary>
        /// ظرفیت سانس
        /// </summary>
        public int QuantityInStock { get;private set; }
        
        
        /// <summary>
        /// فضای دردسترس :
        /// </summary>
        public decimal AvailableCapacity { get; private set; }

        /// <summary>
        /// چک کننده ی وجود داشتن سانس 
        /// </summary>
        public bool IsExist { get; private set; }
 
        public void FunTypeSet(EFunType eFunType)
        {
            EFunType = eFunType;
        }

        //private string GenerateScheduleCode()
        //{
        //    var millisecond = DateTime.Now.Millisecond.ToString();
        //    var randomCode = new Random().Next(10000, 99999).ToString();
        //    return millisecond  + "" + randomCode; 
        //}
    }
}
