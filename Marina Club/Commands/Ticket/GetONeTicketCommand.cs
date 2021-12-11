using System.Net;
using System.Web.Http;
using Marina_Club.Validators.Ticket;

namespace Marina_Club.Commands.Ticket
{
    public class GetONeTicketCommand : CommandBase
    {
        /// <summary>
        /// شماره بلیط
        /// </summary>
        public string TicketNumber { get; set; }

        public override bool Validate()
        {
            return new GetOneTicketCommandValidator().Validate(this).IsValid;

        }
    }
}
