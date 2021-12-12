using Application.Commands.Conversation;
using FluentValidation;

namespace Application.Validators.Conversation
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
