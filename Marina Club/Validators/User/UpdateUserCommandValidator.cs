using FluentValidation;
using Marina_Club.Commands.User;

namespace Marina_Club.Validators
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(x => x.ID)
                .NotNull().WithMessage("آیدی نمیتواند خالی باشد");

            RuleFor(x => x.FirstName)
                .MaximumLength(70).WithMessage("اسم نباید بیشتر از  حرف باشد")
                .NotNull().WithMessage("اسم نمیتواند خالی باشد");

            RuleFor(x => x.Username)
                .MaximumLength(50).WithMessage("نام کاربری بیش از 30 حرف نیتواند باشد")
                .MinimumLength(5).WithMessage("نام کاربری کمتر از 5 حرف نمیتواند باشد");

            RuleFor(x => x.Gender)
                .IsInEnum().WithMessage("عدد جنسیت را وارد کنید")
                .NotNull().WithMessage("جنسیت نمیتواند خالی باشد");
        }
    }
}
