using System;
using System.Collections.Generic;

namespace Application.Helper
{
    public class ScheduleMaker
    {
        public List<SchedulesTime> MakeSchedule(TimeSpan startTime, TimeSpan endTime, int duration, int gapTime)
        {
            TimeSpan scheduleStartTime = startTime;
            TimeSpan scheduleEndTime = default;
            var schedulesTime = new List<SchedulesTime>();

            for (var i = 0; scheduleEndTime <= endTime; i++)
            {
                scheduleEndTime = scheduleStartTime + TimeSpan.FromMinutes(duration);

                schedulesTime.Add(new SchedulesTime(scheduleStartTime, scheduleEndTime));

                scheduleStartTime += TimeSpan.FromMinutes(duration + gapTime);
            }

            return schedulesTime;
        }
   
    }
}
