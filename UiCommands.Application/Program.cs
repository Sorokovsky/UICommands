using UiCommands.Core.Context;

namespace UiCommands.Application;

public static class Program
{
    public static void Main()
    {
        var context = new CommandContext("Головне меню");
        context.Invoke();
    }
}