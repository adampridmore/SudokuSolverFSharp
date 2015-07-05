open SudokuSolverHelpers
open SudokuSolver
open puzzles

puzzle3a
|> stringToPuzzle 
|> solverSequence 
|> Seq.iter (fun solution -> 
                             System.Console.Clear()
                             solution |> printPuzzle
                             System.Threading.Thread.Sleep(250)
                             //System.Console.ReadKey() |> ignore
                           )

//puzzle4 
//|> stringToPuzzle 
//|> solverSequence 
//|> Seq.iter (fun solution -> solution 
//                             |> printAndContinue 
//                             |> ignore)

