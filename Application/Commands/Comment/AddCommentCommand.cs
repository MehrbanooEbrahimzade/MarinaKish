using System;
using Application.Validators.Comment;

namespace Application.Commands.Comment
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
