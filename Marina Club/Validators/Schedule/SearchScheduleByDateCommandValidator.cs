using FluentValidation;
using Marina_Club.Commands.Schedule;

namespace Marina_Club.Validators.Schedule
{
    public class SearchScheduleByDateCommandValidator : AbstractValidator<SearchScheduleByDateCommand>
    {
        public SearchScheduleByDateCommandValidator()
        {
            RuleFor(x => x.FirstPersianDate)
                .NotNull().WithMessage("تاریخ جست و جوی سانس را وارد کنید");
        }
    }
}
