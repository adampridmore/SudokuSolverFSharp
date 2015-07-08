#load "puzzles.fs"
#load "PuzzleTypes.fs"
#load "SudokuSolver2.fs"
#load "SudokuSolverHelpers.fs"

open SudokuSolverHelpers
open SudokuSolver2
  
open puzzles
  
puzzle3a
|> stringToPuzzle
|> puzzleToPossibilities
|> solverSequence 
//|> Seq.length |> printfn "%A"
// |> Seq.last |> Seq.singleton
|> Seq.iter printPossibilities

// TODO Filter by single unsolved in row, column or block