module DiscriminatedUnions


// This compiles down to an enumeration
type Color =
| Red = 0
| Blue = 1
| Green = 2

printfn "%i" (int Color.Red)

// note that named union type fields is part of F# 3.1
// prior to this named union types used tuple syntax

// This compiles down to an abstract class with 
// three inner classes inheriting from it
type Shape =
| Circle of Radius : float
| Triangle of Base : float * Height : float
| Rectangle of Length : float * Height : float
    member x.getArea () = 
        match x with // pattern matching
        | Circle (r) -> (r ** 2.0) * System.Math.PI 
        | Triangle (b, h) -> 0.5 * (b * h)
        | Rectangle (l, h) -> l * h


let demoShape () =

    printfn "%s" "Discriminated Union (Shape) Info:"
        
    let circle = Shape.Circle(4.0)
    printfn "%A" (circle.getArea())

    let triangle = Shape.Triangle(3.0, 4.0)
    printfn "%A" (triangle.getArea())

    let rectangle = Shape.Rectangle(3.0, 4.0)
    printfn "%A" (rectangle.getArea())