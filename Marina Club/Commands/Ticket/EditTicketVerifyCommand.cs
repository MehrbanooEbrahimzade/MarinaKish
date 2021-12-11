using Marina_Club.Validators.Ticket;
using System.Web.Http;
using System.Net;
using System;

namespace Marina_Club.Commands.Ticket
{
    public class EditTicketVerifyCommand : CommandBase
    {
        public Guid Id { get; set; }
        public bool IsVerify { get; set; }

        public override bool Validate()
        {
            return new EditTicketVerifyCommandValidator().Validate(this).IsValid;

        }
    }
}
