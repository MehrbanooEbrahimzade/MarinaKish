using Application.Commands.Conversation;
using FluentValidation;

namespace Application.Validators.Conversation
{
    public class SearchMessageCommandValidator : AbstractValidator<SearchMessageCommand>
    {
        public SearchMessageCommandValidator()
        {
            RuleFor(x => x.ConversationId)
                .NotNull().WithMessage("آیدی تالار گفت و گو نمیتواند خالی باشد");

            RuleFor(x => x.SearchBox)
                .NotNull().WithMessage("باکس جست و جو نمیتواند خالی باشد")
                .NotEmpty().WithMessage("باکس جست و جو نمیتواند خالی باشد");
        }
    }
}
