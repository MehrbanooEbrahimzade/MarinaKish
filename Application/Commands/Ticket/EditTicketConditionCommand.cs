using Application.Validators.Ticket;
using System;
using Domain.Models.enums;

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
        public ECondition ChangeCondition { get; set; }

        public override bool Validate()
        {
            return new EditTicketConditionCommandValidator().Validate(this).IsValid;
        }
    }
}
