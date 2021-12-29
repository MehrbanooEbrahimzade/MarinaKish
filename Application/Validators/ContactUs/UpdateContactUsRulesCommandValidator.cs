using Application.Commands.ContactUs;
using FluentValidation;

namespace Application.Validators.ContactUs
{
    public class UpdateContactUsRulesCommandValidator : AbstractValidator<UpdateContactUsRulesCommand>
    {
        public UpdateContactUsRulesCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotNull().WithMessage("آیدی نمی تواند خالی باشد");

            RuleFor(x => x.Rules)
                .NotNull().WithMessage("قسمت قوانین نمی تواند خالبی باشد")
                .NotEmpty().WithMessage("قوانین را وارد کنید");
        }
    }
}
