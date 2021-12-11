using FluentValidation;
using Marina_Club.Commands.Fun;

namespace Marina_Club.Validators.Fun
{
    public class AddFunCommandValidator : AbstractValidator<AddFunCommand>
    {
        public AddFunCommandValidator()
        {
            RuleFor(x => x.FunType)
                .NotNull().WithMessage("اسم تفریح را وارد کنید")
                .IsInEnum().WithMessage("تفریح وارد کرده خود را مجددا بررسی کنید");

            RuleFor(x => x.Price)
                .NotNull().WithMessage("قیمت تفریح نمیتواند خالی باشد")
                .GreaterThan(0).WithMessage("قیمت تفریح باید بیشتر از 0 باشد")
                .ScalePrecision(2, 4).WithMessage("برای قیمت تعداد اعشار حداکثر تا 2 و تعداد ارقام حداکثر تا 4 تا باید باشد");
                

            RuleFor(x => x.StartTime)
                .NotNull().WithMessage("زمان شروع نمیتواند خالی باشد")
                .NotEmpty().WithMessage("زمان شروع را وارد کنید");

            RuleFor(x => x.EndTime)
                .NotNull().WithMessage("زمان پایان نمیتواند خالی باشد")
                .NotEmpty().WithMessage("زمان پایان را وارد کنید");

            RuleFor(x => x.SansDuration)
                .NotNull().WithMessage("مدت زمان نمیتواند خالی باشد")
                .GreaterThan(0).WithMessage("مدت زمان باید بیشتر از 0 باشد")
                .LessThan(121).WithMessage("مدت زمان تفریح حداکثر میتواند 120 باشد");


            RuleFor(x => x.SansTotalCapacity)
                .NotNull().WithMessage("فضای کل سانس نمیتواند خالی باشد")
                .GreaterThan(0).WithMessage("فضای سانس باید بیشتر از 0 باشد")
                .LessThanOrEqualTo(100).WithMessage("فضای سانس حداکثر میتواند 100 باشد");
                

            RuleFor(x => x.SansGapTime)
                .NotNull().WithMessage("زمان استراحت نمیتواند خالی باشد")
                .GreaterThan(0).WithMessage("زمان استراحت باید بیشتر از 0 باشد")
                .LessThanOrEqualTo(60).WithMessage("زمان استراحت حداثکر باید 60 دقیقه باشد");

            RuleFor(x => x.About)
                .Length(0, 250).WithMessage("حداکثر درباره تفریح باید 250 حرف باشد");
        }
    }
}
