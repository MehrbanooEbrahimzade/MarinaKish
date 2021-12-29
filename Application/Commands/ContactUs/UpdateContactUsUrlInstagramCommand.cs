using System;
using Application.Validators.ContactUs;

namespace Application.Commands.ContactUs
{
    public class UpdateContactUsUrlInstagramCommand :CommandBase
    {
        /// <summary>
        /// آیدی
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// آدرس اینستگرام
        /// </summary>
        public string UrlInstagram { get; set; }
    
        public override bool Validate()
        {
            return new UpdateContactUsUrlInstagramCommandValidator().Validate(this).IsValid;
        }
    }
}
