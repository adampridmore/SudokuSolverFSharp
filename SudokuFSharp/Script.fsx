#load "SudokuSolver.fs"
#load "SudokuSolverHelpers.fs"
#load "puzzles.fs"
open SudokuSolver
open SudokuSolverHelpers
open puzzles
  
// puzzle2 |> stringToPuzzle |> printAndContinue |> solver |> printPuzzle
// puzzle3 |> stringToPuzzle |> printAndContinue |> solver |> printPuzzle
// puzzle4 |> stringToPuzzle |> printAndContinue |> solver |> printPuzzle

puzzle3b
|> stringToPuzzle 
|> printAndContinue
|> solver 
|> printPuzzle
//|> Seq.iter (fun solution -> solution 
//                             |> printAndContinue 
//                             |> ignore)


//[|"a";"b"|]
//|> Seq.map(fun x -> ( 
//                      "---",
//                      (sprintf "|%s|" x),
//                      "---"))
//|> Seq.iter (fun (a,b,c) -> printfn "%s\r\n%s\r\n%s" a b c)
