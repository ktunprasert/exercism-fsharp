module Accumulate

let rec accum func input acc =
    match input with
    | [] -> acc |> List.rev
    | h :: t -> accum func t (func(h) :: acc)

let accumulate (func: 'a -> 'b) (input: 'a list): 'b list =
   accum func input List.empty

