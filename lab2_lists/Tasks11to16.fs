module Tasks11to16
open System

// Задание 11
let is_global_max_church (arr: int list) (index: int) =
    let rec find_max current_max remaining_list =
        match remaining_list with
        | head :: tail ->
            let new_max = if head > current_max then head else current_max
            find_max new_max tail
        | [] -> current_max
    
    let rec get_element idx lst =
        match lst with
        | head :: tail ->
            if idx = 0 then head
            else get_element (idx - 1) tail
        | [] -> failwith "Out of bounds"
    
    match arr with
    | [] -> false
    | _ ->
        let element = get_element index arr
        let globalMax = find_max Int32.MinValue arr
        element = globalMax

let is_global_max_list (arr: int list) (index: int) =
    if index < 0 || index >= List.length arr then
        false
    else
        let element = List.item index arr
        let globalMax = List.max arr
        element = globalMax