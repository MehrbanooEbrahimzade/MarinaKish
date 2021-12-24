
using FluentValidation;

namespace Application.Commands.User
{
    public class RegisterUserCommand : CommandBase
    {
        public string PhoneNumber { get; set; }

        public override bool Validate()
        {
            return new RegisterUserCommandValidator().Validate(this).IsValid;
        }
    }

    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(x => x.PhoneNumber).MaximumLength(11).WithMessage("شماره تلفن وارد شده معتبر نمی باشد");
        }
    }
}
