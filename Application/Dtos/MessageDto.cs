using System;
using Domain.Models.enums;

namespace Application.Dtos
{
    public class MessageDto
    {

        /// <summary>
        /// ID
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// زمان فرستاده شدن پیامک
        /// </summary>
        public string ShamsiPlaceDate { get; set; }

        /// <summary>
        /// نام کاربری فرستنده
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// پیام
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// آیدی تالار گفت و گو
        /// </summary>
        public Guid ConversationID { get; set; }

        /// <summary>
        /// وضعیت پیام
        /// </summary>
        public EMessageStatus MessageStatus { get; set; }
    }
}
