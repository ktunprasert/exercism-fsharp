module Meetup

open System

type Week =
    | First
    | Second
    | Third
    | Fourth
    | Last
    | Teenth

let meetup (year: int) (month: int) (week: Week) (dayOfWeek: DayOfWeek) : DateTime =
    let firstDay = DateTime(year, month, 1)
    let daysToAdd = (int dayOfWeek - int firstDay.DayOfWeek + 7) % 7
    let firstDayOfWeek = firstDay.AddDays(float daysToAdd)

    match week with
    | First -> firstDayOfWeek
    | Second -> firstDayOfWeek.AddDays(7.0)
    | Third -> firstDayOfWeek.AddDays(14.0)
    | Fourth -> firstDayOfWeek.AddDays(21.0)
    | Last ->
        [ 5; 4; 3; 2; 1 ]
        |> List.map (fun i -> firstDayOfWeek.AddDays(float i * 7.0))
        |> List.find (fun d -> d.Month = month)

    | Teenth ->
        [ 0..3 ]
        |> List.map (fun i -> firstDayOfWeek.AddDays(float i * 7.0))
        |> List.find (fun d -> d.Day >= 13 && d.Day <= 19)
