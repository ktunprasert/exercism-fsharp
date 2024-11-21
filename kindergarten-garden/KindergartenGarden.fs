module KindergartenGarden

type Plant =
    | Grass = 'G'
    | Clover = 'C'
    | Radishes = 'R'
    | Violets = 'V'

let plantFromChar (c: char) =
    match c with
    | 'G' -> Plant.Grass
    | 'C' -> Plant.Clover
    | 'R' -> Plant.Radishes
    | 'V' -> Plant.Violets
    | _ -> failwith "Invalid plant"

let plants (diagram: string) (student: string) : Plant list =
    match diagram.Split('\n') with
    | [| row1; row2 |] ->
        let i = (int student.[0] - int 'A') * 2
        let indexes = [ i; i + 1 ]

        [ row1; row2 ]
        |> List.collect (fun row -> indexes |> List.map (fun index -> plantFromChar row.[index]))
    | _ -> failwith "Invalid diagram"
