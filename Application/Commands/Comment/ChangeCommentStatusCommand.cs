using Domain.Models.enums;
using System;
using Application.Validators.Comment;

namespace Application.Commands.Comment
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
