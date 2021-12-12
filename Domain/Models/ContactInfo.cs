using System;

namespace Domain.Models
{
    public class ContactInfo
    {
        public ContactInfo()
        { 
        }

        /// <summary>
        /// ID
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// تلفن ثابت
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// ایمیل
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// آدرس
        /// </summary>
        public string Address { get; set; }
    }
}