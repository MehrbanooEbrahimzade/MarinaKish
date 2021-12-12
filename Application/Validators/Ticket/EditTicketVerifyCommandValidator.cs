using FluentValidation;
using Application.Commands.Ticket;

namespace Application.Validators.Ticket
{
    public class EditTicketVerifyCommandValidator : AbstractValidator<EditTicketVerifyCommand>
    {
        public EditTicketVerifyCommandValidator()
        {
            RuleFor(x => x.IsVerify)
                .NotNull().WithMessage("فعال کردن یا غیرفعال کردن بلیط/سانس را وارد کنید");

            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("آیدی نمیتواند خالی باشد")
                .NotNull().WithMessage("آیدی بلیط را وارد کنید");
        }
    }
}
