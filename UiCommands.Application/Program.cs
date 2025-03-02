using UiCommands.Core.Selectors;

namespace UiCommands.Application;

public static class Program
{
    public static void Main()
    {
        var number = Choosing.GetNumber("number", 1, 3);
        Console.WriteLine(number);
    }
}