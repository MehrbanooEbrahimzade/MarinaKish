using Marina_Club.Validators.Conversation;

namespace Marina_Club.Commands.Conversation
{
    public class AddConversationCommand : CommandBase
    {
        /// <summary>
        /// عنوان
        /// </summary>
        public string Title { get; set; }

        public override bool Validate()
        {
            return new AddConversationCommandValidator().Validate(this).IsValid;

        }
    }
}
