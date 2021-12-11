using Marina_Club.Models.enums;
using Marina_Club.Validators.Ticket;
using System;

namespace Marina_Club.Commands.Ticket
{
    public class EditTicketConditionCommand : CommandBase
    {

        /// <summary>
        /// آیدی بلیط
        /// </summary>
        public Guid TicketId { get; set; }

        /// <summary>
        /// وضعیت
        /// </summary>
        public ECondition ChangeCondition { get; set; }

        public override bool Validate()
        {
            return new EditTicketConditionCommandValidator().Validate(this).IsValid;
        }
    }
}
