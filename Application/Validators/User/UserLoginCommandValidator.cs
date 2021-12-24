using Application.Commands.User;
using FluentValidation;

namespace Application.Validators.User
{
    public class UserLoginCommandValidator : AbstractValidator<UserLoginCommand>
    {
        public UserLoginCommandValidator()
        {
            RuleFor(x => x.PhoneNumber)
                .MaximumLength(11).WithMessage("شماره تلفن نمیتواند بیشتر از 11 حرف باشد")
                .MinimumLength(11).WithMessage("شماره تلفن نمیتواند کمتر از 11 حرف باشد")
                .NotNull().WithMessage("شماره تلفن خود را وارد کنید");

            RuleFor(x => x.VerifyCode)
                .MaximumLength(6).WithMessage("کد تایید بیشتر از 6 حرف وارد شده است")
                .MinimumLength(6).WithMessage("کد تایید کمتر از 6 حرف وارد شده است")
                .NotNull().WithMessage("کد تایید را وارد کنید");

        }
    }
}
