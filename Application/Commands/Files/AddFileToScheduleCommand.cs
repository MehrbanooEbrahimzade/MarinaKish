using System;
using Application.Validators.Files;

namespace Application.Commands.Files
{
    public class AddFileToScheduleCommand : CommandBase
    {
        /// <summary>
        /// آیدی تفریح
        /// </summary>
        public Guid ScheduleID { get; set; }

        /// <summary>
        /// آیدی فایل/عکس
        /// </summary>
        public Guid FileID { get; set; }

        /// <summary>
        /// Command Validation
        /// </summary>
        public override bool Validate()
        {
            return new AddFileToScheduleCommandValidator().Validate(this).IsValid;
          
        }
    }
}
