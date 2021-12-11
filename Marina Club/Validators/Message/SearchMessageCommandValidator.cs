using FluentValidation;
using Marina_Club.Commands.Message;

namespace Marina_Club.Validators.Message
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
