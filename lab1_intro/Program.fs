open Tests

[<EntryPoint>]
let main argv =
    System.Console.Write("Выберите задание для проверки: ")
    let user_choice = System.Console.ReadLine()
    match user_choice with
    | "1" -> test1 ()
    | "2" -> test2 ()
    | "3" -> test3 ()
    | "4" -> test4 ()
    | "5" -> test5 ()
    | "6" -> test6 ()
    | "7" | "8" -> test7_8 ()
    | "9" | "10" -> test9_10 ()
    | "11" | "12" -> test11_12 ()
    | "13" -> test13 ()
    | "14" -> test14 ()
    | "15" -> test15 ()
    | "16" | "17" | "18" | "19" -> test16_19 ()
    | "20" -> test20 ()
    | _ -> incorrect_choice ()
    0