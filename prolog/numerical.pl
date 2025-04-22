% Задание 1
% Максимум
max(X, Y, X) :- X>Y, !.
max(_, Y, Y).

max(X, Y, Z, U) :-
    max(X, Y, M), max(M, Z, U).

max(X, Y, Z, X) :- X>Y, X>Z, !.
max(_, Y, Z, Y) :- Y>Z, !.
max(_, _, Z, Z).

% Факториал
fact_up(0, 1).
fact_up(N, X) :-
    N > 0,
    N1 is N - 1,
    fact_up(N1, X1),
    X is N * X1. 

fact_down(N, X) :- 
    fact_tail(N, 1, X).

fact_tail(0, Acc, Acc).
fact_tail(N, Acc, X) :-
    N > 0,
    NewAcc is N * Acc,
    N1 is N - 1,
    fact_tail(N1, NewAcc, X).


% Сумма цифр
digit_sum_up(0, 0) :- !.
digit_sum_up(N, S) :-
    Digit is N mod 10,
    NewN is N div 10,
    digit_sum_up(NewN, NewSum),
    S is NewSum + Digit.

digit_sum_down(N, S) :-
    digit_sum_tail(N, 0, S).

digit_sum_tail(0, Acc, Acc) :- !.

digit_sum_tail(N, Acc, S) :-
    NewN is N div 10,
    NewAcc is Acc + N mod 10,
    digit_sum_tail(NewN, NewAcc, S).

% Проверка на свободность от квадратов
square_free(1).
square_free(N) :-
    N > 1,
    \+ has_square_factor(N, 2).

has_square_factor(N, K) :-
    K * K =< N,
    (
        0 is N mod (K * K); 
        NextK is K + 1,
        has_square_factor(N, NextK)
    ).

% Чтение списка
r_list(A, N):-r_list(A, N, 0, []).
r_list(A, N, N, A):-!.
r_list(A, N, K, B):-read(X), append(B,[X],B1), K1 is K+1, r_list(A, N, K1, B1).

% Запись в список
w_list([]):-!.
w_list([H|T]) :- write(H), nl, w_list(T).

% Добавление в список
my_ap([], Y, Y).
my_ap([H|T], Y, [H|T1]) :- my_ap(T, Y, T1).

% Проверка на наличие в списке
in_list([], _) :- false.
in_list([X|T], X).
in_list([_|T], X) :- in_list(T, X).

% Получение элемента по индексу
get_at(0, [Head|_], Head).

get_at(Index, [_|Tail], Element) :-
    Index > 0,
    NewIndex is Index - 1,
    get_at(NewIndex, Tail, Element).

% Сумма элементов списка
sum_list_up([], 0).

sum_list_up([H|T], Sum) :-
    sum_list_up(T, TS),
    Sum is H + TS.

sum_list_down(List, Sum) :-
    sum_list_down(List, 0, Sum).

sum_list_down([], Acc, Acc).

sum_list_down([H|T], Acc, Sum) :-
    NewAcc is Acc + H,
    sum_list_down(T, NewAcc, Sum).

% Удаление элементов с не равной суммой цифр
remove_if_sum_equal([], _, []).

remove_if_sum_equal([X | Tail], TargetSum, Result) :-
    digit_sum_down(X, Sum),
    (Sum =:= TargetSum -> remove_if_sum_equal(Tail, TargetSum, Result); Result = [X | NewResult], remove_if_sum_equal(Tail, TargetSum, NewResult)).

% Задание 2
% Минимальная цифра числа
min_digit_up(N, N) :- 
    N >= 0, N < 10.

min_digit_up(N, Min) :-
    N >= 10,
    LastDigit is N mod 10,
    Rest is N // 10,
    min_digit_up(Rest, MinRest),
    Min is min(LastDigit, MinRest).

min_digit_down(0, Min) :- 
    Min = 0.
min_digit_down(N, Min) :-
    min_digit_down(N, 9, Min).

min_digit_down(0, Acc, Acc).

min_digit_down(N, Acc, Min) :-
    N > 0,
    LastDigit is N mod 10,
    NewAcc is min(Acc, LastDigit),
    Rest is N // 10,
    min_digit_down(Rest, NewAcc, Min).

