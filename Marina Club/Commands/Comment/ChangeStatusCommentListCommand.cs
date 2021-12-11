using Marina_Club.Models.enums;
using Marina_Club.Validators.Comment;
using System;
using System.Collections.Generic;

namespace Marina_Club.Commands.Comment
{
    public class ChangeStatusCommentListCommand : CommandBase
    {
        /// <summary>
        /// آی دی ها
        /// </summary>
        public List<Guid> IDs { get; set; }

        /// <summary>
        /// وضعیت کامنت
        /// </summary>
        public EStatus Status { get; set; }

        public override bool Validate()
        {
            return new ChangeStatusCommentListCommandValidator().Validate(this).IsValid;
        }
    }
}
