using Application.Validators.Message;
using System;

namespace Application.Commands.Message
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
        public string Text { get; internal set; }

        public override bool Validate()
        {
            return new EditMessageCommandValidator().Validate(this).IsValid;
        }
    }
}
