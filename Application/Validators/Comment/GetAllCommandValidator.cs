using Application.Commands.Comment;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Validators.Comment
{
    public class GetAllCommandValidator : AbstractValidator<GetAllCommand>
    {

        public GetAllCommandValidator()
        {
            RuleFor(f => f.status)
                .NotNull().WithMessage(" تغییر وضعیت کامنت را وارد کنید")
                .IsInEnum().WithMessage("وضعیت کامنت تعریف نشده است");

        }

    }
}
