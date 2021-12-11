using FluentValidation;
using Marina_Club.Commands.Message;

namespace Marina_Club.Validators.Message
{
    public class EditMessageCommandValidator : AbstractValidator<EditMessageCommand>
    {
        public EditMessageCommandValidator()
        {
            RuleFor(x => x.MessageID)
                .NotNull().WithMessage("آیدی پیام نمیتواند خالی باشد");

            RuleFor(x => x.EditedMessage)
                .NotNull().WithMessage("پیام ویرایش شده نمیتواند خالی باشد")
                .NotEmpty().WithMessage("پیام ویرایش شده نمیتواند خالی باشد");
        }
    }
}
