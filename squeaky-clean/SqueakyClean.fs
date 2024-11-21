module SqueakyClean

open System

let transform (c: char) : string =
    match c with
    | ' ' -> ""
    | '-' -> "_"
    | c when Char.IsDigit(c) -> ""
    | c when Char.IsBetween(c, 'α', 'ω') -> "?"
    | c when Char.IsUpper(c) -> c |> Char.ToLower |> sprintf "-%c"
    | c -> c.ToString()

let clean (identifier: string) : string =
    identifier |> Seq.map transform |> String.concat ""
