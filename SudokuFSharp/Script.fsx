#load "SudokuSolver.fs"
#load "SudokuSolverHelpers.fs"
open SudokuSolver
open SudokuSolverHelpers

let puzzle2 = "
    427003610
    080270090
    009610702
    190830004
    700092061
    860007509
    008701053
    016305400
    503020180"

let puzzle3 = "
    002000800
    100200040
    306800720
    005300008
    020000090
    600001500
    057003201
    010007006
    003000400"

let puzzle4= "
    530070000
    600195000
    098000060
    800060003
    400803001
    700020006
    060000280
    000419005
    000080079"
  
// puzzle2 |> stringToPuzzle |> printAndContinue |> solver |> printPuzzle
// puzzle3 |> stringToPuzzle |> printAndContinue |> solver |> printPuzzle
// puzzle4 |> stringToPuzzle |> printAndContinue |> solver |> printPuzzle

puzzle4 
|> stringToPuzzle 
|> solverSequence 
|> Seq.iter (fun solution -> solution 
                             |> printAndContinue 
                             |> ignore)
