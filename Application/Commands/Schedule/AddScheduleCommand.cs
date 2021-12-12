using System;
using Application.Validators.Schedule;

namespace Application.Commands.Schedule
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
