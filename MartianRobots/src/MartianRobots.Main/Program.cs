// See https://aka.ms/new-console-template for more information

using MartianRobots.Core;

var input = "./input.txt";
var output = "./output.txt";
var lines = await File.ReadAllLinesAsync(input);
lines = lines.Where(l => !string.IsNullOrWhiteSpace(l)).ToArray();

var marsInput = lines[0].Split(" ");
var mars = new Mars(int.Parse(marsInput[0]), int.Parse(marsInput[1]));
var robots = new List<Robot>();
for (var i = 1; i < lines.Length; i++)
{
    if (i % 2 == 1)
    {
        var robotInput = lines[i].Split(" ");
        var instructions = lines[i + 1];

        var robot = new Robot(int.Parse(robotInput[0]), int.Parse(robotInput[1]), robotInput[2][0], mars);
        robot.Execute(instructions);
        
        robots.Add(robot);
        Console.WriteLine(robot.GetStatus());
    }
}

await File.WriteAllLinesAsync(output, robots.Select(r => r.GetStatus()));
