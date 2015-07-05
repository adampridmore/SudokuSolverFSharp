// #load "SudokuSolver.fs"
#load "SudokuSolverHelpers.fs"
#load "puzzles.fs"
open SudokuSolverHelpers

open puzzles

let nl = System.Environment.NewLine

let puzzleToPossibilities puzzle =
  let processCell x y cell = 
    match cell with 
    | Some(x) -> Seq.singleton x
    | _ -> seq{1..9}

  puzzle 
  |> Seq.mapi(fun x row -> row |> Seq.mapi (fun y cell -> processCell x y cell))

let printPossibilities (possibilities:int seq seq seq) = 
  let padd (s:string) = 
    s.PadRight(9)
  
  let printCellToString cell = 
    let cellText = cell 
                   |> Seq.map string 
                   |> Seq.reduce (+)
                   |> padd
    sprintf "|%s|" cellText

  let processRow (row: int seq seq) = 
    let line = row 
               |> Seq.map printCellToString
               |> Seq.reduce (+)

    sprintf "||%s||%s" line nl
        
  
  possibilities 
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
