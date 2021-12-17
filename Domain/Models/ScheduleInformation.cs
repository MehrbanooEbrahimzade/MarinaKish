using System;

namespace Domain.Models
{
    public class ScheduleInformation
    {

        public ScheduleInformation(TimeSpan startTime, TimeSpan endTime, int gapTime, int duration, int totalCapacity, int presenceCapacity, int onlineCapacity, decimal amount)
        {
            Id = new Guid();
            StartTime = startTime;
            EndTime = endTime;
            GapTime = gapTime;
            Duration = duration;
            TotalCapacity = totalCapacity;
            PresenceCapacity = presenceCapacity;
            OnlineCapacity = onlineCapacity;
            Amount = amount;
        }

        public Guid Id { get; private set; }

        public TimeSpan StartTime { get; private set; }

        public TimeSpan EndTime { get; private set; }

        public int GapTime { get; private set; }

        public int Duration { get; private set; }

        public int TotalCapacity { get; private set; }

        public int PresenceCapacity { get; private set; }

        public int OnlineCapacity { get; private set; }

        public decimal Amount { get; private set; }



        private ScheduleInformation() { }
    }
}