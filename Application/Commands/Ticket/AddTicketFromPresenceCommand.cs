using Application.Validators.Ticket;
using System;

namespace Application.Commands.Ticket
{
    public class AddTicketFromPresenceCommand : CommandBase
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
        /// شماره تلفن کاربر
        /// </summary>
        public string UserCellPhone { get; set; }

        public override bool Validate()
        {
            return new AddTicketFromPresenceCommandValidator().Validate(this).IsValid;
        }
    }
}
