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

let mult_two a b = a*b

let not_divis_by_5 n = n%5 <> 0

let mult_digit_not_divis_by5 n =
    obhod_chisla_condition n mult_two 1 not_divis_by_5

let odd_notprime n = not (is_prime n) && n % 2 = 1 
let max_notprime_odd_divisor n = max_divisor_condition n odd_notprime

let mult_digits n = obhod_chisla n mult_two 1

let gcd_max_notprime_odd_divisor_and_mult_digits n =
    gcd (max_notprime_odd_divisor n) (mult_digits n)

