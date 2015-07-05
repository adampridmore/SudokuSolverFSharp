// #load "SudokuSolver.fs"
#load "SudokuSolverHelpers.fs"
#load "puzzles.fs"
open SudokuSolverHelpers

type Cell = 
  | Solved of int
  | Unsolved of int seq

type Row = {
  Cells : Cell array
}


type Puzzle = {
  Rows : Row array
} 
  
open puzzles

let nl = System.Environment.NewLine

let puzzleToPossibilities puzzle =
  let toCell cell = 
    match cell with 
    | Some(cell) -> Solved(cell)
    | _ -> Unsolved(seq{1..9})

  let toRow cells =
    {Row.Cells = (cells |> Seq.toArray )}

  let toPuzzle rows =
    {Puzzle.Rows = (rows |> Seq.toArray)}

  puzzle 
  |> Seq.map(fun row -> row |> Seq.map toCell)
  |> Seq.map (fun cells -> cells |> toRow)
  |> toPuzzle

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
 
  puzzle.Rows
  |> Seq.map processRow
  |> Seq.reduce (+)
  |> printfn "%s"

let solver (puzzle:int option [][]) =
  puzzle 
  |> puzzleToPossibilities
  |> printPossibilities

printfn ""
puzzle3a 
|> stringToPuzzle 
|> solver
