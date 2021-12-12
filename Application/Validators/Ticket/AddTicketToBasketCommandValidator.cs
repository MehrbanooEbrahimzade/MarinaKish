using Application.Commands.Ticket;
using FluentValidation;

namespace Application.Validators.Ticket
{
    public class AddTicketToBasketCommandValidator : AbstractValidator<AddTicketToBasketCommand>
    {
        public AddTicketToBasketCommandValidator()
        {

            RuleFor(x => x.ScheduleId)
                .NotNull().WithMessage("شناسه سانس مورد نظر برای تهیه بلیط را وارد کنید");

            RuleFor(x => x.NumberOfTicket)
                .NotNull().WithMessage("تعداد بلیط درخواست شده را وارد کنید")
                .GreaterThanOrEqualTo(1).WithMessage("تعداد بلیط درخواست شده باید 1 یا بیشتر باشد")
                .LessThanOrEqualTo(10).WithMessage("تعداد بلیط درخواست شده حداکثر میتواند 10 تا باشد");

            RuleFor(x => x.UserId)
                .NotNull().WithMessage("آیدی کاربر را وارد کنید");
        }
    }
}
