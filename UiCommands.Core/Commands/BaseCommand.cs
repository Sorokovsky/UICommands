using UiCommands.Core.Interfaces;

namespace UiCommands.Core.Commands;

public abstract class BaseCommand : ICommand
{
    public int Number { get; set; }
    public abstract string Title { get; set; }
    public abstract void Invoke(IExitable exitor);
}