using Application.Commands.Schedule;
using FluentValidation;

namespace Application.Validators.Schedule
{
    public class IncreaseFunSchedulesPriceCommandValidator : AbstractValidator<IncreaseFunSchedulesPriceCommand>
    {
        public IncreaseFunSchedulesPriceCommandValidator()
        {
            RuleFor(x => x.FunId)
                .NotNull().WithMessage("آیدی تفریح مورد نظر را وارد کنید");

            RuleFor(x => x.IncreasePrice)
                .GreaterThan(0).WithMessage("قیمت افزایشی باید بیشتر از 0 باشد")
                .ScalePrecision(2, 4).WithMessage("تعداد اعشار افزایش قیمت حداکثر 2 و تعداد ارقام افزایش قیمت حداکثر 4")
                .NotNull().WithMessage("قیمت افزایشی نمیتواند خالی باشد");
        }
    }
}
