module ObhodChisla

let rec obhod_chisla n (f: int->int->int) acc =
    match n with
    | 0 -> acc
    | n -> obhod_chisla (n/10) f (f acc (n%10))

let rec obhod_chisla_condition n (f: int->int->int) acc (condition: int->bool) =
    match n with
    | 0 -> acc
    | n ->
        let digit = n % 10
        let newAcc = 
            match condition digit with
            | true -> f acc digit
            | false -> acc
        obhod_chisla_condition (n/10) f newAcc condition