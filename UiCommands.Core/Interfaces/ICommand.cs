namespace UiCommands.Core.Interfaces;

public interface ICommand
{
    public int Number { get; set; }

    public string Title { get; set; }

    public void Invoke();
}