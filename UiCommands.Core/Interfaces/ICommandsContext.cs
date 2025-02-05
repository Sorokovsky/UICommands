namespace UiCommands.Core.Interfaces;

public interface ICommandsContext : ICommand, IExitable
{
    public void Add(params ICommand[] commands);
}