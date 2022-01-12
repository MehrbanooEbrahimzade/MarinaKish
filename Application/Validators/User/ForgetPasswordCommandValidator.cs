using Application.Commands.User;
using FluentValidation;

namespace Application.Validators.User
{
    public class ForgetPasswordCommandValidator : AbstractValidator<ForgetPasswordCommand>
    {
        public ForgetPasswordCommandValidator()
        {
            RuleFor(x => x.PhoneNumber)
                .NotNull().WithMessage("شماره تلفن نمیتواند خالی باشد")
                .MaximumLength(11).WithMessage("شماره تلفن باید حداکثر دارای 11 حرف باشد")
                .MinimumLength(11).WithMessage("شماره تلفن باید حداقل دارای 11 حرف باشد");

            RuleFor(x => x.NewPassword)
                .NotNull().WithMessage("رمز جدید نمیتواند خالی باشد")
                .MinimumLength(8).WithMessage("رمزعبور جدید باید بیش از 8 حرف باشد");

            RuleFor(x => x.NewPassword)
                .NotNull().WithMessage("تکرار رمز جدید نمیتواند خالی باشد")
                .MinimumLength(8).WithMessage("تکرار رمزعبور جدید باید بیش از 8 حرف باشد");

            RuleFor(x => x.VerifyCode)
                .NotNull().WithMessage("کد تایید نمیتواند خالی باشد")
                .MaximumLength(4).WithMessage("کد تایید باید 4 عدد باشد")
                .MinimumLength(4).WithMessage("کد تایید باید 4 عدد باشد");
        }
    }
}
