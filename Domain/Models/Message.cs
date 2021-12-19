using System;
using Domain.Enums;

namespace Domain.Models
{
    public class Message : Writ
    {
        public Message(string username, string text, Guid conversationId): base( username,  text)
        {
            Id = Guid.NewGuid();
          
            UserName = username;
            
            Text = text;
            
            ConversationId = conversationId;
            
            MessageStatus = MessageStatus.Sent;
            
            SubmitDate = DateTime.Now;
        }

        private Message(){ }

        /// <summary>
        /// وضعیت پیام
        /// </summary>
        public MessageStatus MessageStatus { get; private set; }

        /// <summary>
        /// آیدی تالار گفت و گو
        /// </summary>
        public Guid ConversationId { get; private set; }
        
    }
}
