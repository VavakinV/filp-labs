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

let max_list list = 
    match list with
    | [] -> 0
    | head::tail -> reduce_list list (fun a b -> if a > b then a else b) (fun a -> true) head

let sum_even list = reduce_list list (+) (fun a -> a%2 = 0) 0

let count_odd list = reduce_list list (fun a b -> a+1) (fun a -> a%2 = 1) 0

let rec frequency list num count =
    match list with
    | [] -> count
    | head::tail -> 
        let newCount = if head = num then count+1 else count
        frequency tail num newCount

let rec freq_list list main_list cur_list = 
    match list with
    | [] -> cur_list
    | head::tail -> 
        let freq_elem = frequency main_list head 0
        let new_list = cur_list @ [freq_elem]
        freq_list tail main_list new_list

let pos list el = 
    let rec pos_inner list el num = 
        match list with
            |[] -> 0
            |head::tail -> 
                if (head = el) then num
                else 
                    let num1 = num + 1
                    pos_inner tail el num1
    pos_inner list el 1

let get_from_list list pos = 
    let rec get list num cur_num = 
        match list with 
            |[] -> 0
            |head::tail -> 
                if num = cur_num then head
                else 
                    let new_num = cur_num + 1
                    get tail num new_num
    get list pos 1

let find_most_frequent list = 
    let fL = freq_list list list []
    (max_list fL) |> (pos fL) |> (get_from_list list)   
