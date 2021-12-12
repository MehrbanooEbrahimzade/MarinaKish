using Application.Commands.User;
using FluentValidation;

namespace Application.Validators.User
{
    public class NewMemberLoginCommandValidator : AbstractValidator<NewMemberLoginCommand>
    {
        public NewMemberLoginCommandValidator()
        {
            RuleFor(x => x.CellPhone)
                .MaximumLength(11).WithMessage("شماره تلفن نمیتواند بیشتر از 11 حرف باشد")
                .MinimumLength(11).WithMessage("شماره تلفن نمیتواند کمتر از 11 حرف باشد");

            RuleFor(x => x.FirstName)
                .MaximumLength(70).WithMessage(" نام نمیتواند بیشتر از 60 حرف باشد")
                .NotEmpty().WithMessage("نام نمیتواند خالی باشد")
                .NotNull().WithMessage("نام خود را وارد کنید");

            RuleFor(x => x.UserName)
                .MaximumLength(50).WithMessage("نام کاربری بیشتر از 30 حرف نمیتواند باشد")
                .MinimumLength(5).WithMessage("تعداد کاراکتر نام کاربری حداقل باید 5 کاراکتر باشد");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("رمز عبور جدید را وارد کنید")
                .MinimumLength(8).WithMessage("رمز عبور کمتر از 8 حرف نمیتواند باشد");
        }
    }
}
