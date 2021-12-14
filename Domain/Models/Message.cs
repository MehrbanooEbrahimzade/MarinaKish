using System;
using Domain.Models.enums;

namespace Domain.Models
{
    public class Message
    {
        public Message(string username, string text, Guid conversationID, Guid userId)
        {
            Id = Guid.NewGuid();
            UserName = username;
            Text = text;
            ConversationID = conversationID;
            UserId = userId;
            MessageStatus = EMessageStatus.Sent;
            PlaceDate = DateTime.Now;
        }

        /// <summary>
        /// ID
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// نام کاربری فرستنده
        /// </summary>
        public string UserName { get; private set; }

        /// <summary>
        /// پیام
        /// </summary>
        public string Text { get; private set; }

        /// <summary>
        /// زمان فرستاده شدن پیامک
        /// </summary>
        public DateTime PlaceDate { get; private set; }

        /// <summary>
        /// وضعیت پیام
        /// </summary>
        public EMessageStatus MessageStatus { get; private set; }
        public void MessageStatusSet(EMessageStatus eMessageStatus)
        {
            this.MessageStatus = eMessageStatus;
        }

        /// <summary>
        /// آیدی تالار گفت و گو
        /// </summary>
        public Guid ConversationID { get; private set; }

        /// <summary>
        /// آیدی کاربر
        /// </summary>
        public Guid UserId { get; private set; }

        public Message()
        {

        }
    }
}
