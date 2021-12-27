using System;
using System.Collections.Generic;
using System.Text;
using Application.Validators.ScheduleInfo;
using Application.Validators.User;
using FluentValidation;

namespace Application.Commands.ScheduleInfo
{
    public class AddScheduleInfoCommand: CommandBase
    {
        public Guid FunId { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int GapTime { get; set; }
        
        public int Duration { get; set; }

        public int TotalCapacity { get; set; }

        
        public int PresenceCapacity { get; set; }

        
        public int OnlineCapacity { get; set; }

        
        public decimal Amount { get; set; }

        public override bool Validate()
        {
            return new AddScheduleInfoCommandValidator().Validate(this).IsValid;
        }
    }
}
