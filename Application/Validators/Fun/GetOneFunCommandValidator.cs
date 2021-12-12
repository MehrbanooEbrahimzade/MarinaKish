using Application.Commands.Fun;
using FluentValidation;

namespace Application.Validators.Fun
{
    public class GetOneFunCommandValidator : AbstractValidator<GetOneFunCommand>
    {
        public GetOneFunCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotNull().WithMessage("آی دی مورد نظر را وارد کنید");
        }
    }
}
