using FluentValidation;
using Marina_Club.Commands.Conversation;

namespace Marina_Club.Validators.Conversation
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
