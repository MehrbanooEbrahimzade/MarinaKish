using Application.Validators.Ticket;
using System;
using Domain.Enums;

namespace Application.Commands.Ticket
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
        public Condition ChangeCondition { get; set; }

        public override bool Validate()
        {
            return new EditTicketConditionCommandValidator().Validate(this).IsValid;
        }
    }
}
