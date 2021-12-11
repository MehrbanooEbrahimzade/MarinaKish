using FluentValidation;
using Marina_Club.Commands.Schedule;

namespace Marina_Club.Validators.Schedule
{
    public class AddScheduleCommandValidator : AbstractValidator<AddScheduleCommand>
    {
        public AddScheduleCommandValidator()
        {
            RuleFor(x => x.NumberOfDays)
                .NotNull().WithMessage("تعداد روز ساختن سانس را وارد کنید")
                .NotEqual(0).WithMessage("تعداد روز ساختن سانس نمیتواند 0 باشد");

            RuleFor(x => x.FunId)
                .NotNull().WithMessage("لطفا ایدی تفریح را وارد کنید");
        }
    }
}
