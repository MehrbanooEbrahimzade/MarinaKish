using System;
using Application.Validators.ContactUs;

namespace Application.Commands.ContactUs
{
    public class UpdateContactUsUrlLinkedinCommand : CommandBase
    {
        /// <summary>
        /// آیدی
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// آدرس لینکدین
        /// </summary>
        public string UrlLinkedin { get; set; }


        public override bool Validate()
        {
            return new UpdateContactUsUrlLinkedinCommandValidator().Validate(this).IsValid;
        }
    }
}
