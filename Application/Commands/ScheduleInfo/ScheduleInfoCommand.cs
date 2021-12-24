using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.ScheduleInfo
{
    public class ScheduleInfoCommand: CommandBase
    {
        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public int GapTime { get; set; }
        
        public int Duration { get; set; }

        public int TotalCapacity { get; set; }

        
        public int PresenceCapacity { get; set; }

        
        public int OnlineCapacity { get; set; }

        
        public decimal Amount { get; set; }

        public override bool Validate()
        {
            return new AddSellerInfoCommandValidator().Validate(this).IsValid;

        }
    }
}
