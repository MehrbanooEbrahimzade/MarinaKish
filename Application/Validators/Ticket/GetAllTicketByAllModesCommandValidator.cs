using Application.Commands.Ticket;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Validators.Ticket
{
    public class GetAllTicketByAllModesCommandValidator : AbstractValidator<GetAllTicketByAllModesCommand>
    {
        public GetAllTicketByAllModesCommandValidator()
        {
            //RuleFor(r => r.Condition)
            //    .(0).WithMessage("درصد تخفیف باید بیشتر از 0 باشد")
            //    .LessThan(4).WithMessage("درصد تخفیف باید کمتر از 100 باشد");
        }

    }
}
