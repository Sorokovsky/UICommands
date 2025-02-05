using UiCommands.Core.Interfaces;

namespace UiCommands.Core.Commands;

internal class ExitCommand : ICommand
{
    public int Number { get; set; }
    public string Title { get; set; } = "Вийти.";
    public void Invoke(ICommandsContext context)
    {
        context.Exit();
    }
}