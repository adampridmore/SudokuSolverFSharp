#load "SudokuSolver2.fs"
#load "SudokuSolverHelpers.fs"
#load "puzzles.fs"
open SudokuSolverHelpers
open SudokuSolver2
  
open puzzles

let printPossibilities (puzzle:Puzzle) = 
  let padd (s:string) = 
    s.PadRight(9)
  
  let printCellToString (cell:Cell) = 
    let cellText = match cell with
                   | Solved(x) -> string x |> padd
                   | Unsolved(list) -> list
                                       |> Seq.map string 
                                       |> Seq.reduce (+)
                                       |> padd

    sprintf "|%s|" cellText

  let processRow (row:Row) = 
    let line = row.Cells
               |> Seq.map printCellToString
               |> Seq.reduce (+)
    sprintf "||%s||%s" line nl

  printfn "" 
  puzzle.Rows
  |> Seq.map processRow
  |> Seq.reduce (+)
  |> printfn "%s"

//let solver (puzzle:int option [][]) =
//  puzzle 
//  |> puzzleToPossibilities
//  |> printPossibilities

puzzle3a 
|> stringToPuzzle
|> solver
|> printPossibilities
