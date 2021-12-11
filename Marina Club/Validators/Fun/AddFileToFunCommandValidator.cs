using FluentValidation;
using Marina_Club.Commands.Fun;

namespace Marina_Club.Validators.Fun
{
    public class AddFileToFunCommandValidator : AbstractValidator<AddFileToFunCommand>
    {
        public AddFileToFunCommandValidator()
        {
            RuleFor(x => x.FunId)
                .NotNull().WithMessage("آیدی تفریح نمیتواند خالی باشد");

            RuleFor(x => x.FileId)
                .NotNull().WithMessage("آیدی عکس نمیتواند خالی باشد");
        }
    }
}
