using System;
using Application.Validators.Comment;
using Domain.Enums;

namespace Application.Commands.Comment
{
    public class ChangeCommentStatusCommand : CommandBase
    {
        /// <summary>
        /// commentId 
        /// </summary>
        public Guid commentId { get; set; }

        /// <summary>
        /// تایید شدن
        /// </summary>
        public Status Status { get; set; }

        /// <summary>
        /// Command Validation
        /// </summary>
        public override bool Validate()
        {
            return new ChangeCommentStatusCommandValidator().Validate(this).IsValid;
        }
    }
}
