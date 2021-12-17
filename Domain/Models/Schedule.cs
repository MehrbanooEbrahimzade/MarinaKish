using System;
using System.Collections.Generic;
using Domain.Enums;

namespace Domain.Models
{
    public class Schedule
    {
        public Schedule
            (FunType funType, DateTime executeDateTime, decimal availableCapacity, TimeSpan startTime
                , TimeSpan endTime, Guid funId, DateTime sansDate, int quantityInStock)
        {
            Id = Guid.NewGuid();
            EFunType = funType;
            ExecuteDateTime = executeDateTime;
            AvailableCapacity = availableCapacity;
            StartTime = startTime;
            EndTime = endTime;
            FunId = funId;
            SansDate = sansDate;
            QuantityInStock = quantityInStock;
            IsExist = true;
        }

        private Schedule() { }

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
        public FunType EFunType { get; private set; }

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
 
        public void FunTypeSet(FunType eFunType)
        {
            EFunType = eFunType;
        }
    }
}
