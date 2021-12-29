using System;
using Application.Validators.ContactUs;

namespace Application.Commands.ContactUs
{
    public class UpdateContactUsEmailCommand : CommandBase
    {
        /// <summary>
        /// آیدی
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// ایمیل
        /// </summary>
        public string Email { get; set; }

        public override bool Validate()
        {
            return new UpdateContactUsEmailCommandValidator().Validate(this).IsValid;
        }
    }
}
