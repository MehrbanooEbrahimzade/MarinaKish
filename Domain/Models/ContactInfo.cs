using System;

namespace Domain.Models
{
    public class ContactInfo //TODO:delete 
    {
        public ContactInfo(string phone , string email , string address)
        {
            Id = Guid.NewGuid();
            Phone = phone;
            Address = address; 
        }

        /// <summary>
        /// ID
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// تلفن ثابت
        /// </summary>
        public string Phone { get; private set; }

        /// <summary>
        /// ایمیل
        /// </summary>
        public string Email { get;private set; }

        /// <summary>
        /// آدرس
        /// </summary>
        public string Address { get;private set; }
        public ContactInfo()
        {

        }
    }
}