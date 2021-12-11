using FluentValidation;
using Marina_Club.Commands.Files;

namespace Marina_Club.Validators.Files
{
    public class AddFileToScheduleCommandValidator : AbstractValidator<AddFileToScheduleCommand>
    {
        public AddFileToScheduleCommandValidator()
        {
            RuleFor(x => x.FileID)
                .NotNull().WithMessage("آیدی عکس نمیتواند خالی باشد");

            RuleFor(x => x.ScheduleID)
                .NotNull().WithMessage("آیدی سانس نمیتواند خالی باشد");

        }
    }
}
