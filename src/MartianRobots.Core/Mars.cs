namespace MartianRobots.Core;

public class Mars(int width, int height)
{
    private readonly HashSet<(int, int)> _scents = [];

    public bool IsOnGrid(int x, int y)
        => x >= 0 && x <= width && y >= 0 && y <= height;

    public void AddScent(int x, int y)
        => _scents.Add((x, y));

    public bool HasScent(int x, int y)
        => _scents.Contains((x, y));
}