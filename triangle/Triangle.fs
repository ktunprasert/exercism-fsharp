module Triangle

let validTriangle (triangle: float list) : bool =
    match triangle with
    | 0.0 :: 0.0 :: 0.0 :: _ -> false
    | a :: b :: c :: _  ->
        a + b >= c && b + c >= a && a + c >= b
    | _ -> false

let equilateral triangle =
    validTriangle triangle && List.distinct triangle |> List.length = 1

let isosceles triangle =
    validTriangle triangle && List.distinct triangle |> List.length < 3

let scalene triangle =
    validTriangle triangle && List.distinct triangle |> List.length = 3
