using Application.Validators.Ticket;
using Domain.Models.enums;

namespace Application.Commands.Ticket
{
    public class GetAllTicketFromFunCommand : CommandBase
    {
        public EFunType EFunType { get; set; }

        public override bool Validate()
        {
            return new GetAllTicketFromFunCommandValidator().Validate(this).IsValid;

        }
    }
}
