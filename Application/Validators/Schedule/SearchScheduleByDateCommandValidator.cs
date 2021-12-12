using Application.Commands.Schedule;
using FluentValidation;

namespace Application.Validators.Schedule
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
