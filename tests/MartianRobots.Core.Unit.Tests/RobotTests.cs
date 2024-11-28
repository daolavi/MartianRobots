namespace MartianRobots.Core.Unit.Tests;

[TestFixture]
public class RobotTests
{
    private Mars _sut;

    [SetUp]
    public void Setup()
    {
        _sut = new Mars(5, 3);
    }

    [Test]
    public void Test_TurnLeft()
    {
        var robot = new Robot(1, 1, 'N', _sut);
        robot.Execute("L");
        Assert.That(robot.GetStatus(), Is.EqualTo("1 1 W"));

        robot.Execute("L");
        Assert.That(robot.GetStatus(), Is.EqualTo("1 1 S"));

        robot.Execute("L");
        Assert.That(robot.GetStatus(), Is.EqualTo("1 1 E"));

        robot.Execute("L");
        Assert.That(robot.GetStatus(), Is.EqualTo("1 1 N"));
    }

    [Test]
    public void Test_TurnRight()
    {
        var robot = new Robot(1, 1, 'N', _sut);
        robot.Execute("R");
        Assert.That(robot.GetStatus(), Is.EqualTo("1 1 E"));

        robot.Execute("R");
        Assert.That(robot.GetStatus(), Is.EqualTo("1 1 S"));

        robot.Execute("R");
        Assert.That(robot.GetStatus(), Is.EqualTo("1 1 W"));

        robot.Execute("R");
        Assert.That(robot.GetStatus(), Is.EqualTo("1 1 N"));
    }

    [Test]
    public void Test_MoveForward_OnGrid()
    {
        var robot = new Robot(1, 1, 'N', _sut);
        robot.Execute("F");
        Assert.That(robot.GetStatus(), Is.EqualTo("1 2 N"));

        robot.Execute("R");
        robot.Execute("F");
        Assert.That(robot.GetStatus(), Is.EqualTo("2 2 E"));
    }

    [Test]
    public void Test_MoveForward_OutOfGrid()
    {
        var robot = new Robot(5, 3, 'N', _sut);
        robot.Execute("F");
        Assert.That(robot.GetStatus(), Is.EqualTo("5 3 N LOST"));

        // The robot leaves a scent at (5, 3)
        Assert.IsTrue(_sut.HasScent(5, 3));
    }

    [Test]
    public void Test_MoveForward_PreventLossDueToScent()
    {
        _sut.AddScent(5, 3); // Scent added at (5, 3)
        var robot = new Robot(5, 3, 'N', _sut);
        robot.Execute("F");
        Assert.That(robot.GetStatus(), Is.EqualTo("5 3 N")); // Robot doesn't get lost due to scent
    }

    [Test]
    public void Test_MultipleRobots()
    {
        var robot1 = new Robot(1, 1, 'E', _sut);
        robot1.Execute("RFRFRFRF");
        Assert.That(robot1.GetStatus(), Is.EqualTo("1 1 E"));
        
        var robot2 = new Robot(3, 2, 'N', _sut);
        robot2.Execute("FRRFLLFFRRFLL");
        Assert.That(robot2.GetStatus(), Is.EqualTo("3 3 N LOST"));

        var robot3 = new Robot(0, 3, 'W', _sut);
        robot3.Execute("LLFFFLFLFL");
        Assert.That(robot3.GetStatus(), Is.EqualTo("2 3 S"));
    }
}