#load "SudokuSolver.fs"
#load "SudokuSolverHelpers.fs"
#load "puzzles.fs"
open SudokuSolver
open SudokuSolverHelpers
open puzzles
  
// puzzle2 |> stringToPuzzle |> printAndContinue |> solver |> printPuzzle
// puzzle3 |> stringToPuzzle |> printAndContinue |> solver |> printPuzzle
// puzzle4 |> stringToPuzzle |> printAndContinue |> solver |> printPuzzle

puzzle5
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



let a = [1;2;3;4;5] |> Set.ofSeq
let b = [2;3] |> Set.ofSeq

a |> Seq.filter (fun x -> b |> Seq.exists (fun y -> y = x) |> not)
b |> Set.difference a
Set.difference a b
