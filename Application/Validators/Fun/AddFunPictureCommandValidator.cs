using Application.Commands.Fun;
using FluentValidation;

namespace Application.Validators.Fun
{
    public class AddFunPictureCommandValidator : AbstractValidator<AddFunPictureCommand>
    {
        public AddFunPictureCommandValidator()
        {
            RuleFor(x => x.EFunType)
                .NotNull().WithMessage("نوع تفریح نمیتواند خالی باشد");
        }
    }
}
