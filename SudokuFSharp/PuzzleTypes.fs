module PuzzleTypes

type Cell = 
  | Solved of int
  | Unsolved of int list

type Row = {
  Cells : Cell array
}


type Puzzle = {
  Rows : Row array
}

