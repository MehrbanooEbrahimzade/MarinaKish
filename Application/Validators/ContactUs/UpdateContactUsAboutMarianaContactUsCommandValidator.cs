using Application.Commands.ContactUs;
using FluentValidation;

namespace Application.Validators.ContactUs
{
    public class UpdateContactUsAboutMarianaContactUsCommandValidator : AbstractValidator<UpdateContactUsAboutMarianaContactUsCommand>
    {
        public UpdateContactUsAboutMarianaContactUsCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotNull().WithMessage("آیدی نمی تواند خالی باشد");

            RuleFor(x => x.AboutMariana)
                .NotNull().WithMessage("قسمت درباره ما نمی تواند خالبی باشد")
                .NotEmpty().WithMessage("درباره ما را وارد کنید");
        }
    }
}
