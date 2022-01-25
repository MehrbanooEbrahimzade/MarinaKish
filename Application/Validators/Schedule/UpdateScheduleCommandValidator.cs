using System;
using System.Collections.Generic;
using System.Text;
using Application.Commands.Schedule;
using FluentValidation;

namespace Application.Validators.Schedule
{
    class UpdateScheduleCommandValidator :AbstractValidator<UpdateScheduleCommand>
    {
        public UpdateScheduleCommandValidator()
        {
            RuleFor(f => f.ScheduleId)
                .NotNull().WithMessage("آی دیه سانس نباید خالی باشد");
        }
    }
}
