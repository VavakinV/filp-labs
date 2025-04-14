module QuadraticEquation

// Задание 2
let solve = fun(a, b, c) ->
    let D = b*b-4.0*a*c 
    ((-b+sqrt(D))/(2.0*a), (-b-sqrt(D))/(2.0*a));

