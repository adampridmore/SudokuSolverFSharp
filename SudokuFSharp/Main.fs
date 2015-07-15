open SudokuSolverHelpers
open SudokuSolver

open puzzles
open PuzzleTypes

puzzle3a
|> stringToPuzzle 
|> puzzleToPossibilities
|> solvePuzzle
//|> cellSequence |> Seq.iter (fun c -> match c with 
//                                      | Solved(x) -> printf "%d" x
//                                      | Unsolved(_) -> printf ".")
|> printPossibilities



