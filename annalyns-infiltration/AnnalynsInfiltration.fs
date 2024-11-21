module AnnalynsInfiltration

let canFastAttack (knightIsAwake: bool): bool = not knightIsAwake

let canSpy (knightIsAwake: bool) (archerIsAwake: bool) (prisonerIsAwake: bool): bool = [knightIsAwake; archerIsAwake; prisonerIsAwake] |> List.contains true

let canSignalPrisoner (archerIsAwake: bool) (prisonerIsAwake: bool): bool = prisonerIsAwake && not archerIsAwake

let canFreePrisoner (knightIsAwake: bool) (archerIsAwake: bool) (prisonerIsAwake: bool) (petDogIsPresent: bool): bool =
    match petDogIsPresent, prisonerIsAwake, archerIsAwake, knightIsAwake with
    | true, _, false, _ -> true
    | false, true, false, false -> true
    | _ -> false
