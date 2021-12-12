using Application.Commands.User;
using FluentValidation;

namespace Application.Validators.User
{
    public class AddSellerTicketCommandValidator : AbstractValidator<AddSellerTicketCommand>
    {
        public AddSellerTicketCommandValidator()
        {
            RuleFor(x => x.ScheduleId)
                .NotNull().WithMessage("آیدی سانس نمیتواند خالی باشد");

            RuleFor(x => x.NumberOfTicket)
                .GreaterThan(0).WithMessage("تعداد بلیط های درخواستی فروشنده باید بیشتر از 0 باشد")
                .NotNull().WithMessage("تعداد بلیط های درخواستی فروشنده نمیتواند خالی باشد");

            RuleFor(x => x.SellerId)
                .NotNull().WithMessage("آیدی فروشنده نمیتواند خالی باشد");
        }
    }
}
