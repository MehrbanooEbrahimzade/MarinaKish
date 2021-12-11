using System;
using System.Net;
using System.Web.Http;
using Marina_Club.Models.enums;
using Marina_Club.Validators.Schedule;

namespace Marina_Club.Commands.Schedule
{
    public class AddScheduleCommand : CommandBase
    {
        /// <summary>
        /// تعداد روز برای ساختن سانس
        /// </summary>
        public int NumberOfDays { get; set; }

        /// <summary>
        /// آیدی تفریح
        /// </summary> 
        public Guid FunId { get; set; }


        public override bool Validate()
        {
            return new AddScheduleCommandValidator().Validate(this).IsValid;
        }
    }
}
