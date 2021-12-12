using System;
using System.Net;
using System.Web.Http;
using Application.Validators.Schedule;

namespace Application.Commands.Schedule
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
