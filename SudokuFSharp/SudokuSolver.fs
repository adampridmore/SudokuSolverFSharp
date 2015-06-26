module SudokuSolver 

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
