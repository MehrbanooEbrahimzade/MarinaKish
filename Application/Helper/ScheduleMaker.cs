using System;
using System.Collections.Generic;
using Application.Commands.ScheduleInfo;
using Domain.Models;

namespace Application.Helper
{
    public static class ScheduleMaker
    {
        public static List<Schedule> MakeSchedule(AddScheduleInfoCommand command)
        {
            DateTime date = command.StartDate;

            var schedules = new List<Schedule>();

            for (; date <= command.EndDate; date = date.AddDays(1))
            {
                TimeSpan scheduleStartTime = command.StartTime;
                TimeSpan scheduleEndTime = default;

                for (; scheduleEndTime <= command.EndTime;)
                {
                    scheduleEndTime = scheduleStartTime + TimeSpan.FromMinutes(command.Duration);

                    schedules.Add(new Schedule(date, scheduleStartTime, scheduleEndTime, command.Amount,
                        command.FunId));

                    scheduleStartTime += TimeSpan.FromMinutes(command.Duration + command.GapTime);
                }
            }

            return schedules;
        }
    }
}
