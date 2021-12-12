using Application.Commands;
using FluentValidation;

namespace Application.Validators
{
    public class PersianDateCommandValidator : AbstractValidator<PersianDateCommand>
    {
        public PersianDateCommandValidator()
        {
            RuleFor(x => x.Day)
                .GreaterThanOrEqualTo(1).WithMessage("روز باید 1 یا بیشتر باشد")
                .LessThanOrEqualTo(31).WithMessage("روز باید 31 یا کمتر باشد");

            RuleFor(x => x.Month)
                .GreaterThanOrEqualTo(1).WithMessage("ماه حداقل باید 1 باشد")
                .LessThanOrEqualTo(12).WithMessage("ماه حداکثر میتواند 12 باشد");

            RuleFor(x => x.Year)
                .GreaterThanOrEqualTo(1368).WithMessage("سال شمسی حداقل باید 1368 باشد")
                .LessThanOrEqualTo(1410).WithMessage("سال شمسی حداکثر میتواند 1410 باشد");
        }
    }
}
