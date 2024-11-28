# MartianRobots

## Introduction

This project simulates robots navigating on a rectangular grid representing the surface of Mars. Robots receive commands to move or turn, and they leave a scent at the edge of the grid if they fall off, preventing future robots from falling at the same location.

## Features

- **Read input from .txt file**
- **Export output to .txt file**
- **Print output in console**

## Prerequisite

- .NET 8 SDK & runtime.

## Quick Start

1. **Clone the repository**:
    ```bash
    git clone https://github.com/daolavi/MartianRobots.git
    ```

2. **Move to root folder**:
    ```bash
    cd MartianRobots/ 
    ```

3. **Build solution**:
    ```bash
    dotnet build
    ```
   
4. **Run tests**:
   ```bash
   dotnet test
   ```

5. **Run main project**:
   ```bash
   dotnet run --project ./src/MartianRobots.Main/MartianRobots.Main.csproj
   ```
6. **Check results**: open ./output.txt file or check your console. 

## Input Format

- The first line specifies the grid's dimensions (width height).
- Each subsequent pair of lines specifies:
  - The robot's starting position (x y orientation).
  - A sequence of commands (L, R, F).

### Example Input
```
5 3
1 1 E
RFRFRFRF
3 2 N
FRRFLLFFRRFLL
0 3 W
LLFFFLFLFL
```

## Output Format

The program outputs the final position and orientation of each robot, with LOST appended if the robot moved off the grid.

### Example Output
```
1 1 E
3 3 N LOST
2 3 S
```

## Extending the Solution

The solution is designed to be extensible. To add new commands:
- Update the Robot class by adding a new case in the `Execute` method.
- Update tests to cover the new command's behavior.

## Author

- Dao Lam