using Application.Commands.ContactUs;
using FluentValidation;

namespace Application.Validators.ContactUs
{
    public class UpdateContactUsPhoneNumberCommandValidator : AbstractValidator<UpdateContactUsPhoneNumberCommand>
    {
        public UpdateContactUsPhoneNumberCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotNull().WithMessage("آیدی نمی تواند خالی باشد");

            RuleFor(x => x.PhoneNumber)
                .NotNull().WithMessage("شماره تماس نمی تواند خالبی باشد")
                .NotEmpty().WithMessage("شماره تماس را وارد کنید");
        }
    }
}
