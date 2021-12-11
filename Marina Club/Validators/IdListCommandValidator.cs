using FluentValidation;
using Marina_Club.Commands;

namespace Marina_Club.Validators
{
    public class IdListCommandValidator : AbstractValidator<IdListCommand>
    {
        public IdListCommandValidator()
        {
            RuleFor(x => x.IDs)
                .NotNull().WithMessage("حداقل 1 آیدی باید وارد شود");
        }
    }
}
