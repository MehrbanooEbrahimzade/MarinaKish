using FluentValidation;
using Marina_Club.Commands.Conversation;

namespace Marina_Club.Validators.Conversation
{
    public class AddConversationCommandValidator : AbstractValidator<AddConversationCommand>
    {
        public AddConversationCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotNull().WithMessage("لطفا عنوان پیام را وارد کنید")
                .NotEmpty().WithMessage("عنوان پیام نمیتواند خالی باشد");
        }
    }
}
