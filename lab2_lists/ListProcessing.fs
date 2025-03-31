module ListProcessing
open System

let most_frequent list =
    list
    |> List.countBy id
    |> List.sortByDescending snd
    |> List.head
    |> fst

let count_square_elements (list: int list) =
    let unique_elements = List.distinct list
    list
    |> List.filter (fun x ->
        unique_elements
        |> List.exists (fun y -> y * y = x)
    )
    |> List.length

let digit_sum n:int =
    let rec digit_sum_inner n curSum =
        if n = 0 then curSum
        else
            let n1 = n/10
            let digit = n%10
            let sum = curSum + digit
            digit_sum_inner n1 sum
    digit_sum_inner n 0

let count_divisors n =
    if n = 0 then 0
    else
        let nAbs = abs n
        [1..nAbs] |> List.filter (fun x -> nAbs % x = 0) |> List.length

let create_tuples (listA: int list) (listB: int list) (listC: int list) =
    let sortedA = listA |> List.sortByDescending id
    
    let sortedB = 
        listB 
        |> List.sortBy (fun x -> (digit_sum x, abs x))
    
    let sortedC = 
        listC 
        |> List.sortByDescending (fun x -> (count_divisors x, abs x))
    
    List.zip3 sortedA sortedB sortedC

let read_and_sort_strings_by_length () =
    let rec readLines acc =
        let line = Console.ReadLine()
        if String.IsNullOrEmpty(line) then
            acc
        else
            readLines (line :: acc)
    
    let lines = readLines [] |> List.rev
    lines |> List.sortBy (fun s -> s.Length)