using System;
using Domain.Models.enums;

namespace Domain.Models
{
    public class Message: Writing
    {
        public Message(string username, string text, Guid conversationId, Guid userId)
        {
            Id = Guid.NewGuid();
            UserName = username;
            Text = text;
            ConversationId = conversationId;
            UserId = userId;
            MessageStatus = EMessageStatus.Sent;
            SubmitDate = DateTime.Now;
        }

        public Message() { }

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
        public Guid ConversationId { get; private set; }

        /// <summary>
        /// آیدی کاربر
        /// </summary>
        public Guid UserId { get; private set; }//TODO:DELETE
        
    }
}
