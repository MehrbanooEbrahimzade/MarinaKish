using Application.Commands.Message;
using FluentValidation;

namespace Application.Validators.Message
{
    public class SearchMessageCommandValidator : AbstractValidator<SearchMessageCommand>
    {
        public SearchMessageCommandValidator()
        {
            RuleFor(x => x.SearchBox)
                .NotNull().WithMessage("کلمات باکس جست و جو را وارد کنید")
                .NotEmpty().WithMessage("باکس جست و جو نمیتواند خالی باشد");
        }
    }
}
