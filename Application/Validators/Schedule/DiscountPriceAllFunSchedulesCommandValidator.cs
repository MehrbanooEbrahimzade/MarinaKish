using Application.Commands.Schedule;
using FluentValidation;

namespace Application.Validators.Schedule
{
    public class DiscountPriceAllFunSchedulesCommandValidator : AbstractValidator<DiscountPriceAllFunSchedulesCommand>
    {
        public DiscountPriceAllFunSchedulesCommandValidator()
        {
            RuleFor(x => x.FunId)
                .NotNull().WithMessage("آیدی تفریح نمیتواند خالی باشد");

            RuleFor(x => x.DiscountPrice)
                .GreaterThan(0).WithMessage("قیمت تخفیف باید بیشتر از 0 باشد")
                .ScalePrecision(2, 4).WithMessage("تعداد اعشار کاهش قیمت حداکثر 2 و تعداد ارقام افزایش قیمت حداکثر 4")
                .NotNull().WithMessage("قیمت تخفیف نباید خالی باشد");
        }
    }
}
