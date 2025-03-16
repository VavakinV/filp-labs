open CircleAndCylinder
open QuadraticEquation
open DigitSum

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