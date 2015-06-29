module SudokuSolver 

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


let getSolvedCellValues (puzzle:int option [][]) cellx celly = 
  Seq.concat [|
    (getRowCells puzzle celly);
    (getColumnCells puzzle cellx);
    (getBlockCells puzzle cellx celly)
  |] 
  |> Seq.distinct

let getOptionValues optionSeq = 
  optionSeq 
  |> Seq.filter(fun (x:'a Option) -> x.IsSome)
  |> Seq.map (fun (x:'a Option) -> x.Value)

let getPossibleSolutions (puzzle:int option [][]) cellx celly =
  let oneToNine = seq{1..9} |> Set.ofSeq
  
  getSolvedCellValues puzzle cellx celly
  |> getOptionValues 
  |> Set.ofSeq
  |> Set.difference oneToNine

let processCell (puzzle:int option [][]) x y =
  match puzzle.[y].[x] with
  | None -> match ((getPossibleSolutions puzzle x y) |> Seq.toList) with
            | [] -> failwith "No valid solutions - invalid puzzle!"
            | [x] -> Some(x)
            | _ -> None
  | x -> x

let nextSolution (puzzle:int option [][]) = 
  puzzle 
  |> Seq.mapi(fun y row -> row 
                           |> Seq.mapi (fun x _ -> processCell puzzle x y)
                           |> Seq.toArray
              )
  |> Seq.toArray

let solverSequence (puzzle: int option [][]) =
  let unfolder (puzzleA, puzzleB) = 
    match puzzleA with
    | None -> Some(puzzleB, (Some(puzzleB), nextSolution puzzleB))
    | Some(puzzleA) when puzzleA = puzzleB -> None
    | Some(puzzleA) -> Some(puzzleB, (Some(puzzleB), nextSolution puzzleB))

  Seq.unfold unfolder (None, puzzle)

let solver (puzzle: int option [][]) = 
  solverSequence puzzle
  |> Seq.last