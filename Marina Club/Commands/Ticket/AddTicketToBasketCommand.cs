using System;
using System.Net;
using System.Web.Http;
using Marina_Club.Models.enums;
using Marina_Club.Validators.Ticket;

namespace Marina_Club.Commands.Ticket
{
    public class AddTicketToBasketCommand : CommandBase
    {

        /// <summary>
        /// آی دیه مدل سانس ها
        /// </summary>
        public Guid ScheduleId { get; set; }

        /// <summary>
        /// تعداد بلیط
        /// </summary>
        public int NumberOfTicket { get; set; }

        /// <summary>
        /// آیدی کاربر
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Command Validation
        /// </summary>
        /// <returns>true/false</returns>
        public override bool Validate()
        {
            return new AddTicketToBasketCommandValidator().Validate(this).IsValid;
        }
    }
}
