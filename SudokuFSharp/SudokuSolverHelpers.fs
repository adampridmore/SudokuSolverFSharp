module SudokuSolverHelpers
open PuzzleTypes

let nl = System.Environment.NewLine

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

let stringToPuzzle (text:string) = 
  let parseChar (c:char) =
    match c with
    | ' ' | '0' |'.'  -> None
    | c when System.Char.IsNumber(c) -> Some(System.Int32.Parse(c.ToString()))
    | o -> failwith (sprintf "Invalid character in puzzle text: '%s'" (o.ToString()) )

  let newLines = [|"\n";"\r\n"|]

  text.Split(newLines, System.StringSplitOptions.RemoveEmptyEntries)
  |> Seq.map (fun rowText -> rowText.Trim())
  |> Seq.map (fun rowText -> rowText.ToCharArray())
  |> Seq.map (fun rowChars -> rowChars 
                              |> Seq.filter (fun c -> not (System.Char.IsWhiteSpace(c)) )
                              |> Seq.map parseChar 
                              |> Seq.toArray)
  |> Seq.toArray



let printPossibilities (puzzle:Puzzle) = 
  let padd (s:string) = 
    s.PadRight(18)
  
  let printCellToString (cell:Cell) = 
    let cellText = match cell with
                   | Solved(x) -> (sprintf "%s" (x |> string)) |> padd
                   | Unsolved(list) -> list
                                       |> Seq.map string 
                                       |> Seq.reduce (+)
                                       |> padd

    sprintf "|%s|" cellText

  let processRow (row:Row) = 
    let line = row.Cells
               |> Seq.map printCellToString
               |> Seq.reduce (+)
    sprintf "||%s||%s" line nl

  printfn "" 
  puzzle.Rows
  |> Seq.map processRow
  |> Seq.reduce (+)
  |> printfn "%s"