namespace UiCommands.Core.Selectors;

public static class Choosing
{
    public static string GetText(string name)
    {
        Console.Write($"Введіть {name}: ");
        return Console.ReadLine() ?? string.Empty;
    }

    public static int GetNumber(string name, int? min, int? max)
    {
        var hasMin = min != null;
        var hasMax = max != null;
        var hasConditions = hasMin || hasMax;
        var maxText = hasMax ? $"меньше рівне ніж {max}" : string.Empty;
        var minText = hasMin ? $"більше рівне за {min}" : string.Empty;
        var start = hasConditions ? "(" : string.Empty;
        var end = hasConditions ? ")" : string.Empty;
        var middle = hasMin && hasMax ? " та " : string.Empty;
        var fullText = $"{name}{start}{minText}{middle}{maxText}{end}";
        int value;
        bool isError;
        do
        {
            Console.Write($"Введіть {fullText}: ");
            isError = TryGetParseNumber(Console.ReadLine() ?? string.Empty, out value) || (value < min || value > max);
            if (isError)
            {
                Console.WriteLine("Ви ввели не правильнк значення, спробуйте ше.");
            }
        } while (isError);
        return value;
    }

    private static bool TryGetParseNumber(string text, out int value)
    {
        var isNotNumber = text.Any(x => x is < '0' or > '9');
        var isNotParsed = int.TryParse(text, out value) == false;
        return isNotParsed || isNotNumber;
    }
}