﻿using Marina_Club.Validators.User;
using System.Web.Http;

namespace Marina_Club.Commands.User
{
    public class ForgetPasswordCommand : CommandBase
    {
        /// <summary>
        /// شماره تلفن
        /// </summary>
        public string CellPhone { get; set; }

        /// <summary>
        /// رمزعبور جدید
        /// </summary>
        public string NewPassword { get; set; }

        /// <summary>
        /// تکرار رمزعبور جدید
        /// </summary>
        public string RepeatNewPassword { get; set; }

        /// <summary>
        /// کد تایید
        /// </summary>
        public string VerifyCode { get; set; }

        /// <summary>
        /// Command Validation
        /// </summary>
        public override bool Validate()
        {
            return new ForgetPasswordCommandValidator().Validate(this).IsValid;
        }
    }
}
