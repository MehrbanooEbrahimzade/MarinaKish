using FluentValidation;
using Marina_Club.Commands;

namespace Marina_Club.Validators
{
    public class IdCommandValidator : AbstractValidator<IdCommand>
    {
        public IdCommandValidator()
        {
            RuleFor(x => x.ID)
                .NotNull().WithMessage("آیدی نمیتواند خالی باشد");
        }
    }
}
