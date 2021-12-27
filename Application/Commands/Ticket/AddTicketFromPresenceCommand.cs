using Application.Validators.Ticket;
using Domain.Enums;
using System;

namespace Application.Commands.Ticket
{
    public class AddTicketFromPresenceCommand : CommandBase
    {
        public string UserId { get; set; }

        public Guid FunId { get; set; }

        public Gender gender { get; set; }

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
        //public string UserCellPhone { get; set; }
        public int AvailableCapacity { get; internal set; }

        public override bool Validate()
        {
            return new AddTicketFromPresenceCommandValidator().Validate(this).IsValid;
        }
    }
}
