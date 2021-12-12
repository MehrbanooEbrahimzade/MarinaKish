using Application.Commands.Fun;
using FluentValidation;

namespace Application.Validators.Fun
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
