using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services.classes
{
    public class ScheduleInfoService
    {
        public List<SchedulesTime> SchedulesMaker(TimeSpan StartTime, TimeSpan EndTime, int Duration, int GapTime)
        {
            TimeSpan startTime = StartTime;
            TimeSpan endTime = default;
            List<SchedulesTime> schedulesTime = new List<SchedulesTime>();

            for (int i = 0; endTime <= EndTime; i++)
            {
                endTime = startTime + TimeSpan.FromMinutes(Duration);

                schedulesTime.Add(new SchedulesTime(startTime, endTime));

                startTime += TimeSpan.FromMinutes(Duration + GapTime);
            }

            return schedulesTime;
        }
        public class SchedulesTime
        {
            public SchedulesTime(TimeSpan startTime, TimeSpan endTime)
            {
                StartTime = startTime;
                EndTime = endTime;
            }
            public TimeSpan StartTime { get; set; }
            public TimeSpan EndTime { get; set; }

        }
    }
}
