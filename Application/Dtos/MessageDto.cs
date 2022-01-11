using System;
using Domain.Enums;

namespace Application.Dtos
{
    public class MessageDto
    {

        /// <summary>
        /// commentId
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
        public string Text { get; set; }

        /// <summary>
        /// آیدی تالار گفت و گو
        /// </summary>
        public Guid ConversationID { get; set; }

        /// <summary>
        /// وضعیت پیام
        /// </summary>
        public MessageStatus MessageStatus { get; set; }
        
    }
}
