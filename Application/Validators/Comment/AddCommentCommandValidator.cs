using Application.Commands.Comment;
using FluentValidation;

namespace Application.Validators.Comment
{
    public class AddCommentCommandValidator : AbstractValidator<AddCommentCommand>
    {
        public AddCommentCommandValidator()
        {
            RuleFor(x => x.Message)
                .NotNull().WithMessage("لطفا پیام خودرا وارد کنید")
                .NotEmpty().WithMessage("پیام شما نمیتواند خالی باشد")
                .MaximumLength(250).WithMessage("پیام نمیتواند بیشتر از 250 کاراکتر باشد");

            RuleFor(x => x.FunId)
                .NotNull().WithMessage("آیدی تفریح نمیتواند خالی باشد");

            RuleFor(x => x.UserId)
                .NotNull().WithMessage("آیدی کاربر نمیتواند خالی باشد");
        }
    }
}
