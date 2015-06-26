#load "SudokuSolver.fs"
open SudokuSolver

let toString x = x.ToString()
  
let printPuzzle (puzzle:int option [][]) =
  let cellToText cell = match cell with
                        | None -> "."
                        | Some(x) -> sprintf "%i" x

  let joinCells (cells:int option seq) = 
    System.String.Join(" ", cells)

  puzzle 
  |> Seq.map(fun row -> row 
                        |> Seq.map cellToText
                        |> Seq.reduce (+)
                        |> (sprintf "%s") )
  |> String.concat System.Environment.NewLine
  |> (printfn "%s")

let printAndContinue x =
  x |> printPuzzle
  printfn ""
  x

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

let newLines = [|"\n";"\r\n"|]

let parseChar (c:char) =
  match c with
  | ' ' | '0'  -> None
  | c when System.Char.IsNumber(c) -> Some(System.Int32.Parse(c.ToString()))
  | o -> failwith (sprintf "Invalid character in puzzle text: '%s'" (o.ToString()) )

let stringToPuzzle (text:string) = 
  text.Split(newLines, System.StringSplitOptions.RemoveEmptyEntries)
  |> Seq.map (fun rowText -> rowText.Trim())
  |> Seq.map (fun rowText -> rowText.ToCharArray())
  |> Seq.map (fun rowChars -> rowChars 
                              |> Seq.filter (fun c -> not (System.Char.IsWhiteSpace(c)) )
                              |> Seq.map parseChar 
                              |> Seq.toArray)
  |> Seq.toArray
  
//puzzle2 |> stringToPuzzle |> printAndContinue |> solver |> printPuzzle
//puzzle3 |> stringToPuzzle |> printAndContinue |> solver |> printPuzzle
//puzzle4 |> stringToPuzzle |> printAndContinue |> solver |> printPuzzle

puzzle4 
|> stringToPuzzle 
|> solverSequence 
|> Seq.iter (fun solution -> solution 
                             |> printAndContinue 
                             |> ignore)

