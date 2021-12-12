using Application.Validators.Files;
using System;

namespace Application.Commands.Files
{
    public class AddFileToUserCommand : CommandBase
    {
        /// <summary>
        /// آیدی کاربر
        /// </summary>
        public Guid UserID { get; set; }

        /// <summary>
        /// آیدی عکس
        /// </summary>
        public Guid FileID { get; set; }

        /// <summary>
        /// Command Validation
        /// </summary>
        public override bool Validate()
        {
            return new AddFileToUserCommandValidator().Validate(this).IsValid;
        }
    }
}
