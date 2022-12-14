using Application.Commands.Fun;
using FluentValidation;

namespace Application.Validators.Fun
{
    public class AddFunCommandValidator : AbstractValidator<AddFunCommand>
    {
        public AddFunCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("اسم تفریح را وارد کنید")
                .NotEmpty().WithMessage("اسم تفریح نمی تواند خالی باشد");

            RuleFor(x => x.About)
                .Length(0, 250).WithMessage("حداکثر درباره تفریح باید 250 حرف باشد");

            RuleFor(x => x.ScheduleInfo.Amount)
                .NotNull().WithMessage("قیمت تفریح نمیتواند خالی باشد")
                .GreaterThan(0).WithMessage("قیمت تفریح باید بیشتر از 0 باشد");


            RuleFor(x => x.ScheduleInfo.StartTime)
                    .NotNull().WithMessage("زمان شروع نمیتواند خالی باشد")
                    .NotEmpty().WithMessage("زمان شروع را وارد کنید");

            RuleFor(x => x.ScheduleInfo.EndTime)
                .NotNull().WithMessage("زمان پایان نمیتواند خالی باشد")
                .NotEmpty().WithMessage("زمان پایان را وارد کنید");

            RuleFor(x => x.ScheduleInfo.Duration)
                 .NotNull().WithMessage("مدت زمان نمیتواند خالی باشد")
                 .GreaterThan(0).WithMessage("مدت زمان باید بیشتر از 0 باشد")
                 .LessThan(121).WithMessage("مدت زمان تفریح حداکثر میتواند 120 باشد");


            RuleFor(x => x.ScheduleInfo.TotalCapacity)
                .NotNull().WithMessage("فضای کل سانس نمیتواند خالی باشد")
                .GreaterThan(0).WithMessage("فضای سانس باید بیشتر از 0 باشد")
                .LessThanOrEqualTo(100).WithMessage("فضای سانس حداکثر میتواند 100 باشد");


            RuleFor(x => x.ScheduleInfo.GapTime)
                .NotNull().WithMessage("زمان استراحت نمیتواند خالی باشد")
                .GreaterThan(0).WithMessage("زمان استراحت باید بیشتر از 0 باشد")
                .LessThanOrEqualTo(60).WithMessage("زمان استراحت حداثکر باید 60 دقیقه باشد");

            //RuleFor(x => x.ScheduleInfo.TotalCapacity == x.ScheduleInfo.PresenceCapacity + x.ScheduleInfo.OnlineCapacity); //نمیگیره چرا


        }
    }
}
