using Marina_Club.Models.enums;
using System;

namespace Marina_Club.Models
{
    public class Message
    {
        public Message(Guid conversationID, Guid userID, string username, string massage)
        {
            ConversationID = conversationID;
            UserID = userID;
            UserName = username;
            message = massage;
            MessageStatus = EMessageStatus.Sent;
            PlaceDate = DateTime.Now;
        }

        /// <summary>
        /// ID
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// زمان فرستاده شدن پیامک
        /// </summary>
        public DateTime PlaceDate { get; set; }

        /// <summary>
        /// نام کاربری فرستنده
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// پیام
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// وضعیت پیام
        /// </summary>
        public EMessageStatus MessageStatus { get; set; }

        /// <summary>
        /// آیدی تالار گفت و گو
        /// </summary>
        public Guid ConversationID { get; set; }

        /// <summary>
        /// آیدی کاربر
        /// </summary>
        public Guid UserID { get; set; }

        private Message() {   }
    }
}
