using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Comment
{
    public class ScheduleInfoCommand
    {
        public TimeSpan StartTime { get; private set; }

        public TimeSpan EndTime { get; private set; }

        public int GapTime { get; private set; }
        
        public int Duration { get; private set; }

        public int TotalCapacity { get; private set; }

        
        public int PresenceCapacity { get; private set; }

        
        public int OnlineCapacity { get; private set; }

        
        public decimal Amount { get; private set; }

    }
}
