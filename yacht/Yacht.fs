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

let scoreSingle dice kind = dice |> List.filter (fun x -> x = kind) |> List.length |> (*) (int kind)

let score category dice : int =
    match category with
    | Ones -> scoreSingle dice Die.One
    | Twos -> scoreSingle dice Die.Two
    | Threes -> scoreSingle dice Die.Three
    | Fours -> scoreSingle dice Die.Four
    | Fives -> scoreSingle dice Die.Five
    | Sixes -> scoreSingle dice Die.Six
    | FullHouse ->
        let groups: (Die * Die list) list = dice |> List.groupBy id

        match groups.Length with
        | 2 ->
            if groups |> List.exists (fun (_, g) -> g.Length <> 2 && g.Length <> 3) then
                0
            else
                groups |> List.collect (fun (_, v) -> v) |> List.sumBy int

        | _ -> 0

    | FourOfAKind ->
        let groups = dice |> List.groupBy id
        if groups |> List.exists (fun (_, g) -> g.Length >= 4) then
            groups |> List.filter (fun (_, g) -> g.Length >= 4) |> List.head |> fst |> int |> (*) 4
        else
            0

    | LittleStraight ->
        match dice |> List.sortBy int with
        | [Die.One; Die.Two; Die.Three; Die.Four; Die.Five] -> 30
        | _ -> 0

    | BigStraight ->
        match dice |> List.sortBy int with
        | [Die.Two; Die.Three; Die.Four; Die.Five; Die.Six] -> 30
        | _ -> 0

    | Choice -> dice |> List.sumBy int
    | Yacht ->
        match dice |> List.groupBy id with
        | [(_, g)] when g.Length = 5 -> 50
        | _ -> 0
