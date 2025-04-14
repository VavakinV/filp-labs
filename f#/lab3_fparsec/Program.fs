open System
open FParsec

type Expr =
    | Number of int
    | Add of Expr * Expr
    | Subtract of Expr * Expr

let numberParser : Parser<Expr, unit> =
    pint32 |>> Number

let exprParser, exprParserRef = createParserForwardedToRef()

let addSubtractParser =
    let opp = OperatorPrecedenceParser<Expr, unit, unit>()
    let expr = opp.ExpressionParser
    opp.TermParser <- numberParser <|> between (pchar '(') (pchar ')') exprParser
    opp.AddOperator(InfixOperator("+", spaces, 1, Associativity.Left, fun x y -> Add(x, y)))
    opp.AddOperator(InfixOperator("-", spaces, 1, Associativity.Left, fun x y -> Subtract(x, y)))
    expr

exprParserRef.Value <- addSubtractParser

let parseString str =
    match run exprParser str with
    | Success(result, _, _) -> result
    | Failure(errorMsg, _, _) -> failwith errorMsg

let printResult expr =
    let rec exprToString = function
        | Number n -> n.ToString()
        | Add (e1, e2) -> $"({exprToString e1} + {exprToString e2})"
        | Subtract (e1, e2) -> $"({exprToString e1} - {exprToString e2})"
    
    let resultString = exprToString expr
    Console.WriteLine($"Parsed expression: {resultString}")


let input = "3+4-(1+8)-(5+6)"
Console.WriteLine($"Input string: {input}")
let parsed = parseString input
printResult parsed