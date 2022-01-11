    using System;
using System.Collections.Generic;
using Application.Validators.Comment;
using Domain.Enums;

namespace Application.Commands.Comment
{
    public class ChangeStatusCommentListCommand : CommandBase
    {
        /// <summary>
        /// آی دی ها
        /// </summary>
        public List<Guid> IDs { get; set; }

        public override bool Validate()
        {
            return new ChangeStatusCommentListCommandValidator().Validate(this).IsValid;
        }
    }
}
