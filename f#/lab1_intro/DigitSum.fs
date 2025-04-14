module DigitSum

// Задание 4

let rec digit_sum_up (n:int) =
    if n < 10 then n
    else n%10 + digit_sum_up (n / 10)

// Задание 5

let digit_sum_down (n:int) =
    let rec digit_sum_inner n curSum =
        if n = 0 then curSum
        else
            let n1 = n/10
            let digit = n%10
            let sum = curSum + digit
            digit_sum_inner n1 sum
    digit_sum_inner n 0
