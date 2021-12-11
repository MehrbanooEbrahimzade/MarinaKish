using FluentValidation;
using Marina_Club.Commands.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marina_Club.Validators.Ticket
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
