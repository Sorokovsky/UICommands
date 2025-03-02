using System.Text;
using UiCommands.Core.Context;

namespace UiCommands.Application;

public static class Program
{
    public static void Main()
    {
        var context = new CommandContext("Головне меню", Encoding.UTF8);
        context.Invoke();
    }
}