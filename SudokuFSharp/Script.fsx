#load "puzzles.fs"
#load "PuzzleTypes.fs"
#load "SudokuSolver.fs"
#load "SudokuSolverHelpers.fs"

open SudokuSolverHelpers
open SudokuSolver
  
open puzzles
  
puzzle3a
|> stringToPuzzle
|> puzzleToPossibilities
|> solverSequence 
//|> Seq.length |> printfn "%A"
// |> Seq.last |> Seq.singleton
|> Seq.iter printPossibilities

// TODO Filter by single unsolved in row, column or block