using Application.Commands.ContactUs;
using FluentValidation;

namespace Application.Validators.ContactUs
{
    public class UpdateContactUsEmailCommandValidator : AbstractValidator<UpdateContactUsEmailCommand>
    {
        public UpdateContactUsEmailCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotNull().WithMessage("آیدی نمی تواند خالی باشد");

            RuleFor(x => x.Email)
                .NotNull().WithMessage("ایمیل نمی تواند خالبی باشد")
                .NotEmpty().WithMessage("ایمیل را وارد کنید");
        }
    }
}
