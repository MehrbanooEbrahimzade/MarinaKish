using Marina_Club.Validators.Message;
using System;

namespace Marina_Club.Commands.Message
{
    public class EditMessageCommand : CommandBase
    {
        /// <summary>
        /// آیدی پیام
        /// </summary>
        public Guid MessageID { get; set; }

        /// <summary>
        /// پیام برای ویرایش کردن
        /// </summary>
        public string EditedMessage { get; set; }

        public override bool Validate()
        {
            return new EditMessageCommandValidator().Validate(this).IsValid;

        }
    }
}
