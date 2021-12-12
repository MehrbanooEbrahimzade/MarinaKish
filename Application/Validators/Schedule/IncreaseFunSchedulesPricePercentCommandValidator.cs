using Application.Commands.Schedule;
using FluentValidation;

namespace Application.Validators.Schedule
{
    public class IncreaseFunSchedulesPricePercentCommandValidator : AbstractValidator<IncreaseFunSchedulesPricePercentCommand>
    {
        public IncreaseFunSchedulesPricePercentCommandValidator()
        {
            RuleFor(x => x.FunId)
                .NotNull().WithMessage("آیدی تفریح نمیتواند خالی باشد");

            RuleFor(x => x.IncreasePricePercent)
                .GreaterThan(0).WithMessage("درصد قیمت افزایشی باید بیشتر از 0 باشد")
                .LessThan(200).WithMessage("درصد قیمت افزایشی نمیتواند 200 درصد یا بیشتر باشد")
                .NotNull().WithMessage("درصد قیمت افزایشی نمیتواند خالی باشد");
        }
    }
}
