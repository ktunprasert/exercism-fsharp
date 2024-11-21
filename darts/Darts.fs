module Darts

let score (x: double) (y: double): int =
    match x * x + y * y |> sqrt with
    | r when r <= 1.0 -> 10
    | r when r <= 5.0 -> 5
    | r when r <= 10.0 -> 1
    | _ -> 0

