using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.ContactUs
{
    public class AddContactUsCommand
    {
        /// <summary>
        /// آیدی 
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// درباره ماریانا
        /// </summary>
        public string AboutMariana { get; set; }

        /// <summary>
        /// متن قوانین ماریانا
        /// </summary>
        public string Rules { get; set; }

        /// <summary>
        /// ایمیل
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// شماره تماس
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// آدرس لینک دین
        /// </summary>
        public string UrlLinkedin { get; set; }

        /// <summary>
        /// آدرس اینستاگرام
        /// </summary>
        public string UrlInstagram { get; set; }
    }
}
