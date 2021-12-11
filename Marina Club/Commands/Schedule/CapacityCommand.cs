using System;
using Marina_Club.Validators.Schedule;

namespace Marina_Club.Commands.Schedule
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
