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

## Author

- Dao Lam