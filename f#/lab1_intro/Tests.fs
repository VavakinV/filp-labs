module Tests

open CircleAndCylinder
open QuadraticEquation
open DigitSum
open Fibonacci
open LogicArg
open ObhodChisla
open FavoriteLanguage
open ProcessingNumbers
open ProcessingNumbersUI

let incorrect_choice () =
    System.Console.WriteLine("Некорректный номер")

// Задание 1
let test1 () =
    System.Console.WriteLine("Hello, World!")

// Задание 2
let test2 () =
    System.Console.Write("Решение квадратного уравнения x^2 - 2x + 1: ")
    System.Console.WriteLine(solve(1,-2, 1))

// Задание 3
let test3 () =
    System.Console.Write("Площадь круга радиуса 3: ")
    System.Console.WriteLine(circle_area(3))

    System.Console.Write("Объём цилиндра радиуса 3 и высоты 5 (суперпозиция): ")
    System.Console.WriteLine(volume_with_area 3 5)

    System.Console.Write("Объём цилиндра радиуса 3 и высоты 5 (каррирование): ")
    System.Console.WriteLine(volume_with_area_3 5)

// Задание 4
let n = 12345
let test4 () =
    System.Console.Write("Сумма цифр 12345 (рекурсия вверх): ")
    System.Console.WriteLine(digit_sum_up n)

// Задание 5
let test5 () =
    System.Console.Write("Сумма цифр 12345 (рекурсия вниз): ")
    System.Console.WriteLine(digit_sum_down n)

// Фибоначчи
let test_fibonacci () =
    System.Console.Write("Фибоначчи (вверх): ")
    System.Console.WriteLine(fibonacci_up 19)
    System.Console.Write("Фибоначчи (вниз): ")
    System.Console.WriteLine(fibonacci_down 19)

// Задание 6
let test6 () =
    System.Console.Write("Факториал 10: ")
    System.Console.WriteLine(digit_sum_or_fact false 10)
    System.Console.Write("Сумма цифр 10: ")
    System.Console.WriteLine(digit_sum_or_fact true 10)

// Задание 7, 8
let count_ a b = a+1
let sum_ a b = a+b
let minDigit a b =
        match (a, b) with
        | (a, b) when a <= b -> a
        | _ -> b
let maxDigit a b =
        match (a, b) with
        | (a, b) when a >= b -> a
        | _ -> b
let test7_8 () =
    System.Console.WriteLine("Обход числа 135:")
    System.Console.Write("Количество цифр: ")
    System.Console.WriteLine(obhod_chisla 135 count_ 0)
    System.Console.Write("Сумма цифр: ")
    System.Console.WriteLine(obhod_chisla 135 sum_ 0)
    System.Console.Write("Минимальная цифра: ")
    System.Console.WriteLine(obhod_chisla 135 minDigit 9)
    System.Console.Write("Максимальная цифра: ")
    System.Console.WriteLine(obhod_chisla 135 maxDigit 0)

let greaterThan3 n = n > 3
let isEven n = n % 2 = 0
let smallerThan4 n = n < 4

// Задание 9, 10
let test9_10 () =
    System.Console.WriteLine("Обход числа 546372 с условием:")
    System.Console.Write("Количество цифр >3: ")
    System.Console.WriteLine(obhod_chisla_condition 546372 count_ 0 greaterThan3)
    System.Console.Write("Сумма чётных цифр: ")
    System.Console.WriteLine(obhod_chisla_condition 546372 sum_ 0 isEven)
    System.Console.Write("Максимальная цифра <4: ")
    System.Console.WriteLine(obhod_chisla_condition 546372 maxDigit 0 smallerThan4)

// Задание 11, 12
let test11_12 () =
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
let test13 () =

    System.Console.Write("Обход взаимно простых компонентов 10 (сумма): ")
    System.Console.WriteLine(obhod_chisla_coprime 10 (+) 0)

// Задание 14
let test14 () =
    System.Console.Write("Функция Эйлера для 20: ")
    System.Console.WriteLine(euler_func 20)

// Задание 15
let test15 () =
    System.Console.Write("Обход взаимно простых компонентов 10, меньших 5 (сумма): ")
    let lessThan5 n = n < 5
    System.Console.WriteLine(obhod_chisla_coprime_condition 10 (+) 0 lessThan5)

// Задания 16-19
let test16_19 () =
    // метод 1
    System.Console.Write("Максимальный простой делитель 20: ")
    System.Console.WriteLine(max_prime_divisor 20)
    // метод 2
    System.Console.Write("Произведение цифр числа, не делящихся на 5 (2554): ")
    System.Console.WriteLine(mult_digit_not_divis_by5 2554)
    // метод 3
    System.Console.Write("НОД максимального нечётного непростого делителя и произведения цифр 28: ")
    System.Console.WriteLine(gcd_max_notprime_odd_divisor_and_mult_digits 315)

// Задание 20
let test20 () = 
    // Суперпозиция
    let process_input = System.Console.ReadLine >> (fun s -> s.Split(' ')) >> (fun arr -> (arr.[0], arr.[1] |> int)) >> (fun (funcId, n) -> choose_function funcId n) >> string >> System.Console.WriteLine
    process_input()

    // Каррирование
    let input = System.Console.ReadLine().Split(' ')
    let x = input.[0]
    let y = input.[1]
    let chosen_function = choose_function x
    let y = int y
    let result = run_method chosen_function y
    System.Console.WriteLine result