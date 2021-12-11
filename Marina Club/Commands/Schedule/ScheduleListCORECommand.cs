using Marina_Club.Validators.Schedule;
using System;
using System.Collections.Generic;

namespace Marina_Club.Commands.Schedule
{
    public class ScheduleListCORECommand : CommandBase
    {
        /// <summary>
        /// آی دی ها
        /// </summary>
        public List<Guid> IDs { get; set; }

        /// <summary>
        /// وجود داشتن سانس
        /// </summary>
        public bool IsExist { get; set; }

        public override bool Validate()
        {
            return new ScheduleListCORECommandValidator().Validate(this).IsValid;
        }
    }
}
