module Fibonacci

let rec fibonacci_up (n:int) =
    match n with
    | 1 -> 1
    | 2 -> 1 
    | _ -> fibonacci_up (n-1) + fibonacci_up (n-2)


let fibonacci_down (n:int) = 
    let rec fibonacci_down_inner x curSum n =
        match n with
        | 1 -> curSum
        | _ -> fibonacci_down_inner curSum (curSum+x) (n-1)
    fibonacci_down_inner 0 1 n


