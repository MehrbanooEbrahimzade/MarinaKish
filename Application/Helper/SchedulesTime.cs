using System;

namespace Application.Helper
{
    public class SchedulesTime
    {
        public SchedulesTime(TimeSpan startTime, TimeSpan endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
        }
        public TimeSpan StartTime { get; private set; }
        public TimeSpan EndTime { get; private set; }

    }
}
