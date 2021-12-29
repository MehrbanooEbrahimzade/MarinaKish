using System;
using Application.Validators.ContactUs;

namespace Application.Commands.ContactUs
{
    public class UpdateContactUsPhoneNumberCommand : CommandBase
    {
        /// <summary>
        /// آیدی
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// شماره تماس
        /// </summary>
        public string PhoneNumber { get; set; }


        public override bool Validate()
        {
            return new UpdateContactUsPhoneNumberCommandValidator().Validate(this).IsValid;
        }
    }
}
