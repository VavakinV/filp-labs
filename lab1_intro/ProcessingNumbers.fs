module ProcessingNumbers
open ObhodChisla

let is_prime number =
    let rec check d =
        match d*d > number with
        | true -> true
        | false ->
            match number%d with
            | 0 -> false
            | _ -> check (d+1)
    match number < 2 with
    | true -> false
    | false -> check 2

let max_divisor_condition number (condition :int->bool) =
    let rec find num divisor max =
        match divisor > num/2 with
        | true -> max
        | false ->
            let nextDivisor = divisor+1
            match num%divisor with
            | 0 when condition divisor -> find num nextDivisor divisor
            | _ -> find num nextDivisor max
    find number 3 1

let max_prime_divisor number =
    max_divisor_condition number (fun x -> is_prime x)