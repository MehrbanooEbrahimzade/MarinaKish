using FluentValidation;
using Marina_Club.Commands.Message;

namespace Marina_Club.Validators.Message
{
    public class AddMessageCommandValidator : AbstractValidator<AddMessageCommand>
    {
        public AddMessageCommandValidator()
        {
            RuleFor(x => x.ConversationID)
                .NotNull().WithMessage("آیدی تالار گفت و گو نمیتواند خالی باشد");

            RuleFor(x => x.UserID)
                .NotNull().WithMessage("آیدی کاربر نمیتواند خالی باشد");

            RuleFor(x => x.Username)
                .Null().WithMessage("نام کاربری باید خالی باشد");
                
            RuleFor(x => x.Message)
                .NotEmpty().WithMessage("پیام نمیتواند خالی باشد")
                .NotNull().WithMessage("پیام خود را وارد کنید");
        }
    }
}
