module BirdWatcher

let lastWeek: int[] = [| 0; 2; 5; 3; 7; 8; 4 |]

let yesterday (counts: int[]) : int = counts.[counts.Length - 2]

let total (counts: int[]) : int = counts |> Array.sum

let dayWithoutBirds (counts: int[]) : bool = counts |> Array.exists (fun n -> n = 0)

let incrementTodaysCount (counts: int[]) : int[] =
    let n = counts.Length - 1
    counts[n] <- counts[n] + 1
    counts

let unusualWeek (counts: int[]) : bool =
    let mutable even = ResizeArray<int>()
    let mutable odd = ResizeArray<int>()

    for i = 0 to counts.Length - 1 do
        match i % 2 with
        | 1 -> even.Add(counts.[i])
        | _ -> odd.Add(counts.[i])

    let evenArr = even.ToArray()
    let oddArr = odd.ToArray()

    evenArr |> Array.forall (fun n -> n = 0)
    || evenArr |> Array.forall (fun n -> n = 10)
    || oddArr |> Array.forall (fun n -> n = 5)
