using FluentValidation;
using Marina_Club.Commands.Ticket;

namespace Marina_Club.Validators.Ticket
{
    public class GetAllTicketFromFunCommandValidator : AbstractValidator<GetAllTicketFromFunCommand>
    {
        public GetAllTicketFromFunCommandValidator()
        {
            RuleFor(x => x.FunType)
                .NotNull().WithMessage("اسم تفریح را وارد کنید");
        }
    }
}
