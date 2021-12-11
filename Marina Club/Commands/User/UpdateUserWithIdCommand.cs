using System;
using System.Net;
using System.Web.Http;
using Marina_Club.Validators.User;

namespace Marina_Club.Commands.User
{
    public class UpdateUserWithIdCommand : CommandBase
    {
        /// <summary>
        /// ID 
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
