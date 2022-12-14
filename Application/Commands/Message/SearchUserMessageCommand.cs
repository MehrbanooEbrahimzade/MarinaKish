using Application.Validators.Message;
using System;

namespace Application.Commands.Message
{
    public class SearchUserMessageCommand : CommandBase
    {
        /// <summary>
        /// آیدی کاربر
        /// </summary>
        public Guid Userid { get; set; }

        /// <summary>
        /// باکس جست و جوی پیام کاربر
        /// </summary>
        public string SearchBoxUserMessage { get; set; }

        public override bool Validate()
        {
            return new SearchUserMessageCommandValidator().Validate(this).IsValid;
        }
    }
}
