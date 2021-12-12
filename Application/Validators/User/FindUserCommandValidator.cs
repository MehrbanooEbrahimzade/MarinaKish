using Application.Commands.User;
using FluentValidation;

namespace Application.Validators.User
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
