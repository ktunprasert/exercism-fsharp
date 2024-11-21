module KindergartenGarden

type Plant =
    | Grass
    | Clover
    | Radishes
    | Violets

    static member Parse (c: char) =
        match c with
        | 'G' -> Grass
        | 'C' -> Clover
        | 'R' -> Radishes
        | 'V' -> Violets
        | _ -> failwith "Invalid plant"

let plants (diagram: string) (student: string) : Plant list =
    match diagram.Split() with
    | [| row1; row2 |] ->
        let i = (int student.[0] - int 'A') * 2

        [ row1; row2 ]
        |> List.collect (fun row -> row |> Seq.toList |> List.skip i |> List.take 2)
        |> List.map Plant.Parse
    | _ -> failwith "Invalid diagram"
