using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Application.Commands.Comment;

namespace Marina_Club.Controllers
{
    public class ScheduleInformationController : ControllerBase
    {
        public void AddScheduleInfo(ScheduleInfoCommand command)
        {
            var scheduleInfo = new ScheduleInfo(command.StartTime, command.EndTime, command.GapTime, command.Duration,
                command.TotalCapacity, command.PresenceCapacity, command.OnlineCapacity, command.Amount);


            //var schedule = new Schedule()
            //    (DateTime date, TimeSpan start, TimeSpan end, decimal price, Guid funId
        }

    }
}
