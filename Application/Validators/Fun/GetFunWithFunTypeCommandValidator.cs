using Application.Commands.Fun;
using FluentValidation;

namespace Application.Validators.Fun
{
    public class GetFunWithFunTypeCommandValidator : AbstractValidator<GetFunWithFunTypeCommand>
    {
        public GetFunWithFunTypeCommandValidator()
        {
            RuleFor(x => x.EFunType)
                .NotNull().WithMessage("نام تفریح مورد نظر را وارد کنید")
                .IsInEnum().WithMessage("اسم تفریح باید ثبت شده باشد");
        }
    }
}
