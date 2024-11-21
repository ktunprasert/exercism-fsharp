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
    let i = (int student.[0] - int 'A') * 2

    diagram.Split()
    |> Seq.collect (fun row -> row |> Seq.skip i |> Seq.take 2)
    |> Seq.map Plant.Parse
    |> Seq.toList
