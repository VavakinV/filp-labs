module IZFunctions

let modulo = 100000I
let global_limit = 1000000000000I

let rec shrink_number n =
    match n % modulo = 0I with
    | false -> n
    | true ->
        let newN = n / 5I
        shrink_number newN

let remove_tens n result =
    let rec loop n result =
        match n % 5I = 0I with
        | false -> n, result
        | true -> 
            let newResult = result / 2I
            let newN = n / 5I
            loop newN newResult
    loop n result

let five_digits_of_fact n =
    let n = shrink_number n
    let rec factfunc n acc limit =
        match n > limit with
        | true -> acc % modulo
        | false ->
            let newN, newAcc = remove_tens n acc
            let updatedAcc = (newAcc * (newN % modulo)) % global_limit
            let nextN = n + 1I
            factfunc nextN updatedAcc limit
    factfunc 1I 1I n