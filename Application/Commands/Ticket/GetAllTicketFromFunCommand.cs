using Application.Validators.Ticket;
using Domain.Enums;

namespace Application.Commands.Ticket
{
    public class GetAllTicketFromFunCommand : CommandBase
    {
        public FunType EFunType { get; set; }

        public override bool Validate()
        {
            return new GetAllTicketFromFunCommandValidator().Validate(this).IsValid;

        }
    }
}
