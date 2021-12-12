using System;
using Application.Validators.Schedule;

namespace Application.Commands.Schedule
{
    public class CapacityCommand : CommandBase
    {
        /// <summary>
        /// schedule ID
        /// </summary>
        public Guid ScheduleId { get; set; }

        /// <summary>
        /// فضای سانس
        /// </summary>
        public int Capacity { get; set; }

        public override bool Validate()
        {
            return new CapacityCommandValidator().Validate(this).IsValid;
        }
    }
}
