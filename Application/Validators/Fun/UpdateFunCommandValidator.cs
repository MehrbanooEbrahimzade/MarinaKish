using Application.Commands.Fun;
using FluentValidation;

namespace Application.Validators.Fun
{
    public class UpdateFunCommandValidator : AbstractValidator<UpdateFunCommand>
    {
        public UpdateFunCommandValidator()
        {
            RuleFor(x => x.FunId)
                .NotNull().WithMessage("آیدی تفریح نمیتواند خالی باشد");

            RuleFor(x => x.Name)
                .NotNull().WithMessage("اسم تفریح را وارد کنید");


            RuleFor(x => x.About)
                .Length(0, 250).WithMessage("حداکثر درباره تفریح باید 250 حرف باشد");

        }
    }
}
