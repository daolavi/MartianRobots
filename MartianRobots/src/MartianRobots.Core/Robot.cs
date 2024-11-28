namespace MartianRobots.Core;

public class Robot(int x, int y, char orientation)
{
    private int X { get; set; } = x;
    private int Y { get; set; } = y;
    private char Orientation { get; set; } = orientation;
    private bool IsLost { get; } = false;
    private static readonly char[] Directions = ['N', 'E', 'S', 'W'];
    
    public void Execute(string instructions)
    {
        foreach (var instruction in instructions)
        {
            if (IsLost) break;

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
        if (IsLost)
        {
            return;
        }

        switch (Orientation)
        {
            case 'N': 
                Y++; 
                break;
            case 'E': 
                X++; 
                break;
            case 'S': 
                Y--; 
                break;
            case 'W': 
                X--; 
                break;
        }
    }
}