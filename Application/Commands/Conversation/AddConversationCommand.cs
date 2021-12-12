using Application.Validators.Conversation;

namespace Application.Commands.Conversation
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
