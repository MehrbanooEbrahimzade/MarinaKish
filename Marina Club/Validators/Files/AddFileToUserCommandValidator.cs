using FluentValidation;
using Marina_Club.Commands.Files;

namespace Marina_Club.Validators.Files
{
    public class AddFileToUserCommandValidator : AbstractValidator<AddFileToUserCommand>
    {
        public AddFileToUserCommandValidator()
        {
            RuleFor(x => x.UserID)
                .NotNull().WithMessage("آیدی کاربر نمیتواند خالی باشد");

            RuleFor(x => x.FileID)
                .NotNull().WithMessage("آیدی فایل/عکس نمیتواند خالی باشد");
        }
    }
}
