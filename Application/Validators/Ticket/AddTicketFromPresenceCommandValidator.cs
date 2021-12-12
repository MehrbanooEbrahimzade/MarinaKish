using Application.Commands.Ticket;
using FluentValidation;

namespace Application.Validators.Ticket
{
    public class AddTicketFromPresenceCommandValidator : AbstractValidator<AddTicketFromPresenceCommand>
    {
        public AddTicketFromPresenceCommandValidator()
        {
            RuleFor(x => x.ScheduleId)
                .NotNull().WithMessage("شناسه سانس مورد نظر برای تهیه بلیط را وارد کنید");

            RuleFor(x => x.NumberOfTicket)
                .NotNull().WithMessage("تعداد بلیط درخواست شده را وارد کنید")
                .GreaterThanOrEqualTo(1).WithMessage("تعداد بلیط درخواست شده باید 1 یا بیشتر باشد")
                .LessThanOrEqualTo(10).WithMessage("تعداد بلیط درخواست شده حداکثر میتواند 10 تا باشد");

            RuleFor(x => x.UserCellPhone)
                .NotNull().WithMessage("شماره تلفن کاربر را وارد کنید")
                .NotEmpty().WithMessage("شماره تلفن کاربر نمیتواند خالی باشد")
                .MaximumLength(11).WithMessage("شماره تلفن کاربر باید 11 رقم باشد")
                .MinimumLength(11).WithMessage("شماره تلفن کاربر باید 11 رقم باشد");
        }
    }
}
