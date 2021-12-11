using Marina_Club.Validators.Ticket;
using System.Web.Http;
using System.Net;

namespace Marina_Club.Commands.Ticket
{
    public class GetAllTicketFromUserCommand : CommandBase
    {
        public string CellPhone { get; set; }

        public override bool Validate()
        {
            return new GetAllTicketFromUserCommandValidator().Validate(this).IsValid;

        }
    }
}
