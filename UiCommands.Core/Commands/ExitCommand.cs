using UiCommands.Core.Interfaces;

namespace UiCommands.Core.Commands;

internal class ExitCommand : BaseCommand
{
    public override string Title { get; set; } = "Вийти";
    
    public override void Invoke(IExitable? exitor)
    {
        exitor?.Exit();
    }
}