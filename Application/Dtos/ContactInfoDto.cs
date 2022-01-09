using System;


namespace Application.Dtos
{
    public class ContactInfoDto
    {
        /// <summary>
        /// commentId 
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// تلفن ثابت
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// تلفن همراه
        /// </summary>
        public string CellPhone { get; set; }

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
