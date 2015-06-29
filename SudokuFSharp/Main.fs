open SudokuSolverHelpers
open SudokuSolver
open puzzles

puzzle4 
|> stringToPuzzle 
|> solverSequence 
|> Seq.iter (fun solution -> //System.Threading.Thread.Sleep(1000)
                             System.Console.Clear()
                             solution |> printAndContinue |> ignore
                             System.Console.ReadKey() |> ignore
                           )

//puzzle4 
//|> stringToPuzzle 
//|> solverSequence 
//|> Seq.iter (fun solution -> solution 
//                             |> printAndContinue 
//                             |> ignore)

