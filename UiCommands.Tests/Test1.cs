using UiCommands.Core.Contexts;

namespace UiCommands.Tests;

[TestClass]
public sealed class Test1
{
    [TestMethod]
    public void TestMethod1()
    {
        const string titleContext = "Головне меню.";
        var context = new CommandsContext(titleContext);
        Assert.AreEqual(0, context.Number);
        Assert.AreEqual(titleContext, context.Title);
    }
}