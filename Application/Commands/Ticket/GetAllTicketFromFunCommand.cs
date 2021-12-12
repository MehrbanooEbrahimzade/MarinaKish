using Application.Validators.Ticket;
using Domain.Models.enums;

namespace Application.Commands.Ticket
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
