module ValentinesDay

type Approval =
    | Yes
    | No
    | Maybe

type Cuisine =
    | Korean
    | Turkish

type Genre =
    | Crime
    | Horror
    | Romance
    | Thriller

type Activity =
    | BoardGame
    | Chill
    | Movie of Genre
    | Restaurant of Cuisine
    | Walk of int

let rateActivity (activity: Activity) : Approval =
    match activity with
    | BoardGame | Chill -> No
    | Movie Romance -> Yes
    | Movie _ -> No
    | Restaurant Korean -> Yes
    | Restaurant _ -> Maybe
    | Walk n when n < 3 -> Yes
    | Walk n when n < 5 -> Maybe
    | Walk _ -> No

