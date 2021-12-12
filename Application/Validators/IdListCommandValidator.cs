using Application.Commands;
using FluentValidation;

namespace Application.Validators
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
