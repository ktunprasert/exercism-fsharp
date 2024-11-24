module Gigasecond

open System

let GigaSecond = 1_000_000_000.0

let add (beginDate: DateTime): DateTime = beginDate.AddSeconds(GigaSecond)

