using FluentValidation;
using Marina_Club.Commands.User;

namespace Marina_Club.Validators.User
{
    public class UpdateUserWithIdCommandValidator : AbstractValidator<UpdateUserWithIdCommand>
    {
        public UpdateUserWithIdCommandValidator()
        {
            RuleFor(x => x.IsActive)
                .NotNull().WithMessage("فعال یا بلاک شدن کاربر باید نشان داده شود");
        }
    }
}
