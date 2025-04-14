module ShapesDiscriminated

open System
open IPrint

type Shape =
    | Rectangle of width: float * height: float
    | Square of side: float
    | Circle of radius: float
    member this.GetArea() =
        match this with
        | Rectangle(w, h) -> w * h
        | Square(s) -> s * s
        | Circle(r) -> Math.PI * r * r

    override this.ToString() =
        match this with
        | Rectangle(w, h) -> 
            $"Rectangle((width = {w}, height = {h}), area = {this.GetArea()})"
        | Square(s) ->
            $"Square((side = {s}), area = {this.GetArea()})"
        | Circle(r) ->
            $"Circle((radius = {r}), area = {this.GetArea()})"

    interface IPrint with
        member this.Print() =
            match this with
            | Rectangle(w, h) -> 
                Console.WriteLine(this.ToString())
            | Square(s) ->
                Console.WriteLine(this.ToString())
            | Circle(r) ->
                Console.WriteLine(this.ToString())