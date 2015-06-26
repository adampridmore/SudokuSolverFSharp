#load "SudokuSolver.fs"
open SudokuSolver

let toString x = x.ToString()

let printPuzzle puzzle =
  let printRow row =  
    row 
    |> Seq.map toString 
    |> Seq.reduce (+)

  let rows =  puzzle |> Seq.map printRow  |> Seq.toArray
  
  System.String.Join(System.Environment.NewLine, rows)
  
let print o = o |> Seq.iter (printfn "%A")

let printAndContinue x = 
  x |> print 
  x

let puzzle = 
  [|
    [|1;2;1;1;1;1;1;1;1|]
    [|1;1;1;1;1;1;1;1;1|]
    [|1;1;1;1;1;1;1;1;1|]
    [|1;1;1;1;1;1;1;1;1|]
    [|1;1;1;1;1;1;1;1;1|]
    [|1;1;1;1;1;1;1;1;1|]
    [|1;1;1;1;1;1;1;1;1|]
    [|1;1;1;1;1;1;1;1;1|]
    [|1;1;1;1;1;1;1;1;1|]
  |]

let puzzle2 = 
  [|
    [|4;2;7;0;0;3;6;1;0|]
    [|0;8;0;2;7;0;0;9;0|]
    [|0;0;9;6;1;0;7;0;2|]
    [|1;9;0;8;3;0;0;0;4|]
    [|7;0;0;0;9;2;0;6;1|]
    [|8;6;0;0;0;7;5;0;9|]
    [|0;0;8;7;0;1;0;5;3|]
    [|0;1;6;3;0;5;4;0;0|]
    [|5;0;3;0;2;0;1;8;0|]
  |]

let puzzle3 = [|
    [|0;0;2;0;0;0;8;0;0|]
    [|1;0;0;2;0;0;0;4;0|]
    [|3;0;6;8;0;0;7;2;0|]
    [|0;0;5;3;0;0;0;0;8|]
    [|0;2;0;0;0;0;0;9;0|]
    [|6;0;0;0;0;1;5;0;0|]
    [|0;5;7;0;0;3;2;0;1|]
    [|0;1;0;0;0;7;0;0;6|]
    [|0;0;3;0;0;0;4;0;0|]
  |]

let puzzle4 = [|
    [|5;3;0;0;7;0;0;0;0|]
    [|6;0;0;1;9;5;0;0;0|]
    [|0;9;8;0;0;0;0;6;0|]
    [|8;0;0;0;6;0;0;0;3|]
    [|4;0;0;8;0;3;0;0;1|]
    [|7;0;0;0;2;0;0;0;6|]
    [|0;6;0;0;0;0;2;8;0|]
    [|0;0;0;4;1;9;0;0;5|]
    [|0;0;0;0;8;0;0;7;9|]
  |]
     
// puzzle |> printPuzzle

puzzle4
|> solver
|> solver
|> solver
|> solver
|> solver
|> solver
|> solver
|> solver
|> solver
|> solver
|> print