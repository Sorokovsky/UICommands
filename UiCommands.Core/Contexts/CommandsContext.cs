using UiCommands.Core.Commands;
using UiCommands.Core.Interfaces;

namespace UiCommands.Core.Contexts;

public class CommandsContext : ICommandsContext
{
    private int _currentNumber;

    private readonly List<ICommand> _commands = [];
    
    private bool _isExit;
    
    public int Number { get; set; }
    
    public string Title { get; set; }

    public CommandsContext(string title)
    {
        Title = title;
        Add(new ExitCommand());
    }
    
    public void Invoke(ICommandsContext _)
    {
        try
        {
            _isExit = false;
            while (_isExit == false)
            {
                ChooseCommand().Invoke(this);
                Console.Write("Натисніть кнопку щоб продовжити.");
                Console.ReadKey();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void Exit()
    {
        _isExit = true;
    }

    public void Add(params ICommand[] commands)
    {
        foreach (var command in commands)
        {
            command.Number = _currentNumber++;
            _commands.Add(command);
        }
    }

    private ICommand ChooseCommand()
    {
        Console.WriteLine("Виберіть опцію.");
        _commands
            .Select(x => $"{x.Number}-{x.Title}.")
            .ToList()
            .ForEach(Console.WriteLine);
        Console.Write(">> ");
        var commandNumber = int.Parse(Console.ReadLine() ?? string.Empty);
        var command = _commands.FirstOrDefault(x => x.Number == commandNumber);
        if (command == null)
        {
            throw new Exception("Відповідь не розпізнано.");
        }

        return command;
    }
}