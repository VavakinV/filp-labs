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

let rec gcd a b =
    match b with
    | 0 -> a
    | _ -> gcd b (a % b)

let are_сoprimes a b =
    gcd a b = 1

let obhod_chisla_coprime num (func :int->int->int) initial =
    let rec obhod num acc c =
        match c with
        | 0 -> acc
        | _ ->
            let newAcc = if are_сoprimes num c then func acc c else acc
            obhod num newAcc (c-1)
    obhod num initial num

let euler_func number =
    obhod_chisla_coprime number (fun x y -> x + 1) 0

let obhod_chisla_coprime_condition num (func :int->int->int) initial condition =
    let rec obhod num acc c =
        match c with
        | 0 -> acc
        | _ ->
            let newc = c-1
            let flag = condition c
            match flag, are_сoprimes num c with
            | true, true -> obhod num (func acc c) newc
            | _, _ -> obhod num acc newc
    obhod num initial num