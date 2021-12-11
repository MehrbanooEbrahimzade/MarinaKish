using FluentValidation;
using Marina_Club.Commands.User;

namespace Marina_Club.Validators.User
{
    public class AddSellerInfoCommandValidator : AbstractValidator<AddSellerInfoCommand>
    {
        public AddSellerInfoCommandValidator()
        {
            RuleFor(x => x.NationalCode)
                .NotEmpty().WithMessage("کد ملی را وارد کنید")
                .NotNull().WithMessage("کد ملی نمیتواند خالی باشد");

            RuleFor(x => x.CardNumber)
                .CreditCard().WithMessage("شماره کارت اشتباه وارد شده است");

            RuleFor(x => x.ShabaNumber)
                .NotEmpty().WithMessage("شماره شبا را وارد کنید")
                .NotNull().WithMessage("شماره شبا نمیتواند خالی باشد");
        }
    }
}