% Произведение цифр, не делящихся на 5
product_non_fives_up(0, 0).
product_non_fives_up(N, N) :- 
    N > 0, N < 10, N mod 5 =\= 0.

product_non_fives_up(N, Product) :-
    N >= 10,
    LastDigit is N mod 10,
    LastDigit mod 5 =:= 0,
    Rest is N // 10,
    product_non_fives_up(Rest, Product).

product_non_fives_up(N, Product) :-
    N >= 10,
    LastDigit is N mod 10,
    LastDigit mod 5 =\= 0,
    Rest is N // 10,
    product_non_fives_up(Rest, PartialProduct),
    Product is LastDigit * PartialProduct.

product_non_fives_down(N, Product) :-
    N >= 0,
    product_non_fives_down(N, 1, Product).


product_non_fives_down(0, Acc, Acc).

product_non_fives_down(N, Acc, Product) :-
    N > 0,
    LastDigit is N mod 10,
    LastDigit mod 5 =:= 0,
    Rest is N // 10,
    product_non_fives_down(Rest, Acc, Product).

product_non_fives_down(N, Acc, Product) :-
    N > 0,
    LastDigit is N mod 10,
    LastDigit mod 5 =\= 0,
    NewAcc is Acc * LastDigit,
    Rest is N // 10,
    product_non_fives_down(Rest, NewAcc, Product).

% НОД
gcd(X, 0, X) :- X > 0.

gcd(X, Y, GCD) :-
    Y > 0,
    Remainder is X mod Y,
    gcd(Y, Remainder, GCD).

% Задание 3
% Проверка на глобальный максимум
has_greater([Head|_], Element) :- Head > Element.
has_greater([_|Tail], Element) :- has_greater(Tail, Element). 

is_global_max(List, Index) :-
    get_at(Index, List, Element),
    \+ has_greater(List, Element).

% Проверка на локальный минимум
is_local_min(List, Index) :-
    get_at(Index, List, Element),
    check_left_neighbor(List, Index, Element),
    check_right_neighbor(List, Index, Element).

check_left_neighbor(List, Index, Element) :-
    LeftIndex is Index - 1,
    ( LeftIndex >= 0 ->
        get_at(LeftIndex, List, Left),
        Left > Element
    ; true ).

check_right_neighbor(List, Index, Element) :-
    RightIndex is Index + 1,
    length(List, Length),
    ( RightIndex < Length ->
        get_at(RightIndex, List, Right),
        Right > Element
    ; true ).  

% Циклический сдвиг влево на 1
rotate_left([], []).
rotate_left([Head | Tail], Rotated) :-
    my_ap(Tail, [Head], Rotated). 

% Задание 4
solve_friends :-
    Friends = [_,_,_,_],

    in_list(Friends, [locksmith,WHO1,no,young]),
    in_list(Friends, [turner,WHO2,_,ageT]),
    in_list(Friends, [welder,WHO3,_,_]),

    in_list(Friends, [_,borisov,sister,_]),
    in_list(Friends, [_,ivanov,_,_]),
    in_list(Friends, [_,semenov,_,ageS]),

    write("Locksmith: "), write(WHO1), nl,
    write("Turner: "), write(WHO2), nl,
    write("Welder: "), write(WHO3), nl.

% Задание 5
is_prime(2).
is_prime(N) :-
    N > 2,
    N mod 2 =\= 0,
    has_no_divisors(N, 3).

has_no_divisors(N, K) :- 
    K * K > N, !.
has_no_divisors(N, K) :- 
    N mod K =\= 0,
    NextK is K + 2,
    has_no_divisors(N, NextK).

max_prime_divisor(N, MaxDiv) :- 
    N > 1,
    max_prime_divisor(N, 2, 1, MaxDiv).

max_prime_divisor(1, _, Acc, Acc) :- !.
max_prime_divisor(N, K, Acc, MaxDiv) :- 
    K * K > N, !,
    (is_prime(N) -> MaxDiv = N ; MaxDiv = Acc).

max_prime_divisor(N, K, Acc, MaxDiv) :- 
    N mod K =:= 0,
    (is_prime(K) -> NewAcc = max(Acc, K) ; NewAcc = Acc),
    NextN is N // K,
    max_prime_divisor(NextN, K, NewAcc, MaxDiv).

