module CircleAndCylinder

// Задание 3
let circle_area = fun(radius) ->
    let pi = 3.14159
    pi * radius * radius;

let cylinder_volume = fun circlearea height ->
    height * circlearea;

let volume_with_area = circle_area  >> cylinder_volume

let area_radius_3 = circle_area 3
let volume_with_area_3 = cylinder_volume area_radius_3

