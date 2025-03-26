module ReadList

let readList n =
    let rec read n list =
        match n with
        | 0 -> list
        | k -> 
            let element = System.Console.ReadLine() |> int
            let newList = list@[element]
            read (k - 1) newList
    read n []
