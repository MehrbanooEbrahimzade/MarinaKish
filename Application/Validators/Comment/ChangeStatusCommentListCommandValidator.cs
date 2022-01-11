using Application.Commands.Comment;
using FluentValidation;

namespace Application.Validators.Comment
{
    public class ChangeStatusCommentListCommandValidator : AbstractValidator<ChangeStatusCommentListCommand>
    {
        public ChangeStatusCommentListCommandValidator()
        {
            RuleFor(x => x.IDs)
                .NotNull().WithMessage("Comment[commentId] is null. you must enter at least 1 id");

     
        }
    }
}
