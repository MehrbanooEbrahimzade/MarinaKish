namespace Application.Commands
{
    public abstract class CommandBase : ICommandBase
    {
        public abstract bool Validate();
    }
}
