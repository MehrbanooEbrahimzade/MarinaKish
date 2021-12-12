using System;
using Application.Validators.Conversation;

namespace Application.Commands.Conversation
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
