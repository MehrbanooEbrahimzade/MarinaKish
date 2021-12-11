using FluentValidation;
using Marina_Club.Commands.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marina_Club.Validators.Ticket
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
