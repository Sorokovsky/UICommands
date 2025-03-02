using UiCommands.Core.Interfaces;

namespace UiCommands.Core.Context;

public sealed class CommandContext : ICommandContext
{
    private bool _canExit;
    
    private readonly List<ICommand> _commands = [];
    
    public CommandContext(string title)
    {
        Title = title;
    }

    public string Title { get; }
    
    public int Number { get; set; }
    
    public void Invoke()
    {
        _canExit = false;
        Loop();
    }

    public void Exit()
    {
        _canExit = true;
    }

    private void Loop()
    {
        
    }
}