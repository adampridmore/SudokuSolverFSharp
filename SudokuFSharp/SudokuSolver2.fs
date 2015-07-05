module SudokuSolver2

open puzzles

let puzzleToPossibilities puzzle =
  let processCell x y cell = 
    match cell with 
    | Some(x) -> Seq.singleton x
    | _ -> seq{1..9}

  puzzle 
  |> Seq.mapi(fun x row -> row |> Seq.mapi (fun y cell -> processCell x y cell))

let printPossibilities (possibilities:int seq seq seq) = 
  let processRow (row: int seq seq) = 
    row 
    |> Seq.map (fun cell -> sprintf "%A" cell)
    |> Seq.reduce (+)
  
  possibilities 
  |> Seq.map processRow
  |> Seq.reduce (+)
  |> printfn "%s"

let solver (puzzle:int option [][]) =
  puzzle 
  |> puzzleToPossibilities
  |> printPossibilities


puzzle3a |> solver