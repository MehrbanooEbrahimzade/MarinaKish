using Application.Commands.ContactUs;
using FluentValidation;

namespace Application.Validators.ContactUs
{
    public class UpdateContactUsUrlLinkedinCommandValidator : AbstractValidator<UpdateContactUsUrlLinkedinCommand>
    {
        public UpdateContactUsUrlLinkedinCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotNull().WithMessage("آیدی نمی تواند خالی باشد");

            RuleFor(x => x.UrlLinkedin)
                .NotNull().WithMessage("آدرس لینکدین نمی تواند خالبی باشد")
                .NotEmpty().WithMessage("آدرس لینکدین را وارد کنید");
        }
    }
}
