using System;
using Marina_Club.Models.enums;
using Marina_Club.Validators.Comment;

namespace Marina_Club.Commands.Comment
{
    public class AddCommentCommand : CommandBase
    {

        /// <summary>
        /// پیام :
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// شناسه مدل تفریح :
        /// </summary>
        public Guid FunId { get; set; }

        /// <summary>
        /// شناسه کاربری
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Command Validation
        /// </summary>
        public override bool Validate()
        {
            return new AddCommentCommandValidator().Validate(this).IsValid;
        }
    }
}
