using Application.Commands.User;
using FluentValidation;

namespace Application.Validators.User
{
    public class UserSignUpCommandValidator : AbstractValidator<UserSignUpCommand>
    {
        public UserSignUpCommandValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("نام نمیتواند خالی باشد")
                .NotNull().WithMessage("نام خودرا وارد کنید");

            RuleFor(x => x.LastName)
                .NotNull().WithMessage("نام خانوادگی خود را وارد کنید");

            RuleFor(x => x.UserName)
                .MaximumLength(30).WithMessage("نام کاربری بیشتر از 30 حرف نمیتواند باشد")
                .MinimumLength(5).WithMessage("نام کاربری کمتر از 5 حرف نمیتواند باشد");

            RuleFor(x => x.Password)
                .MinimumLength(8).WithMessage("کاراکتر های رمز عبور باید بیش از 8 حرف باشد");

            RuleFor(x => x.Provice)
                .MinimumLength(3).WithMessage("شهر مورد نظر یافت نشد");

            RuleFor(x => x.ContactInfo.CellPhone)
                .MaximumLength(11).WithMessage("شماره تلفن همراه اشتباه است . مثال : 09123456789")
                .MinimumLength(11).WithMessage("شماره تلفن همراه اشتباه است . مثال : 09123456789");

        }
    }
}
