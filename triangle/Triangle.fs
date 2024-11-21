module Triangle

let validTriangle (triangle: float list) : bool =
    match triangle with
    | 0.0 :: 0.0 :: 0.0 :: _ -> false
    | a :: b :: c :: _  ->
        a + b >= c && b + c >= a && a + c >= b
    | _ -> false

let distinctSides triangle =
    List.distinct triangle |> List.length

let equilateral triangle =
    validTriangle triangle && distinctSides triangle = 1

let isosceles triangle =
    validTriangle triangle && distinctSides triangle <= 2

let scalene triangle =
    validTriangle triangle && distinctSides triangle = 3
