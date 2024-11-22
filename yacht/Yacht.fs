module Yacht

type Category =
    | Ones
    | Twos
    | Threes
    | Fours
    | Fives
    | Sixes
    | FullHouse
    | FourOfAKind
    | LittleStraight
    | BigStraight
    | Choice
    | Yacht

type Die =
    | One = 1
    | Two = 2
    | Three = 3
    | Four = 4
    | Five = 5
    | Six = 6

let scoreSingle dice kind =
    dice |> List.filter (fun x -> x = kind) |> List.length |> (*) (int kind)

let score category dice : int =
    let counted = dice |> List.countBy id
    let sorted = dice |> List.map int |> List.sort

    match category with
    | Ones -> scoreSingle dice Die.One
    | Twos -> scoreSingle dice Die.Two
    | Threes -> scoreSingle dice Die.Three
    | Fours -> scoreSingle dice Die.Four
    | Fives -> scoreSingle dice Die.Five
    | Sixes -> scoreSingle dice Die.Six
    | FullHouse when counted.Length = 2 && counted |> List.exists (fun (_, g) -> g = 3) -> dice |> List.sumBy int
    | FourOfAKind when counted |> List.exists (fun (_, n) -> n >= 4) ->
        counted |> List.find (fun (_, n) -> n >= 4) |> fst |> int |> (*) 4
    | LittleStraight when sorted = [ 1..5 ] -> 30
    | BigStraight when sorted = [ 2..6 ] -> 30
    | Choice -> dice |> List.sumBy int
    | Yacht when snd (counted.[0]) = 5 -> 50
    | _ -> 0
