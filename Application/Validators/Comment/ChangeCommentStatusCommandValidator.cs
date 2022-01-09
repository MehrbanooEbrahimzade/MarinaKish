using Application.Commands.Comment;
using FluentValidation;

namespace Application.Validators.Comment
{
    public class ChangeCommentStatusCommandValidator : AbstractValidator<ChangeCommentStatusCommand>
    {
        public ChangeCommentStatusCommandValidator()
        {
            RuleFor(x => x.commentId)
                .NotNull().WithMessage("Comment[commentId] is null");

            RuleFor(x => x.Status)
                .NotNull().WithMessage("وضعیت کامنت را وارد کنید")
                .IsInEnum().WithMessage("وضعیت مورد نظر ثبت نشده است");
                

        }
    }
}
