using Application.Commands.User;
using FluentValidation;

namespace Application.Validators.User
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
