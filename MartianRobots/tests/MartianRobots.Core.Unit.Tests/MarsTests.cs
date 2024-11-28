namespace MartianRobots.Core.Unit.Tests;

[TestFixture]
public class MarsTests
{
    [Test]
    public void Test_IsOnGrid()
    {
        var mars = new Mars(5, 3);

        Assert.IsTrue(mars.IsOnGrid(0, 0));
        Assert.IsTrue(mars.IsOnGrid(5, 3));
        Assert.IsFalse(mars.IsOnGrid(-1, 0));
        Assert.IsFalse(mars.IsOnGrid(6, 3));
        Assert.IsFalse(mars.IsOnGrid(3, 4));
    }

    [Test]
    public void Test_Scents()
    {
        var mars = new Mars(5, 3);

        Assert.IsFalse(mars.HasScent(1, 1));
        mars.AddScent(1, 1);
        Assert.IsTrue(mars.HasScent(1, 1));
    }
}