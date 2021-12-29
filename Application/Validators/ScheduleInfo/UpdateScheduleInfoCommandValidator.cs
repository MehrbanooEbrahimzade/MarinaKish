using System;
using System.Collections.Generic;
using System.Text;
using Application.Commands.ScheduleInfo;
using FluentValidation;

namespace Application.Validators.ScheduleInfo
{
    public class UpdateScheduleInfoCommandValidator: AbstractValidator<UpdateScheduleInfoCommand>
    {
        public UpdateScheduleInfoCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotNull().WithMessage("آیدی اطلاعات سانس نمیتواند خالی باشد");
        }
    }
}
