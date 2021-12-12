using Application.Commands.Ticket;
using FluentValidation;

namespace Application.Validators.Ticket
{
    public class GetAllTicketFromUserCommandValidator : AbstractValidator<GetAllTicketFromUserCommand>
    {
        public GetAllTicketFromUserCommandValidator()
        {
            RuleFor(x => x.CellPhone)
                .MaximumLength(11).WithMessage("شماره تلفن نمیتواند بیشتر از 11 حرف باشد")
                .MinimumLength(11).WithMessage("شماره تلفن نمیتواند کمتر از 11 حرف باشد")
                .NotNull().WithMessage("شماره تلفن همراه را وارد کنید");
        }
    }
}
