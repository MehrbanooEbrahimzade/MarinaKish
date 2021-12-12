using Application.Commands.Schedule;
using FluentValidation;

namespace Application.Validators.Schedule
{
    public class ScheduleListCORECommandValidator : AbstractValidator<ScheduleListCORECommand>
    {
        public ScheduleListCORECommandValidator()
        {
            RuleFor(x => x.IDs)
                .NotNull().WithMessage("حداقل یک آی دی باید وارد شود");

            RuleFor(x => x.IsExist)
                .NotNull().WithMessage("کنسل کردن یا فعال کردن سانس را وارد کنید");
        }
    }
}
