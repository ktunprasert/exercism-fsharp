module Bob

let isQuestion (input: string) : bool = input.Trim().EndsWith("?")
let isYelling (input: string) : bool = input.ToUpper() = input && input.ToLower() <> input

let response (input: string) : string =
    match input.Trim() with
    | "" -> "Fine. Be that way!"
    | _ when isYelling input && isQuestion input -> "Calm down, I know what I'm doing!"
    | _ when isYelling input -> "Whoa, chill out!"
    | _ when isQuestion input -> "Sure."
    | _ -> "Whatever."
