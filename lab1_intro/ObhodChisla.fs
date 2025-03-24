module ObhodChisla

let rec obhod_chisla n (f: int->int->int) acc =
    match n with
    | 0 -> acc
    | n -> obhod_chisla (n/10) f (f acc (n%10))
    