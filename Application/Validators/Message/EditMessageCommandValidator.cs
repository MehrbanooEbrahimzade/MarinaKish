using Application.Commands.Message;
using FluentValidation;

namespace Application.Validators.Message
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
