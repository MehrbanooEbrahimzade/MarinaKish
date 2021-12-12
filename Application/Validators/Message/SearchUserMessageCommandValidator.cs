using Application.Commands.Message;
using FluentValidation;

namespace Application.Validators.Message
{
    public class SearchUserMessageCommandValidator : AbstractValidator<SearchUserMessageCommand>
    {
        public SearchUserMessageCommandValidator()
        {
            RuleFor(x => x.Userid)
                .NotNull().WithMessage("آیدی کاربر نمیتواند خالی باشد");

            RuleFor(x => x.SearchBoxUserMessage)
                .NotNull().WithMessage("کلمات باکس جست و جوی کاربر را وارد کنید")
                .NotEmpty().WithMessage("باکس جست و جوی پیام کاربر نمیتواند خالی باشد");
        }
    }
}
