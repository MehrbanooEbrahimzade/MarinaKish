using System;
using Domain.Enums;

namespace Application.Dtos
{
    public class TicketDto
    {
        /// <summary>
        /// commentId 
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// نوع تفریح :
        /// </summary>
        public string FunType { get; set; }

        public DateTime SubmitDate { get; set;  }
        /// <summary>
        /// وضعیت
        /// </summary>
        public Condition Condition { get; set; }
        
        /// <summary>
        /// جنسیت
        /// </summary>
        public Gender gender { get; set; }
        
        /// <summary>
        /// محل خرید
        /// </summary>
        public WhereBuy BoughtPlace { get; set; }

        public  UserDto UserDto { get; set; }


        public ScheduleDto ScheduleDto{ get; set; }


    }
}
