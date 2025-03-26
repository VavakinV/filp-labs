open ReadList
open WriteList
open ReduceList

[<EntryPoint>]
let main argv = 
    System.Console.WriteLine("Введите 5 элементов списка:")
    let arr = readList 5
    System.Console.WriteLine("Вывод списка:")
    writeList arr
    System.Console.WriteLine("Сумма элементов меньших 5:")
    let sumLess5 = reduce_list arr (+) (fun (x) -> x < 5) 0
    System.Console.WriteLine sumLess5
    System.Console.WriteLine("Минимальный элемент:")
    System.Console.WriteLine(min_list arr)
    System.Console.WriteLine("Сумма чётных:")
    System.Console.WriteLine(sum_even arr)
    System.Console.WriteLine("Количество нечётных:")
    System.Console.WriteLine(count_odd arr)
    System.Console.WriteLine(frequency arr 3 0)
    0