module ProcessingNumbersUI
open ProcessingNumbers

let run_method method number =
    method number

let choose_function n =
    match n with
    | "1" -> max_prime_divisor
    | "2" -> mult_digit_not_divis_by5
    | "3" -> gcd_max_notprime_odd_divisor_and_mult_digits
    | _ -> failwith "Неверный метод"




