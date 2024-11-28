namespace MartianRobots.Core;

public class Robot(int x, int y, char orientation, Mars mars)
{
    private static readonly char[] Directions = ['N', 'E', 'S', 'W'];
    private int X { get; set; } = x;
    private int Y { get; set; } = y;
    private char Orientation { get; set; } = orientation;
    private bool IsLost { get; set; }
    private Mars Mars { get; } = mars;

    public void Execute(string instructions)
    {
        foreach (var instruction in instructions)
        {
            if (IsLost)
            {
                break;
            }

            switch (instruction)
            {
                case 'L': TurnLeft(); break;
                case 'R': TurnRight(); break;
                case 'F': MoveForward(); break;
                default: throw new ArgumentException($"Invalid instruction: {instruction}");
            }
        }
    }

    public string GetStatus()
    {
        return $"{X} {Y} {Orientation}" + (IsLost ? " LOST" : string.Empty);
    }

    private void TurnLeft()
    {
        var index = Array.IndexOf(Directions, Orientation);
        Orientation = Directions[(index + 3) % 4];
    }

    private void TurnRight()
    {
        var index = Array.IndexOf(Directions, Orientation);
        Orientation = Directions[(index + 1) % 4];
    }

    private void MoveForward()
    {
        if (IsLost) return;

        var newX = X;
        var newY = Y;

        switch (Orientation)
        {
            case 'N': 
                newY++; 
                break;
            case 'E': 
                newX++; 
                break;
            case 'S': 
                newY--; 
                break;
            case 'W': 
                newX--; 
                break;
        }

        if (!Mars.IsOnGrid(newX, newY))
        {
            if (!Mars.HasScent(X, Y))
            {
                Mars.AddScent(X, Y);
                IsLost = true;
            }
        }
        else
        {
            X = newX;
            Y = newY;
        }
    }
}