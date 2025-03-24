module LogicArg

open DigitSum

let factorial n:int =
    let rec factorial_tail n acc =
        match n with
        | 1 -> acc
        | _ -> factorial_tail (n-1) (acc*n)
    factorial_tail n 1

let digit_sum_or_fact flag =
    match flag with
    | true -> digit_sum_down
    | false -> factorial

