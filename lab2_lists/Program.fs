open System

open ReadList
open WriteList
open ReduceList
open BinaryTree
open ListProcessing
open Tasks11to16
open GenerateABTuple
open CombineLists
open ShuffleWords
open SortStringsASCII

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
    Console.WriteLine("Перемещение всех элементов перед минимумом в конец:")
    Console.Write("Чёрч: ")
    print_list (move_before_min_church arr)
    Console.Write("List: ")
    print_list (move_before_min_list arr)
    Console.WriteLine("Два наименьших элемента списка:")
    Console.Write("Чёрч: ")
    Console.WriteLine(find_two_min_church arr)
    Console.Write("List: ")
    Console.WriteLine(find_two_min_list arr)
    Console.WriteLine("Проверка на чередование положительных/отрицательных:")
    Console.Write("Чёрч: ")
    Console.WriteLine(is_alternating_church arr)
    Console.Write("List: ")
    Console.WriteLine(is_alternating_list arr)
    Console.WriteLine("Количество минимальных элементов:")
    Console.Write("Чёрч: ")
    Console.WriteLine(count_min_elements_church arr)
    Console.Write("List: ")
    Console.WriteLine(count_min_elements_list arr)
    Console.WriteLine("Значения между средним арифметическим и максимумом:")
    Console.Write("Чёрч: ")
    print_list (filter_between_avg_and_max_church arr)
    Console.Write("List: ")
    print_list (filter_between_avg_and_max_list arr)
    Console.Write("Введите число: ")
    let N = Console.ReadLine() |> int
    Console.WriteLine("Построенные кортежи (a,b): ")
    print_list (generate_ab_tuples N)
    Console.WriteLine("Объединение списков [1, 2, 3] и [4, 5, 6]:")
    let ar1 = [1; 2; 3]
    let ar2 = [4; 5; 6]
    print_list (combine_lists ar1 ar2)
    Console.WriteLine("Перемешивание строки 'apple banana orange grape mango':")
    Console.WriteLine(shuffle_words "apple banana orange grape mango")
    Console.WriteLine("Сортировка по квадратичному отклонению среднего веса ASCII-кода символа строки от следнего веса первой строки:")
    Console.WriteLine("Исходный массив: ['abc', 'a', 'aaaaa', 'uyo', 'tel', 'lorem']")
    Console.Write("Отсортированный массив: ")
    print_list (sort_by_ASCII_deviation ["abc"; "a"; "aaaaa"; "uyo"; "tel"; "lorem"])
    0
 