using FluentValidation;
using Marina_Club.Commands.Schedule;

namespace Marina_Club.Validators.Schedule
{
    public class CancelOrReExistScheduleCommandValidator : AbstractValidator<CancelOrReExistScheduleCommand>
    {
        public CancelOrReExistScheduleCommandValidator()
        {
            RuleFor(x => x.ScheduleId)
                .NotNull().WithMessage("آیدی تفریح نمیتواند خالی باشد");

            RuleFor(x => x.IsExist)
                .NotNull().WithMessage("درست یا نادرست بودن وجود داشتن سانس را مشخص کنید");
        }
    }
}
