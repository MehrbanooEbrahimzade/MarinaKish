using System;
using System.Net;
using System.Web.Http;
using Marina_Club.Validators.Schedule;

namespace Marina_Club.Commands.Schedule
{
    public class SearchScheduleByDateCommand : CommandBase
    {
        public PersianDateCommand FirstPersianDate { get; set; }
        public PersianDateCommand SecondPersianDate { get; set; }

        public override bool Validate()
        {
            return new SearchScheduleByDateCommandValidator().Validate(this).IsValid;

        }
    }
}
