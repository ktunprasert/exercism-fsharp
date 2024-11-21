module GuessingGame

let reply (guess: int): string =
    match guess with
    | 41 | 43 -> "So close"
    | x when x < 42 -> "Too low"
    | x when x > 42 -> "Too high"
    | _ -> "Correct"

