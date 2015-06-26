module SudokuSolverTests

open NUnit.Framework
open FsUnit
open SudokuSolver

[<Test>]
let test1() = 
  let puzzle = 
    [|
      [|1;2;3;4;5;6;7;8;9|]
      [|1;2;3;4;5;6;7;8;9|]
      [|1;2;3;4;5;6;7;8;9|]
      [|1;2;3;4;5;6;7;8;9|]
      [|1;2;3;4;5;6;7;8;9|]
      [|1;2;3;4;5;6;7;8;9|]
      [|1;2;3;4;5;6;7;8;9|]
      [|1;2;3;4;5;6;7;8;9|]
      [|1;2;3;4;5;6;7;8;9|]
    |]
     
  puzzle.[0].[2]