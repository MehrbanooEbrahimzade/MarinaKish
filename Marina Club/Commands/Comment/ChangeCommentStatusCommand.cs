using System;
using Marina_Club.Models.enums;
using Marina_Club.Validators.Comment;

namespace Marina_Club.Commands.Comment
{
    public class ChangeCommentStatusCommand : CommandBase
    {
        /// <summary>
        /// ID 
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// تایید شدن
        /// </summary>
        public EStatus Status { get; set; }

        /// <summary>
        /// Command Validation
        /// </summary>
        public override bool Validate()
        {
            return new ChangeCommentStatusCommandValidator().Validate(this).IsValid;
        }
    }
}
