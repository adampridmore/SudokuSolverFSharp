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
     
puzzle |> printPuzzle

let getRowCells (puzzle:int[][]) rowIndex = 
  puzzle.[rowIndex]

let getColumnCells (puzzle:int[][]) columnIndex = 
  seq{0..8}
  |> Seq.map(fun currentRowIndex -> puzzle.[currentRowIndex].[columnIndex])
  |> Seq.toArray

let getBlockCells (puzzle:int[][]) cellx celly = 
  let blockIndexX = cellx / 3
  let blockIndexY = celly / 3
  seq{
    for x in 0..2 do 
      for y in 0..2 do
        yield puzzle.[blockIndexY*3+y].[blockIndexX*3+x]
  } |> Seq.toArray


let getSolvedCellValues (puzzle:int[][]) cellx celly = 
  Seq.concat [|
    (getRowCells puzzle celly);
    (getColumnCells puzzle cellx);
    (getBlockCells puzzle cellx celly)
  |] 
  |> Seq.distinct
    
let getPossibleSolutions (puzzle:int[][]) cellx celly =
  seq{1..9}
  |> Seq.filter(fun numToCheck -> getSolvedCellValues puzzle cellx celly 
                                  |> Seq.exists(fun solution -> numToCheck = solution) 
                                  |> not
                                  )

let processCell (puzzle:int[][]) x y =
  match puzzle.[y].[x] with
  | 0 -> match ((getPossibleSolutions puzzle x y) |> Seq.toList) with
         | [] -> failwith "No valid solutions - invalid puzzle!"
         | [x] -> x
         | _ -> 0
  | x -> x
  
let solver (puzzle:int[][]) = 
  puzzle 
  |> Seq.mapi(fun y row -> row 
                           |> Seq.mapi (fun x _ -> processCell puzzle x y)
                           |> Seq.toArray
              )
  |> Seq.toArray

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