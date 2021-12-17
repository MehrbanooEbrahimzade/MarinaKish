using System;
using Application.Validators.Comment;
using Domain.Enums;

namespace Application.Commands.Comment
{
    public class AddCommentCommand : CommandBase
    {
        
        public string Message { get; set; }
        public Guid FunId { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public FunType FunType { get; set; }
        public string  PhoneNumber { get; set; }


        /// <summary>
        /// Command Validation
        /// </summary>
        public override bool Validate()
        {
            return new AddCommentCommandValidator().Validate(this).IsValid;
        }
    }
}
