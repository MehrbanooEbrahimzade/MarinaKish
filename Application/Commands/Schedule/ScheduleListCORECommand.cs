using Application.Validators.Schedule;
using System;
using System.Collections.Generic;

namespace Application.Commands.Schedule
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
