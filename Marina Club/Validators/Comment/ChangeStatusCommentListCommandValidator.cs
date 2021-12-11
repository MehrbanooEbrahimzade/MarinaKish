using FluentValidation;
using Marina_Club.Commands.Comment;

namespace Marina_Club.Validators.Comment
{
    public class ChangeStatusCommentListCommandValidator : AbstractValidator<ChangeStatusCommentListCommand>
    {
        public ChangeStatusCommentListCommandValidator()
        {
            RuleFor(x => x.IDs)
                .NotNull().WithMessage("Comment[Id] is null. you must enter at least 1 id");

            RuleFor(x => x.Status)
                .NotNull().WithMessage(" تغییر وضعیت کامنت را وارد کنید")
                .IsInEnum().WithMessage("وضعیت کامنت تعریف نشده است");
        }
    }
}
