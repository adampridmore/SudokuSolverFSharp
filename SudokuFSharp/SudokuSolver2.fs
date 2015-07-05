module SudokuSolver2

type Cell = 
  | Solved of int
  | Unsolved of int seq

type Row = {
  Cells : Cell array
}


type Puzzle = {
  Rows : Row array
}

let nl = System.Environment.NewLine

let toCell cell = 
  match cell with 
  | Some(cell) -> Solved(cell)
  | _ -> Unsolved(seq{1..9})

let toRow cells =
  {Row.Cells = (cells |> Seq.toArray )}

let toPuzzle rows =
  {Puzzle.Rows = (rows |> Seq.toArray)}

let getRowCells (puzzle:Puzzle) rowIndex = 
   puzzle.Rows.[rowIndex].Cells |> Seq.choose (fun cell -> match cell with 
                                                           | Solved(v) -> Some(v)
                                                           | _ -> None)

//let getColumnCells (puzzle:int option [][]) columnIndex = 
//  seq{0..8}
//  |> Seq.map(fun currentRowIndex -> puzzle.[currentRowIndex].[columnIndex])
//  |> Seq.toArray
//
//let getBlockCells (puzzle:int option [][]) cellx celly = 
//  let blockIndexX = cellx / 3
//  let blockIndexY = celly / 3
//  seq{
//    for x in 0..2 do 
//      for y in 0..2 do
//        yield puzzle.[blockIndexY*3+y].[blockIndexX*3+x]
//  } |> Seq.toArray

let puzzleToPossibilities puzzle =
  puzzle 
  |> Seq.map(fun row -> row |> Seq.map toCell)
  |> Seq.map (fun cells -> cells |> toRow)
  |> toPuzzle

let filterPossibilities x y puzzle possibilities =
  let eliminated = getRowCells puzzle y |> Set.ofSeq

  Set.difference (possibilities |> Set.ofSeq) eliminated |> Set.toSeq


let filterPuzzle (puzzle:Puzzle) =
  let filterCell x y (cell:Cell) = 
    match cell with
    | Solved(v) -> Solved(v)
    | Unsolved(possibilities) -> Unsolved(filterPossibilities x y puzzle possibilities)

  let filterRow y (row:Row) =
    row.Cells
    |> Seq.mapi (fun x cell ->  filterCell x y cell)
    |> toRow

  puzzle.Rows 
  |> Seq.mapi filterRow
  |> toPuzzle

let solver puzzleArarys =
  let puzzle = puzzleArarys |> puzzleToPossibilities
  
  puzzle |> filterPuzzle
