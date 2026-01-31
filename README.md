# SudokuSolverFSharp

A Sudoku puzzle solver written in F#.

## Prerequisites

- [.NET 7.0 SDK](https://dotnet.microsoft.com/download) or later

## Building

```bash
cd SudokuFSharp
dotnet build
```

## Running

```bash
cd SudokuFSharp
dotnet run
```

## Usage

The solver reads puzzles defined in `puzzles.fs`. To solve a different puzzle, edit `Main.fs` and change the puzzle reference (e.g., `puzzle3a`) to another puzzle defined in `puzzles.fs`.

## Running Tests

```bash
cd SudokuFSharp
dotnet test
```
