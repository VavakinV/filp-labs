module ReduceList

let rec reduce_list list (f: int->int->int) (condition: int->bool) acc =
    match list with
    | [] -> acc
    | head::tail ->
        let current = head
        let flag = condition current
        let newAcc = if condition current then f acc current else acc
        reduce_list tail f condition newAcc
    
let min_list list = 
    match list with
    | [] -> 0
    | head::tail -> reduce_list list (fun a b -> if a < b then a else b) (fun a -> true) head

let sum_even list = reduce_list list (+) (fun a -> a%2 = 0) 0

let count_odd list = reduce_list list (fun a b -> a+1) (fun a -> a%2 = 1) 0

let rec frequency list num count =
    match list with
    | [] -> count
    | head::tail -> 
        let newCount = if head = num then count+1 else count
        frequency tail num newCount



