open SudokuSolverHelpers
open SudokuSolver

let puzzle4= "
53..7....
6..195...
.98....6.
8...6...3
4..8.3..1
7...2...6
.6....28.
...419..5
....8..79"
  
//puzzle4 
//|> stringToPuzzle 
//|> solverSequence 
//|> Seq.iter (fun solution -> System.Threading.Thread.Sleep(1...)
//                             System.Console.Clear()
//                             solution 
//                             |> printAndContinue 
//                             |> ignore)

puzzle4 
|> stringToPuzzle 
|> solverSequence 
|> Seq.iter (fun solution -> solution 
                             |> printAndContinue 
                             |> ignore)

