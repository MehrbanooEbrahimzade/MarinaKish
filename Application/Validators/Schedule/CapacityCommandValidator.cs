using Application.Commands.Schedule;
using FluentValidation;

namespace Application.Validators.Schedule
{
    public class CapacityCommandValidator : AbstractValidator<CapacityCommand>
    {
        public CapacityCommandValidator()
        {
            RuleFor(x => x.ScheduleId)
                .NotNull().WithMessage("آیدی سانس نمیتواند خالی باشد");

            RuleFor(x => x.Capacity)
                .GreaterThan(0).WithMessage("فضا باید بزرگتر از 0 تا باشد")
                .LessThanOrEqualTo(50).WithMessage("فضا نمیتواند بیشتر از 50 باشد");
        }
    }
}
