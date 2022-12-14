using System;
using Application.Validators.User;

namespace Application.Commands.User
{
    public class UpdateUserWithIdCommand : CommandBase
    {
        /// <summary>
        /// commentId 
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// فعال بودن کاربر
        /// </summary>
        public bool IsActive { get; set; }

        public override bool Validate()
        {
            return new UpdateUserWithIdCommandValidator().Validate(this).IsValid;

        }
    }
}
