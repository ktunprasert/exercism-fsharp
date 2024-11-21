module AnnalynsInfiltration

let canFastAttack (knightIsAwake: bool): bool = not knightIsAwake

let canSpy (knightIsAwake: bool) (archerIsAwake: bool) (prisonerIsAwake: bool): bool = [knightIsAwake; archerIsAwake; prisonerIsAwake] |> List.contains true

let canSignalPrisoner (archerIsAwake: bool) (prisonerIsAwake: bool): bool = prisonerIsAwake && not archerIsAwake

let canFreePrisoner (knightIsAwake: bool) (archerIsAwake: bool) (prisonerIsAwake: bool) (petDogIsPresent: bool): bool =
    match petDogIsPresent with
    | true -> not archerIsAwake
    | false -> prisonerIsAwake && (archerIsAwake, knightIsAwake) = (false,false)
