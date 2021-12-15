using Application.Commands.Ticket;
using FluentValidation;

namespace Application.Validators.Ticket
{
    public class GetAllTicketFromFunCommandValidator : AbstractValidator<GetAllTicketFromFunCommand>
    {
        public GetAllTicketFromFunCommandValidator()
        {
            RuleFor(x => x.EFunType)
                .NotNull().WithMessage("اسم تفریح را وارد کنید");
        }
    }
}
