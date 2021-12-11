using Marina_Club.Validators.Message;
using System;

namespace Marina_Club.Commands.Message
{
    public class AddMessageCommand : CommandBase
    {
        /// <summary>
        /// آیدی تالار گفت و گو
        /// </summary>
        public Guid ConversationID { get; set; }

        /// <summary>
        /// آیدی کاربر
        /// </summary>
        public Guid UserID { get; set; }

        /// <summary>
        /// نام کاربری فرستنده
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// پیام
        /// </summary>
        public string Message { get; set; }

        public override bool Validate()
        {
            return new AddMessageCommandValidator().Validate(this).IsValid;
        }
    }
}
