using FluentValidation;
using Marina_Club.Commands.Comment;

namespace Marina_Club.Validators.Comment
{
    public class ChangeCommentStatusCommandValidator : AbstractValidator<ChangeCommentStatusCommand>
    {
        public ChangeCommentStatusCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotNull().WithMessage("Comment[Id] is null");

            RuleFor(x => x.Status)
                .NotNull().WithMessage("وضعیت کامنت را وارد کنید")
                .IsInEnum().WithMessage("وضعیت مورد نظر ثبت نشده است");
        }
    }
}
