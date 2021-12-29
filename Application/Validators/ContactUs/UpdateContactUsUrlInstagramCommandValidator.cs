using Application.Commands.ContactUs;
using FluentValidation;

namespace Application.Validators.ContactUs
{
    public class UpdateContactUsUrlInstagramCommandValidator : AbstractValidator<UpdateContactUsUrlInstagramCommand>
    {
        public UpdateContactUsUrlInstagramCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotNull().WithMessage("آیدی نمی تواند خالی باشد");

            RuleFor(x => x.UrlInstagram)
                .NotNull().WithMessage("آدرس اینستاگرام نمی تواند خالبی باشد")
                .NotEmpty().WithMessage("آدرس اینستاگرام را وارد کنید");
        }
    }
}
