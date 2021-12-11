using FluentValidation;
using Marina_Club.Commands.Schedule;

namespace Marina_Club.Validators.Schedule
{
    public class DiscountPriceListSchedulesCommandValidator : AbstractValidator<DiscountPriceListSchedulesCommand>
    {
        public DiscountPriceListSchedulesCommandValidator()
        {
            RuleFor(x => x.IDs)
                .NotNull().WithMessage("آیدی نمیتواند خالی باشد");

            RuleFor(x => x.DiscountPrice)
                .GreaterThan(0).WithMessage("قیمت تخفیف باید بیشتر از 0 باشد")
                .ScalePrecision(2, 4).WithMessage("تعداد اعشار کاهش قیمت حداکثر 2 و تعداد ارقام کاهش قیمت حداکثر 4")
                .NotNull().WithMessage("قیمت تخفیف نمیتواند خالی باشد");
        }
    }
}
