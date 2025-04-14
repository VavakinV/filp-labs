open System
open IPrint
open Shapes

let rect = Rectangle(4.0, 5.0)
let square = Square(3.0)
let circle = Circle(2.5)

let rectPrintable = rect :> IPrint
rectPrintable.Print()
let squarePrintable = square :> IPrint 
squarePrintable.Print()
let circlePrintable = circle :> IPrint
circlePrintable.Print()