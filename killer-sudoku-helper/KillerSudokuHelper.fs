module KillerSudokuHelper

let combinations exclude size sum =
    let rec combinationsHelper currentSum remainingSize acc current digits =
        match remainingSize, currentSum with
        | 0, 0 when List.length current = size -> [List.rev current]
        | 0, _ -> []
        | _, _ when currentSum < 0 || List.isEmpty digits -> []
        | _, _ ->
            digits
            |> List.mapi (fun i d ->
                combinationsHelper (currentSum - d) (remainingSize - 1) acc (d::current) (List.skip (i+1) digits)
            )
            |> List.concat

    let availableDigits = [1..9] |> List.filter (fun x -> not (List.contains x exclude))
    combinationsHelper sum size [] [] availableDigits
