write_str([]) :- !.
write_str([H|T]) :-
    put(H),
    write_str(T).

in_list([X|_], X).
in_list([_|T], X) :-
    in_list(T, X).

% удаление из первого списка всех элементов второго
remove_list([], _, []) :- !.
remove_list([H|T], R, Res) :-
    in_list(R, H), !,
    remove_list(T, R, Res).
remove_list([H|T], R, [H|Res]) :-
    remove_list(T, R, Res).

make_pos_list(K, K, []) :- !.
make_pos_list(K, Cur, [Next|Ps]) :-
    Next is Cur + 1,
    make_pos_list(K, Next, Ps).

sochet([], _, 0) :- !.
sochet([H|Tsub], [H|Tset], K) :-
    K1 is K - 1,
    sochet(Tsub, Tset, K1).
sochet(Sub, [_|Tset], K) :-
    sochet(Sub, Tset, K).

% выбор мест для d и e в зависимости от остатка
choose_de(0, _, [], []) :- !.
% ровно одна буква d
choose_de(1, Rem, [Pd], []) :-
    sochet([Pd], Rem, 1).
% ровно одна буква e
choose_de(1, Rem, [], [Pe]) :-
    sochet([Pe], Rem, 1).
% обе буквы
choose_de(2, Rem, [Pd], [Pe]) :-
    sochet([P1,P2], Rem, 2),
    ( Pd = P1, Pe = P2
    ; Pd = P2, Pe = P1 ).

% сборка слова
build_word(N, I, PosA, PosB, PosC, PosD, PosE, []) :-
    I > N, !.
build_word(N, I, PosA, PosB, PosC, PosD, PosE, [L|T]) :-
    ( in_list(PosA, I) -> L = a
    ; in_list(PosB, I) -> L = b
    ; in_list(PosC, I) -> L = c
    ; in_list(PosD, I) -> L = d
    ; in_list(PosE, I) -> L = e
    ),
    I1 is I + 1,
    build_word(N, I1, PosA, PosB, PosC, PosD, PosE, T).

% основной предикат
write_words(N, File) :-
    tell(File),
    make_pos_list(N, 0, AllPos),
    
    % выбор мест a
    sochet(PosA, AllPos, 3),
    remove_list(AllPos, PosA, R1),
    % выбор мест b
    sochet(PosB, R1, 2),
    remove_list(R1, PosB, R2),
    % выбор мест c
    sochet(PosC, R2, 2),
    remove_list(R2, PosC, R3),
    % кол-во мест для d и e
    M is N - 7,
    % выбор мест d и e
    choose_de(M, R3, PosD, PosE),

    build_word(N, 1, PosA, PosB, PosC, PosD, PosE, Word),
    write_str(Word), nl,
    fail
;   told.
