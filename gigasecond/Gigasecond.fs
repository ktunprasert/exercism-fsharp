module Gigasecond

open System

let GigaSecond = 1_000_000_000L

let add (beginDate: DateTime): DateTime = beginDate.AddSeconds(float GigaSecond)

