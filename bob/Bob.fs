module Bob

let response (input: string) : string =
    if input.Trim().Length = 0 then
        "Fine. Be that way!"
    elif input.ToUpper() = input && input.ToLower() <> input then
        if input.Trim().EndsWith("?") then
            "Calm down, I know what I'm doing!"
        else
            "Whoa, chill out!"
    elif input.Trim().EndsWith("?") then
        "Sure."
    else
        "Whatever."
