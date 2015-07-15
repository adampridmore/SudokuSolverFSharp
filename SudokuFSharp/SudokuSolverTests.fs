module SudokuSolver2Tests

open NUnit.Framework
open FsUnit
open SudokuSolver
open SudokuSolverHelpers
open puzzles
open PuzzleTypes

[<Test>]
let ``puzzle to possibilities test``() = 
  let puzzle = [[Some(1);Some(2)]]
  
  let row = {
    Cells = ([| Cell.Solved(1); Cell.Solved(2) |]) 
  }

  let expectedPossibilities = {
    Rows = [| { Cells = [| Cell.Solved(1); 
                           Cell.Solved(2) 
                        |]
            } |]
  }

  puzzle 
  |> puzzleToPossibilities 
  |> should equal expectedPossibilities
