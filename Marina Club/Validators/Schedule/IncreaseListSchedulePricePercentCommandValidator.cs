using FluentValidation;
using Marina_Club.Commands.Schedule;

namespace Marina_Club.Validators.Schedule
{
    public class IncreaseListSchedulePricePercentCommandValidator : AbstractValidator<IncreaseListSchedulePricePercentCommand>
    {
        public IncreaseListSchedulePricePercentCommandValidator()
        {
            RuleFor(x => x.IDs)
                .NotNull().WithMessage("حداقل 1 آیدی باید وارد شود");

            RuleFor(x => x.IncreasePricePercent)
                .GreaterThan(0).WithMessage("درصد قیمت افزایشی باید بیشتر از 0 باشد")
                .LessThan(200).WithMessage("درصد قیمت افزایشی نمیتواند 200 درصد یا بیشتر باشد")
                .NotNull().WithMessage("درصد قیمت افزایشی نمیتواند خالی باشد");
        }
    }
}
