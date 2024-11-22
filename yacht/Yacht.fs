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
    | One
    | Two
    | Three
    | Four
    | Five
    | Six

let v die : int =
    match die with
    | One -> 1
    | Two -> 2
    | Three -> 3
    | Four -> 4
    | Five -> 5
    | Six -> 6

let score category dice : int =
    match category with
    | Ones -> dice |> List.filter (fun x -> x = One) |> List.length
    | Twos -> dice |> List.filter (fun x -> x = Two) |> List.length |> (*) 2
    | Threes -> dice |> List.filter (fun x -> x = Three) |> List.length |> (*) 3
    | Fours -> dice |> List.filter (fun x -> x = Four) |> List.length |> (*) 4
    | Fives -> dice |> List.filter (fun x -> x = Five) |> List.length |> (*) 5
    | Sixes -> dice |> List.filter (fun x -> x = Six) |> List.length |> (*) 6
    | FullHouse ->
        let groups: (Die * Die list) list = dice |> List.groupBy id

        match groups.Length with
        | 2 ->
            if groups |> List.exists (fun (_, g) -> g.Length <> 2 && g.Length <> 3) then
                0
            else
                groups |> List.collect (fun (_, v) -> v) |> List.sumBy v

        | _ -> 0

    | FourOfAKind ->
        let groups = dice |> List.groupBy id
        if groups |> List.exists (fun (_, g) -> g.Length >= 4) then
            groups |> List.filter (fun (_, g) -> g.Length >= 4) |> List.head |> fst |> v |> (*) 4
        else
            0

    | LittleStraight ->
        match dice |> List.sortBy v with
        | [One; Two; Three; Four; Five] -> 30
        | _ -> 0

    | BigStraight ->
        match dice |> List.sortBy v with
        | [Two; Three; Four; Five; Six] -> 30
        | _ -> 0

    | Choice -> dice |> List.sumBy v
    | Yacht ->
        match dice |> List.groupBy id with
        | [(_, g)] when g.Length = 5 -> 50
        | _ -> 0
