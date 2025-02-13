using UiCommands.Core.Contexts;

namespace UiCommands.Application;

public static class Program
{
    public static void Main()
    {
        var context = new CommandsContext("Test");
        context.Invoke();
    }
}