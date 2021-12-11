namespace Marina_Club.Commands.ContactInfo
{
    public class AddContactInfoCommand
    {

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
