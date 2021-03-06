﻿module SudokuSolver

open PuzzleTypes

// Converts an option int to a Cell
let toCell cell = 
  match cell with 
  | Some(cell) -> Solved(cell)
  | None -> Unsolved([1..9])

let toRow cells =
  {Row.Cells = (cells |> Seq.toArray )}

let toPuzzle rows =
  {Puzzle.Rows = (rows |> Seq.toArray)}

// Filters cells to a seq of just solved values
let justSolved cells =
  cells 
  |> Seq.choose (fun cell -> match cell with 
                             | Solved(v) -> Some(v)
                             | Unsolved(_) -> None)

let getRowCells (puzzle:Puzzle) rowIndex = 
   puzzle.Rows.[rowIndex].Cells 
   
let getColumnCells (puzzle:Puzzle) columnIndex = 
  seq{0..8}
  |> Seq.map(fun currentRowIndex -> puzzle.Rows.[currentRowIndex].Cells.[columnIndex])

let getBlockCells x y (puzzle:Puzzle) = 
  let blockIndexX = x / 3
  let blockIndexY = y / 3

  seq{
    for y in 0..2 do
      for x in 0..2 do 
        yield puzzle.Rows.[blockIndexY*3+y].Cells.[blockIndexX*3+x]
  }
  
let puzzleToPossibilities puzzle =
  puzzle 
  |> Seq.map(fun row -> row |> Seq.map toCell)
  |> Seq.map (fun cells -> cells |> toRow)
  |> toPuzzle

let filterPossibilities x y puzzle possibilities =
  let getSolvedCells puzzle =
    Seq.concat [|
      getRowCells puzzle y |> justSolved
      getColumnCells puzzle x |> justSolved
      getBlockCells x y puzzle |> justSolved
    |]
    |> Seq.distinct

  Set.difference (possibilities |> Set.ofSeq) (puzzle |> getSolvedCells |> Set.ofSeq) 
  |> Set.toList

// This converts any unsolved cell with a single solution to a solved cell
let convertUnsolvedToSolvedCell (cell:Cell) =
  match cell with
  | Solved(x) -> Solved(x)
  | Unsolved([single]) -> Solved(single)
  | Unsolved(many) -> Unsolved(many)

let mapPuzzle (puzzle:Puzzle) mapCell =
  let mapRow y (row:Row) =
    row.Cells
    |> Seq.mapi (fun x cell ->  mapCell x y cell)
    |> toRow

  puzzle.Rows 
  |> Seq.mapi mapRow
  |> toPuzzle

let filterPuzzle (puzzle:Puzzle) =
  let filterCell x y (cell:Cell) = 
    match cell with
    | Solved(v) -> Solved(v)
    | Unsolved(possibilities) -> Unsolved(filterPossibilities x y puzzle possibilities) 
                                 |> convertUnsolvedToSolvedCell

  mapPuzzle puzzle filterCell

let solverSequence puzzle =
  let unfolder (puzzleA, puzzleB) = 
    match puzzleA with
    | None -> Some(puzzleB, (Some(puzzleB), filterPuzzle puzzleB))
    | Some(puzzleA) when puzzleA = puzzleB -> None
    | Some(puzzleA) -> Some(puzzleB, (Some(puzzleB), filterPuzzle puzzleB))

  Seq.unfold unfolder (None, puzzle)

let cellSequence (puzzle:Puzzle) =
  puzzle.Rows |> Seq.collect(fun row -> row.Cells)

let isUnsolved puzzle = 
  (cellSequence puzzle)
  |> Seq.exists (fun (c:Cell) -> match c with 
                                 | Solved(_) -> false
                                 | Unsolved(_) -> true)

let isSolved puzzle = puzzle |> isUnsolved |> not

let rec solvePuzzle puzzle = 
  puzzle  |> solverSequence |> Seq.last
  
let solver puzzleArarys =
  let puzzle = puzzleArarys |> puzzleToPossibilities
  puzzle |> filterPuzzle
