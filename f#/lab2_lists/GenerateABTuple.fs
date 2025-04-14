module GenerateABTuple
open System

let rec gcd a b =
    if b = 0 then a
    else gcd b (a % b)

let generate_ab_tuples N =
    let divisors = 
        [1..N] 
        |> List.filter (fun x -> N % x = 0)

    let pairs =
        divisors
        |> List.collect (fun x -> 
            let y = N / x
            [(x, y)])

    pairs
    |> List.map (fun (x, y) ->
        let d = gcd x y
        (x / d, y / d))
    |> List.distinct
    |> List.sort
