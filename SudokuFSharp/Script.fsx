#load "SudokuSolver.fs"
#load "puzzles.fs"
#load "PuzzleTypes.fs"
#load "SudokuSolverHelpers.fs"
open SudokuSolver
open SudokuSolverHelpers
open puzzles
open PuzzleTypes
  
// puzzle2 |> stringToPuzzle |> printAndContinue |> solver |> printPuzzle
// puzzle3 |> stringToPuzzle |> printAndContinue |> solver |> printPuzzle
// puzzle4 |> stringToPuzzle |> printAndContinue |> solver |> printPuzzle

let toCell v = 
  [|  
    sprintf "--"
    sprintf "|%s" v
  |]

let cells = ["a";"b";"c"] 
            |> List.map (fun value -> (sprintf "--", sprintf "|%s" value, sprintf "--"))
            |> Seq.toArray

seq{0..2}
|> Seq.map (fun cells -> List.map (fun cell -> cell |> cell.[0]))

let line1 = (cells 
            |> List.map (fun (l1, _, _) -> l1) 
            |> List.reduce (+)) + "-"
let line2 = (cells 
            |> List.map (fun (_, l2, _) -> l2) 
            |> List.reduce (+)) + "|"
let line3 = (cells 
            |> List.map (fun (_, _, l3) -> l3) 
            |> List.reduce (+)) + "-"

printfn "%s" line1
printfn "%s" line2
printfn "%s" line3




                            






//puzzle4 |> stringToPuzzle |> printPuzzle2
//puzzle4
//|> stringToPuzzle 
//|> printAndContinue
//|> printPuzzle
//|> solverSequence
//|> Seq.iter printPuzzle
//|> Seq.iter (fun solution -> solution 
//                             |> printAndContinue 
//                             |> ignore)


//[|"a";"b"|]
//|> Seq.map(fun x -> ( 
//                      "---",
//                      (sprintf "|%s|" x),
//                      "---"))
//|> Seq.iter (fun (a,b,c) -> printfn "%s\r\n%s\r\n%s" a b c)



//let a = [1;2;3;4;5] |> Set.ofSeq
//let b = [2;3] |> Set.ofSeq
//
//a |> Seq.filter (fun x -> b |> Seq.exists (fun y -> y = x) |> not)
//b |> Set.difference a
//Set.difference a b
