using Application.Commands.ContactUs;
using FluentValidation;

namespace Application.Validators.ContactUs
{
    public class AddContactUsCommandValidator : AbstractValidator<AddContactUsCommand>
    {
        public AddContactUsCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotNull().WithMessage("آیدی نمی تواند خالی باشد");

            RuleFor(x => x.AboutMariana)
                .NotNull().WithMessage("قسمت درباره ما نمی تواند خالبی باشد")
                .NotEmpty().WithMessage("درباره ما را وارد کنید");

            RuleFor(x=>x.Rules)
                .NotNull().WithMessage("قسمت قوانین نمی تواند خالبی باشد")
                .NotEmpty().WithMessage("قوانین را وارد کنید");

            RuleFor(x => x.Email)
                .NotNull().WithMessage("ایمیل نمی تواند خالبی باشد")
                .NotEmpty().WithMessage("ایمیل را وارد کنید");

            RuleFor(x=>x.PhoneNumber)
                .NotNull().WithMessage("شماره تماس نمی تواند خالبی باشد")
                .NotEmpty().WithMessage("شماره تماس را وارد کنید");

            RuleFor(x=>x.UrlInstagram)
                .NotNull().WithMessage("آدرس اینستاگرام نمی تواند خالبی باشد")
                .NotEmpty().WithMessage("آدرس اینستاگرام را وارد کنید");

            RuleFor(x=>x.UrlLinkedin)
                .NotNull().WithMessage("آدرس لینکدین نمی تواند خالبی باشد")
                .NotEmpty().WithMessage("آدرس لینکدین را وارد کنید");
        }
    }
}
