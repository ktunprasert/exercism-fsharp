module LogLevels

open System

let message (logLine: string): string =
    match logLine.Trim().Split(": ", StringSplitOptions.TrimEntries) with
    | [|"[INFO]";message|] -> message
    | [|"[WARNING]";message|] -> message
    | [|"[ERROR]";message|] -> message
    | _ -> failwith "Invalid log line"


let logLevel(logLine: string): string =
    match logLine with
    | s when s.StartsWith("[INFO]") -> "info"
    | s when s.StartsWith("[WARNING]") -> "warning"
    | s when s.StartsWith("[ERROR]") -> "error"
    | _ -> failwith "Invalid log line"


let reformat(logLine: string): string =
    message logLine + $" ({logLevel logLine})"
