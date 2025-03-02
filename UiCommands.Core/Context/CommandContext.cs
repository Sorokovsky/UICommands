using UiCommands.Core.Commands;
using UiCommands.Core.Interfaces;
using UiCommands.Core.Selectors;

namespace UiCommands.Core.Context;

public sealed class CommandContext : ICommandContext
{
    private int _currentNumber;
    
    private bool _canExit;
    
    private readonly List<BaseCommand> _commands = [];
    
    public CommandContext(string title)
    {
        Title = title;
    }

    public string Title { get; }
    
    public int Number { get; set; }
    
    public void Invoke(IExitable? exitable = null)
    {
        _canExit = false;
        AppendCommands(new ExitCommand());
        Loop();
    }

    public void AppendCommands(params BaseCommand[] commands)
    {
        commands.ToList().ForEach(command =>
        {
            command.Number = _currentNumber++;
            _commands.Add(command);
        });
    }

    public void Exit()
    {
        _canExit = true;
    }

    private void Loop()
    {
        try
        {
            while (_canExit is false)
            {
                ChooseCommand().Invoke(this);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Сталася помилка: \"{e.Message}\".");
        }
    }

    private ICommand ChooseCommand()
    {
        return Choosing.GetFromList(
            _commands,
            Title,
            item => item.ToString(),
            int.Parse,
            (first, second) => first == second.Number 
        );
    }
}