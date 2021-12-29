using System;
using Application.Validators.ScheduleInfo;

namespace Application.Commands.ScheduleInfo
{
    public class UpdateScheduleInfoCommand: AddScheduleInfoCommand
    {
        public Guid Id { get; set; }
        public override bool Validate()
        {
            return new UpdateScheduleInfoCommandValidator().Validate(this).IsValid;
        }
    }
}
