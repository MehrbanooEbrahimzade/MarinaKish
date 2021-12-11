using System;
using Marina_Club.Validators.Conversation;

namespace Marina_Club.Commands.Conversation
{
    public class SearchMessageCommand : CommandBase
    {
        /// <summary>
        /// آیدی تالار گفت و گو
        /// </summary>
        public Guid ConversationId { get; set; }

        /// <summary>
        /// باکس جست و جوی پیام
        /// </summary>
        public string SearchBox { get; set; }

        public override bool Validate()
        {
            return new SearchMessageCommandValidator().Validate(this).IsValid;
        }
    }
}
