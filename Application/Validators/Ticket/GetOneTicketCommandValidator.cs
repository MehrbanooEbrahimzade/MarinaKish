using FluentValidation;
using Application.Commands.Ticket;

namespace Application.Validators.Ticket
{
    public class GetOneTicketCommandValidator : AbstractValidator<GetONeTicketCommand>
    {
        public GetOneTicketCommandValidator()
        {
            RuleFor(x => x.TicketNumber)
                .NotEmpty().WithMessage("شماره بلیط نمیتواند خالی باشد")
                .NotNull().WithMessage("شماره بلیط را وارد کنید");
        }
    }
}
