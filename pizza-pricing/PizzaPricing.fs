module PizzaPricing

type Pizza =
    | Margherita
    | Caprese
    | Formaggio
    | ExtraSauce of Pizza
    | ExtraToppings of Pizza

let rec pizzaPrice (pizza: Pizza) : int =
    match pizza with
    | Margherita -> 7
    | Caprese -> 9
    | Formaggio -> 10
    | ExtraSauce p -> 1 + pizzaPrice p
    | ExtraToppings p -> 2 + pizzaPrice p

let orderPrice (pizzas: Pizza list) : int =
    match pizzas with
    | [ p ] -> pizzaPrice p + 3
    | [ p1; p2 ] -> pizzaPrice p1 + pizzaPrice p2 + 2
    | pzs -> pzs |> List.sumBy pizzaPrice
