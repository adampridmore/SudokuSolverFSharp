﻿module SudokuSolver 

let getRowCells (puzzle:int option [][]) rowIndex = 
  puzzle.[rowIndex]

let getColumnCells (puzzle:int option [][]) columnIndex = 
  seq{0..8}
  |> Seq.map(fun currentRowIndex -> puzzle.[currentRowIndex].[columnIndex])
  |> Seq.toArray

let getBlockCells (puzzle:int option [][]) cellx celly = 
  let blockIndexX = cellx / 3
  let blockIndexY = celly / 3
  seq{
    for x in 0..2 do 
      for y in 0..2 do
        yield puzzle.[blockIndexY*3+y].[blockIndexX*3+x]
  } |> Seq.toArray


let getSolvedCellValues puzzle cellx celly = 
  Seq.concat [|
    (getRowCells puzzle celly);
    (getColumnCells puzzle cellx);
    (getBlockCells puzzle cellx celly)
  |] 
  |> Seq.distinct

let whereOptionValues optionSeq = optionSeq |> Seq.choose id

let getPossibleSolutions puzzle cellx celly =
  let oneToNine = seq{1..9} |> Set.ofSeq
  
  getSolvedCellValues puzzle cellx celly
  |> whereOptionValues
  |> Set.ofSeq
  |> Set.difference oneToNine

let processCell (puzzle:int option [][]) x y =
  match puzzle.[y].[x] with
  | None -> match ((getPossibleSolutions puzzle x y) |> Seq.toList) with
            | [] -> failwith "No valid solutions - invalid puzzle!"
            | [x] -> Some(x)
            | _ -> None
  | x -> x

let nextSolution puzzle = 
  puzzle 
  |> Array.mapi(fun y row -> row 
                             |> Array.mapi (fun x _ -> processCell puzzle x y)
                )

let solverSequence puzzle =
  let unfolder (puzzleA, puzzleB) = 
    match puzzleA with
    | None -> Some(puzzleB, (Some(puzzleB), nextSolution puzzleB))
    | Some(puzzleA) when puzzleA = puzzleB -> None
    | Some(puzzleA) -> Some(puzzleB, (Some(puzzleB), nextSolution puzzleB))

  Seq.unfold unfolder (None, puzzle)

let solver puzzle = 
  solverSequence puzzle |> Seq.last