using Application.Validators;
using System;
using Domain.Models.enums;

namespace Application.Commands.User
{
    public class UpdateUserCommand : CommandBase
    {
        /// <summary>
        /// ID
        /// </summary>
        public Guid ID { get; set; }

        /// <summary>
        /// نام
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// نام خانوادگی
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// استان
        /// </summary>
        public string Provice { get; set; }

        /// <summary>
        /// نام کاربری
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// جنسیت
        /// </summary>
        public EGender Gender { get; set; }

        /// <summary>
        /// تاریخ تولد
        /// </summary>
        public DateTime BirthDay { get; set; }

        /// <summary>
        /// Command Validation
        /// </summary>
        public override bool Validate()
        {
            return new UpdateUserCommandValidator().Validate(this).IsValid;
        }


    }

}
