using System;
using Application.Validators.ContactUs;

namespace Application.Commands.ContactUs
{
    public class UpdateContactUsRulesCommand : CommandBase
    {
        /// <summary>
        /// آیدی
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// قوانین
        /// </summary>
        public string Rules { get; set; }

        public override bool Validate()
        {
            return new UpdateContactUsRulesCommandValidator().Validate(this).IsValid;
        }
    }
}