max_prime_divisor(N, K, Acc, MaxDiv) :- 
    N mod K =\= 0,
    NextK is K + 1,
    max_prime_divisor(N, NextK, Acc, MaxDiv).


max_odd_nonprime_divisor(N, MaxDiv) :-
    N > 1,
    max_odd_nonprime_divisor(N, 3, 1, MaxDiv).

max_odd_nonprime_divisor(1, _, Acc, Acc) :- !.

max_odd_nonprime_divisor(N, K, Acc, MaxDiv) :- 
    K * K > N, !,
    (N > 1, N mod 2 =\= 0, \+ is_prime(N) -> 
        MaxDiv = max(Acc, N) 
    ; 
        MaxDiv = Acc
    ).

max_odd_nonprime_divisor(N, K, Acc, MaxDiv) :- 
    N mod K =:= 0,
    (K mod 2 =\= 0, \+ is_prime(K) -> 
        NewAcc = max(Acc, K),
        NextN is N // K,
        (NextN =:= 1 -> MaxDiv = NewAcc
         ; max_odd_nonprime_divisor(NextN, K, NewAcc, MaxDiv))
    ; 
        NextN is N // K,
        (NextN =:= 1 -> MaxDiv = Acc
         ; max_odd_nonprime_divisor(NextN, K, Acc, MaxDiv))
    ).

max_odd_nonprime_divisor(N, K, Acc, MaxDiv) :- 
    N mod K =\= 0,
    NextK is K + 2,
    max_odd_nonprime_divisor(N, NextK, Acc, MaxDiv).

digit_product(0, 0) :- !.
digit_product(N, S) :-
    N > 0,
    digit_product_tail(N, 1, S).

digit_product_tail(0, Acc, Acc) :- !.
digit_product_tail(N, Acc, S) :-
    N > 0,
    Digit is N mod 10,
    NewN is N // 10,
    NewAcc is Acc * Digit,
    digit_product_tail(NewN, NewAcc, S).

target_gcd(N, Result) :-
    N > 0,
    max_odd_nonprime_divisor(N, MaxDiv),
    digit_product(N, Product),
    gcd(MaxDiv, Product, Result).

% Задание 6
% Четные индексы затем нечетные индексы
split_even_odd(List, Result) :-
    split(List, 0, Even, Odd),
    my_ap(Even, Odd, Result),
    !.

split([], _, [], []).

split([H|T], Index, [H|Even], Odd) :-
    0 is Index mod 2,
    NewIndex is Index + 1,
    split(T, NewIndex, Even, Odd).

split([H|T], Index, Even, [H|Odd]) :-
    1 is Index mod 2,
    NewIndex is Index + 1,
    split(T, NewIndex, Even, Odd).

% Частоты уникальных элементов
count_occurrences(List, L1, L2) :-
    sort(List, Sorted),
    count_all(List, Sorted, L2),
    L1 = Sorted.

count_all(_, [], []).
count_all(List, [H|T], [Count|Counts]) :-
    count_in_list(List, H, Count),
    count_all(List, T, Counts).

count_in_list(List, Elem, Count) :-
    filter_elements(List, Elem, Filtered),
    length(Filtered, Count).

filter_elements([], _, []).
filter_elements([H|T], Elem, [H|Rest]) :-
    H == Elem,
    filter_elements(T, Elem, Rest).
filter_elements([H|T], Elem, Rest) :-
    H \== Elem,
    filter_elements(T, Elem, Rest).

% Задание 7
solve_facs :-
    Faculties = [math, physics, chemistry],

    in_list(Faculties, FacP),
    in_list(Faculties, FacR),
    in_list(Faculties, FacS),
    
    ( FacP = math -> FacS \= physics ; true ),
    ( FacR \= physics -> FacP = math ; true ),
    ( FacS \= math -> FacR = chemistry ; true ),
    
    FacP \= FacR,
    FacP \= FacS,
    FacR \= FacS,
    
    write("Petr: "), write(FacP), nl,
    write("Roman: "), write(FacR), nl,
    write("Sergey: "), write(FacS), nl.


