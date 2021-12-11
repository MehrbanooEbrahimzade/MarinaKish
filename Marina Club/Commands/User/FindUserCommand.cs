﻿using Marina_Club.Validators.User;

namespace Marina_Club.Commands.User
{
    public class FindUserCommand : CommandBase
    {

        /// <summary>
        /// نام کاربری یا نام و نام خانوادگی
        /// </summary>
        public string UserNameOrFullName { get; set; }

        /// <summary>
        /// Command Validation
        /// </summary>
        public override bool Validate()
        {
            return new FindUserCommandValidator().Validate(this).IsValid;
        }
    }
}
