namespace Marina_Club.Commands
{
    public abstract class CommandBase : ICommandBase
    {
        public abstract bool Validate();
    }
}
