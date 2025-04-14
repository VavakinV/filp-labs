% Мужчины
man(ivan).  
man(alexey).  
man(dmitry).  
man(sergey).  
man(andrey).  
man(mikhail). 
man(georgiy).
 
 % Женщины
woman(anna).  
woman(olga).  
woman(ekaterina).  
woman(tatyana).  
woman(natalia).  
woman(maria). 
woman(helena).

% Родители
parent(ivan, alexey).
parent(olga, alexey).
parent(ivan, ekaterina).
parent(olga, ekaterina).
parent(ivan, anna).
parent(olga, anna).
parent(ivan, sergey).
parent(olga, sergey).
parent(mikhail, andrey).
parent(natalia, andrey).
parent(sergey, mikhail).
parent(ekaterina, mikhail).
parent(sergey, georgiy).
parent(ekaterina, georgiy).

% Вывод всех мужчин
men :- man(X), write(X), nl, fail.
men.

% Вывод всех женщин
women :- woman(X), write(X), nl, fail.
women.

% Вывод всех детей X
children(X) :- parent(X, Y), write(Y), nl, fail.
children(X).

% Является ли X матерью Y
mother(X, Y) :- woman(X), parent(X, Y).

% Мать X
mother(X) :- parent(Y, X), woman(Y), write(Y), nl.

% Является ли X братом Y
brother(X, Y) :- man(X), X \= Y, parent(P, X), parent(P, Y), !.   

% Вывод всех братьев X
brothers(X) :-
    setof(B, brother(B, X), Brothers),
    write(Brothers), nl.

% Являются ли X и Y родными братьями/сёстрами
b_s(X, Y) :- parent(Z, X), parent(Z, Y).

% Все братья и сёстры (X)
b_s(X) :- 
    setof(Y, (b_s(Y, X), Y\=X), BS),
    write(BS), nl.

% Является ли X дочерью Y
daughter(X, Y) :- woman(X), parent(Y, X).

% Дочь X
daughter(X) :- daughter(Y, X), write(Y).
daughter(X).

% Является ли X женой Y
wife(X, Y) :- woman(X), parent(X, Z), parent(Y, Z), !.

% Жена X
wife(X) :- parent(X, Z), parent(Y, Z), woman(Y), write(Y), !.

% Является ли X внуком Y
grand_so(X, Y) :- man(X), parent(Y, Z), parent(Z, X), !.

% Вывод всех внуков X
grand_sons(X) :- 
    setof(Z, (parent(X, Y), parent(Y, Z), man(Z)), GS),
    write(GS), nl. 

% X и Y - бабушка и внук / внук и бабушка
grand_ma_and_son(X, Y) :- 
    (woman(X), man(Y), parent(X, Z), parent(Z, Y), !);
    (woman(Y), man(X), parent(Y, Z), parent(Z, X), !).

% Является ли X дядей Y
uncle(X, Y) :- parent(Z, Y), brother(X, Z), !.

% Вывод всех дядей X
uncle(X) :- uncle(Y, X), write(Y), nl, fail.
uncle(X).
