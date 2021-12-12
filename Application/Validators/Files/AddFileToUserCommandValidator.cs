using Application.Commands.Files;
using FluentValidation;

namespace Application.Validators.Files
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
