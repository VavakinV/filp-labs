open CircleAndCylinder
open QuadraticEquation
open DigitSum
open Fibonacci
open LogicArg
open ObhodChisla
open FavoriteLanguage
open ProcessingNumbers

[<EntryPoint>]
// Задание 1
System.Console.WriteLine("Hello, World!")

// Задание 2
System.Console.Write("Решение квадратного уравнения x^2 - 2x + 1: ")
System.Console.WriteLine(solve(1,-2, 1))

// Задание 3
System.Console.Write("Площадь круга радиуса 3: ")
System.Console.WriteLine(circle_area(3))

System.Console.Write("Объём цилиндра радиуса 3 и высоты 5 (суперпозиция): ")
System.Console.WriteLine(volume_with_area 3 5)

System.Console.Write("Объём цилиндра радиуса 3 и высоты 5 (каррирование): ")
System.Console.WriteLine(volume_with_area_3 5)

// Задание 4
let n = 12345

System.Console.Write("Сумма цифр 12345 (рекурсия вверх): ")
System.Console.WriteLine(digit_sum_up n)

// Задание 5
System.Console.Write("Сумма цифр 12345 (рекурсия вниз): ")
System.Console.WriteLine(digit_sum_down n)

// Фибоначчи
System.Console.Write("Фибоначчи (вверх): ")
System.Console.WriteLine(fibonacci_up 19)
System.Console.Write("Фибоначчи (вниз): ")
System.Console.WriteLine(fibonacci_down 19)

// Задание 6
System.Console.Write("Факториал 10: ")
System.Console.WriteLine(digit_sum_or_fact false 10)
System.Console.Write("Сумма цифр 10: ")
System.Console.WriteLine(digit_sum_or_fact true 10)

// Задание 7, 8
System.Console.WriteLine("Обход числа 135:")

System.Console.Write("Количество цифр: ")
let count_ a b = a+1
System.Console.WriteLine(obhod_chisla 135 count_ 0)

System.Console.Write("Сумма цифр: ")
let sum_ a b = a+b
System.Console.WriteLine(obhod_chisla 135 sum_ 0)

System.Console.Write("Минимальная цифра: ")
let minDigit a b =
    match (a, b) with
    | (a, b) when a <= b -> a
    | _ -> b
System.Console.WriteLine(obhod_chisla 135 minDigit 9)

System.Console.Write("Максимальная цифра: ")
let maxDigit a b =
    match (a, b) with
    | (a, b) when a >= b -> a
    | _ -> b
System.Console.WriteLine(obhod_chisla 135 maxDigit 0)

// Задание 9, 10
System.Console.WriteLine("Обход числа 546372 с условием:")
let greaterThan3 n = n > 3
let isEven n = n % 2 = 0
let smallerThan4 n = n < 4

System.Console.Write("Количество цифр >3: ")
System.Console.WriteLine(obhod_chisla_condition 546372 count_ 0 greaterThan3)

System.Console.Write("Сумма чётных цифр: ")
System.Console.WriteLine(obhod_chisla_condition 546372 sum_ 0 isEven)

System.Console.Write("Максимальная цифра <4: ")
System.Console.WriteLine(obhod_chisla_condition 546372 maxDigit 0 smallerThan4)

// Задание 11, 12

// Суперпозиция
let languageMainSup = (fun () -> System.Console.ReadLine()) >> respondToFavoriteLanguage >> System.Console.WriteLine
System.Console.WriteLine("Какой твой любимый язык программирования?")
languageMainSup ()

// Каррирование
let languageMainCar input output = 
    output (respondToFavoriteLanguage input)

System.Console.WriteLine("Какой твой любимый язык программирования?")
let getInput = languageMainCar (System.Console.ReadLine())
getInput System.Console.WriteLine

// Задание 13
System.Console.Write("Обход взаимно простых компонентов 10 (сумма): ")
System.Console.WriteLine(obhod_chisla_coprime 10 (+) 0)

// Задание 14
System.Console.Write("Функция Эйлера для 20: ")
System.Console.WriteLine(euler_func 20)

// Задание 15
System.Console.Write("Обход взаимно простых компонентов 10, меньших 5 (сумма): ")
let lessThan5 n = n < 5
System.Console.WriteLine(obhod_chisla_coprime_condition 10 (+) 0 lessThan5)

// Задание 16
// метод 1
System.Console.Write("Максимальный простой делитель 20: ")
System.Console.WriteLine(max_prime_divisor 20)
// метод 2
// метод 3