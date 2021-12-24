using Application.Commands.User;
using FluentValidation;

namespace Application.Validators.User
{
    public class GetPhoneAndSetVerifyCodeCommandValidator : AbstractValidator<GetPhoneAndSetVerifyCodeCommand>
    {
        public GetPhoneAndSetVerifyCodeCommandValidator()
        {
            RuleFor(x => x.VerifyCode)
                
                .MaximumLength(6).WithMessage("شماره تلفن همراه نباید بیشتر از 6 عدد باشد")
                .MinimumLength(6).WithMessage("شماره تلفن همراه نباید کمتر از 6 عدد باشد");
        }
    }
}
