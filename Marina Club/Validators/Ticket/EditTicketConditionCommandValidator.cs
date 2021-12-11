using FluentValidation;
using Marina_Club.Commands.Ticket;

namespace Marina_Club.Validators.Ticket
{
    public class EditTicketConditionCommandValidator : AbstractValidator<EditTicketConditionCommand>
    {
        public EditTicketConditionCommandValidator()
        {
            RuleFor(x => x.ChangeCondition)
                .NotNull().WithMessage("لطفا وضعیتی که میخواهید بلیط تغییر کند را وارد کنید")
                .IsInEnum().WithMessage("1-InActive, 2-Reservation, 3-Cancel");
        }
    }
}
