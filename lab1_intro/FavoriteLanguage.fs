module FavoriteLanguage

let respondToFavoriteLanguage language =
    match language with
    | "F#" | "Prolog" -> "Подлиза!"
    | "Python" -> "and the Holy Grail!"
    | "Java" -> "Остров в Индонезии!"
    | "C++" -> "Низкоуровневость!"
    | "Ruby" -> "Подлиза из прошлого семестра!"
    | _ -> "Попробуй F#!"