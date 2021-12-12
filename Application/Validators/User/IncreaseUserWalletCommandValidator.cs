using Application.Commands.User;
using FluentValidation;

namespace Application.Validators.User
{
    public class IncreaseUserWalletCommandValidator : AbstractValidator<IncreaseUserWalletCommand>
    {
        public IncreaseUserWalletCommandValidator()
        {
            RuleFor(x => x.Cash)
                .GreaterThanOrEqualTo(10).WithMessage("مقدار افزایشی کیف پول باید بیشتر از 10 تومان باشد")
                .LessThanOrEqualTo(1000).WithMessage("مقدار افزایشی کیف پول نمیتواند بیشتر از 1000 تومان باشد")
                .NotNull().WithMessage("مقدار افزایشی کیف پول نمیتواند خالی باشد");
        }
    }
}
