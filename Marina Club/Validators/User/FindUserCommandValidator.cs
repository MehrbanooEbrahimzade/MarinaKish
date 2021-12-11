using FluentValidation;
using Marina_Club.Commands.User;

namespace Marina_Club.Validators.User
{
    public class FindUserCommandValidator : AbstractValidator<FindUserCommand>
    {
        public FindUserCommandValidator()
        {
            RuleFor(x => x.UserNameOrFullName)
                .NotNull().WithMessage("نام کاربری کاربر مورد نظر را وارد کنید")
                .NotEmpty().WithMessage("نام کاربری کاربر مورد نظر نمیتواند خالی باشد");
        }
    }
}
