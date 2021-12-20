using Application.Validators;
using System;
using Application.Validators.User;
using Domain.Enums;

namespace Application.Commands.User
{
    public class UpdateUserCommand : CommandBase
    {
        public Guid  Id { get; set; }
        /// <summary>
        /// نام
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// نام خانوادگی
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// تاریخ تولد
        /// </summary>
        public DateTime BirthDay { get; set; }

        /// <summary>
        /// کد ملی
        /// </summary>
        public string  NationalCode { get; set; }
        /// <summary>
        /// اطلاعات بانکی کاربر 
        /// </summary>
        /// <returns></returns>
        public UpdateCreditCard CreditCard { get; set;  }

        public override bool Validate()
        {
            return new UpdateUserCommandValidator().Validate(this).IsValid;
        }


    }

}
