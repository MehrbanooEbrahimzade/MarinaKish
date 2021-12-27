using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Domain.Models
{
    public class ContactUs
    {
        public ContactUs(string aboutMariana,string rules,string email,string phoneNumber ,string urlLinkedin, string urlInstagram)
        {
            Id = Guid.NewGuid();
            AboutMariana = aboutMariana;
            Rules = rules;
            Email = email;
            PhoneNumber = phoneNumber;
            UrlLinkedin = urlLinkedin;
            UrlInstagram = urlInstagram;
        } 

        /// <summary>
        /// آیدی 
        /// </summary>
        public Guid Id { get;  private set; }

        /// <summary>
        /// درباره ماریانا
        /// </summary>
        public string AboutMariana { get; private set; }

        /// <summary>
        /// متن قوانین ماریانا
        /// </summary>
        public string Rules { get; private set; }

        /// <summary>
        /// ایمیل
        /// </summary>
        public string Email { get; private set; }

        /// <summary>
        /// شماره تماس
        /// </summary>
        public string PhoneNumber { get; private set; }

        /// <summary>
        /// آدرس لینک دین
        /// </summary>
        public string UrlLinkedin { get; private set; }

        /// <summary>
        /// آدرس اینستاگرام
        /// </summary>
        public string  UrlInstagram { get; private set; }
    }
}
