using Marina_Club.Models.enums;
using Marina_Club.Validators.Ticket;
using System.Net;
using System.Web.Http;

namespace Marina_Club.Commands.Ticket
{
    public class GetAllTicketFromFunCommand : CommandBase
    {
        public FunType FunType { get; set; }

        public override bool Validate()
        {
            return new GetAllTicketFromFunCommandValidator().Validate(this).IsValid;

        }
    }
}
