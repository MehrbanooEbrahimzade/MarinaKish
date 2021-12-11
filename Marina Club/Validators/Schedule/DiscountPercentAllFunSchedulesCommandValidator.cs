using FluentValidation;
using Marina_Club.Commands.Schedule;

namespace Marina_Club.Validators.Schedule
{
    public class DiscountPercentAllFunSchedulesCommandValidator : AbstractValidator<DiscountPercentAllFunSchedulesCommand>
    {
        public DiscountPercentAllFunSchedulesCommandValidator()
        {
            RuleFor(x => x.FunId)
                .NotNull().WithMessage("آیدی تفریح نمیتواند خالی باشد");

            RuleFor(x => x.DiscountPercent)
                .GreaterThan(0).WithMessage("درصد تخفیف باید بیشتر از 0 باشد")
                .LessThan(100).WithMessage("درصد تخفیف باید کمتر از 100 باشد")
                .NotNull().WithMessage("درصد تخفیف نمیتواند خالی باشد");
        }
    }
}
