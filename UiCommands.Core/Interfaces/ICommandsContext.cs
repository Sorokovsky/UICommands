namespace UiCommands.Core.Interfaces;

public interface ICommandsContext : ICommand
{
    public void Exit();

    public void Add(params ICommand[] commands);
}