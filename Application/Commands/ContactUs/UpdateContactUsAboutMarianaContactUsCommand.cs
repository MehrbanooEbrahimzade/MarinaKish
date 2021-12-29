using System;
using Application.Validators.ContactUs;

namespace Application.Commands.ContactUs
{
    public class UpdateContactUsAboutMarianaContactUsCommand : CommandBase
    {
        /// <summary>
        /// آیدی
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// درباره ماریانا
        /// </summary>
        public string AboutMariana { get; set; }

        public override bool Validate()
        {
            return new UpdateContactUsAboutMarianaContactUsCommandValidator().Validate(this).IsValid;
        }
    }
}
