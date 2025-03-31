open System

open ReadList
open WriteList
open ReduceList
open BinaryTree
open ListProcessing
open Tasks11to16

[<EntryPoint>]
let main argv = 
    Console.WriteLine("Введите 5 элементов списка:")
    let arr = readList 5
    System.Console.WriteLine("Вывод списка:")
    writeList arr
    System.Console.Write("Сумма элементов меньших 5: ")
    let sumLess5 = reduce_list arr (+) (fun (x) -> x < 5) 0
    Console.WriteLine sumLess5
    Console.Write("Минимальный элемент: ")
    Console.WriteLine(min_list arr)
    Console.Write("Сумма чётных: ")
    Console.WriteLine(sum_even arr)
    Console.Write("Количество нечётных: ")
    Console.WriteLine(count_odd arr)
    Console.Write("Самый часто встречающийся элемент: ")
    Console.WriteLine(find_most_frequent arr)
    let tree = 
        empty
        |> insert "banana"
        |> insert "apple"
        |> insert "cherry"
        |> insert "mango"
        |> insert "lemon"
    Console.WriteLine("Вывод двоичного дерева:")
    print_tree tree
    Console.Write("Самый частый элемент с использованием класса List: ")
    Console.WriteLine(most_frequent arr)
    Console.Write("Количество элементов, которые могут быть квадратами других элементов: ")
    Console.WriteLine(count_square_elements arr)
    let listA = [10; 5; 8; 3]   
    let listB = [123; 45; 9; 54]
    let listC = [12; 7; 24; 6]
    Console.Write("Список из кортежей (ai, bi, ci): ")
    Console.WriteLine(create_tuples listA listB listC)
    Console.WriteLine("Введите строки (пустая строка - остановка):")
    let sorted_strings = read_and_sort_strings_by_length ()
    Console.WriteLine("Отсортированные по длине строки: ")
    sorted_strings |> List.iter (Console.WriteLine)
    Console.WriteLine("Проверка элемента по индексу 3 на глобальный максимум:")
    Console.Write("Чёрч: ")
    Console.WriteLine(is_global_max_church arr 3)
    Console.Write("List: ")
    Console.WriteLine(is_global_max_list arr 3)
    0