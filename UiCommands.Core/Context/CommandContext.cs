using System.Text;
using UiCommands.Core.Commands;
using UiCommands.Core.Interfaces;
using UiCommands.Core.Selectors;

namespace UiCommands.Core.Context;

public sealed class CommandContext : ICommandContext
{
    private int _currentNumber;
    
    private bool _canExit;
    
    private readonly Encoding _encoding;
    
    private Encoding _currentInputEncoding;
    private Encoding _currentOutputEncoding;
    
    private readonly List<ICommand> _commands = [];
    
    public CommandContext(string title, Encoding encoding)
    {
        Title = title;
        _encoding = encoding;
    }

    public string Title { get; }
    
    public int Number { get; set; }
    
    public void Invoke(IExitable? exitable = null)
    {
        _canExit = false;
        AppendCommands(new ExitCommand());
        Loop();
    }

    public void AppendCommands(params ICommand[] commands)
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
        SetupEncoding();
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
        ClearEncoding();
    }

    private ICommand ChooseCommand()
    {
        return Choosing.GetFromList(
            _commands,
            Title,
            item => item.ToString() ?? string.Empty,
            int.Parse,
            (first, second) => first == second.Number 
        );
    }

    private void SetupEncoding()
    {
        _currentInputEncoding = Console.InputEncoding;
        _currentOutputEncoding = Console.OutputEncoding;
        Console.OutputEncoding = _encoding;
        Console.InputEncoding = _encoding;
    }

    private void ClearEncoding()
    {
        Console.OutputEncoding = _currentOutputEncoding;
        Console.InputEncoding = _currentInputEncoding; 
    }
}