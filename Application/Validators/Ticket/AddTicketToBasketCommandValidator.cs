using Application.Commands.Ticket;
using FluentValidation;

namespace Application.Validators.Ticket
{
    public class AddTicketToBasketCommandValidator : AbstractValidator<AddTicketToBasketCommand>
    {
        public AddTicketToBasketCommandValidator()
        {

            RuleFor(x => x.FunName)
                .NotNull().WithMessage("");

            RuleFor(x => x.Gender)
                .NotNull().WithMessage("");

            RuleFor(x => x.BoughtPlace)
                .NotNull().WithMessage("");

            RuleFor(x => x.PhoneNumber)
                .NotNull().WithMessage("")
                .Length(11);
            


            RuleFor(x => x.ScheduleId)
                .NotNull().WithMessage("شناسه سانس مورد نظر برای تهیه بلیط را وارد کنید");

        }   
    }
}
