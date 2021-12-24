using Application.Commands.User;
using FluentValidation;

namespace Application.Validators.User
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(x => x.FirstName)
                .MaximumLength(70).WithMessage("اسم نباید بیشتر 70  حرف باشد")
                .NotNull().WithMessage("اسم نمیتواند خالی باشد");


            RuleFor(x => x.CreditCardCommand.ShabaNumber)
                  .MaximumLength(70).WithMessage("شماره شبا نباید بیشتر 24  رقم باشد")
                  .NotNull().WithMessage("شماره شبا نمیتواند خالی باشد");
        }
    }
}
