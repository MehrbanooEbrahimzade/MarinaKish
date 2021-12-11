using FluentValidation;
using Marina_Club.Commands.Fun;

namespace Marina_Club.Validators.Fun
{
    public class AddFunPictureCommandValidator : AbstractValidator<AddFunPictureCommand>
    {
        public AddFunPictureCommandValidator()
        {
            RuleFor(x => x.FunType)
                .NotNull().WithMessage("نوع تفریح نمیتواند خالی باشد");
        }
    }
}
