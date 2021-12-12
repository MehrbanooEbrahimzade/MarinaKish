using Application.Commands;
using FluentValidation;

namespace Application.Validators
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
