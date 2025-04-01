module ShuffleWords
open System

let shuffle_words (input: string) =
    let words = input.Split([|' '|], StringSplitOptions.RemoveEmptyEntries) |> Array.toList
    let rnd = Random()
    words
    |> List.sortBy (fun _ -> rnd.Next())
    |> String.concat " "