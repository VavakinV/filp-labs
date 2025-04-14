module SortStringsASCII
open System

let sort_by_ASCII_deviation (strings: string list) =
    match strings with
    | [] -> []
    | head :: tail ->
        let firstAvg = 
            head 
            |> Seq.averageBy float
        let sqd s =
            let currentAvg = s |> Seq.averageBy float
            (currentAvg - firstAvg) ** 2.0
        head :: (tail |> List.sortBy sqd)