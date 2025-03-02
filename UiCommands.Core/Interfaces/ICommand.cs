namespace UiCommands.Core.Interfaces;

internal interface ICommand
{
    public string Title { get; }
    
    public int Number { get; set; }

    public void Invoke(IExitable? exitable = null);
}