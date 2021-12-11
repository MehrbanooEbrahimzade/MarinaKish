using System;
using System.Net;
using System.Web.Http;
using Marina_Club.Validators.Schedule;

namespace Marina_Club.Commands.Schedule
{
    public class CancelOrReExistScheduleCommand : CommandBase
    {
        /// <summary>
        /// آیدی سانس
        /// </summary>
        public Guid ScheduleId { get; set; }

        /// <summary>
        /// چک کننده ی وجود داشتن سانس :
        /// </summary>
        public bool IsExist { get; set; }

        public override bool Validate()
        {
            return new CancelOrReExistScheduleCommandValidator().Validate(this).IsValid;
        }
    }
}
