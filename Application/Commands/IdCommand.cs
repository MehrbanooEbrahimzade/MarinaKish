using System;
using Application.Validators;

namespace Application.Commands
{
    public class IdCommand : CommandBase
    {
        /// <summary>
        /// ID
        /// </summary>
        public Guid ID { get; set; }

        /// <summary>
        /// Command validation
        /// </summary>
        public override bool Validate()
        {
            return new IdCommandValidator().Validate(this).IsValid;
        }
    }
}
