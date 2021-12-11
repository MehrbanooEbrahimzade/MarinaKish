using FluentValidation;
using Marina_Club.Commands.User;

namespace Marina_Club.Validators.User
{
    public class GetPhoneAndSetVerifyCodeCommandValidator : AbstractValidator<GetPhoneAndSetVerifyCodeCommand>
    {
        public GetPhoneAndSetVerifyCodeCommandValidator()
        {
            RuleFor(x => x.CellPhone)
                .NotNull().WithMessage("شماره تلفن همراه خودرا وارد کنید")
                .NotEmpty().WithMessage("شماره تلفن نمیتواند خالی باشد")
                .MaximumLength(11).WithMessage("شماره تلفن همراه نباید بیشتر از 11 عدد باشد")
                .MinimumLength(11).WithMessage("شماره تلفن همراه نباید کمتر از 11 عدد باشد");
        }
    }
}
