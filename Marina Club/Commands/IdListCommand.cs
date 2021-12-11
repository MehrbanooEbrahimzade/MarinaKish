using Marina_Club.Validators;
using System;
using System.Collections.Generic;

namespace Marina_Club.Commands
{
    public class IdListCommand : CommandBase
    {
        /// <summary>
        /// لیستی از آیدی ها
        /// </summary>
        public List<Guid> IDs { get; set; }

        /// <summary>
        /// Command Validation
        /// </summary>
        public override bool Validate()
        {
            return new IdListCommandValidator().Validate(this).IsValid;
        }
    }
}
