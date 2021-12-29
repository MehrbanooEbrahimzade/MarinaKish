using Application.Commands.Ticket;
using FluentValidation;

namespace Application.Validators.Ticket
{
    public class AddTicketToBasketCommandValidator : AbstractValidator<AddTicketToBasketCommand>
    {
        public AddTicketToBasketCommandValidator()
        {

            RuleFor(x => x.FunName)
                .NotNull().WithMessage("اسم تفریخ نباید خالی باشد");

            RuleFor(x => x.Gender)
                .NotNull().WithMessage("جنسیت نباید خالی باشد");

            RuleFor(x => x.BoughtPlace)
                .NotNull().WithMessage("محل خرید نباید خالی باشد ");
            
            RuleFor(x => x.ScheduleId)
                .NotNull().WithMessage("شناسه سانس مورد نظر برای تهیه بلیط را وارد کنید");

        }   
    }
}
