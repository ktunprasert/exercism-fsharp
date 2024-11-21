module TisburyTreasureHunt

let getCoordinate (line: string * string) : string = snd line

let convertCoordinate (coordinate: string) : int * char = int coordinate.[0] - int '0', coordinate.[1]

let compareRecords
    ((_, azaraCoords): string * string)
    ((_, ruisCoords, _): string * (int * char) * string)
    : bool =
    convertCoordinate azaraCoords = ruisCoords

let createRecord (az: string * string) (ru: string * (int * char) * string) : (string * string * string * string) =
    let azName, azCoords = az
    let ruName, _, ruColor = ru

    if compareRecords az ru then
        azCoords, ruName, ruColor, azName
    else
        "", "", "", ""
