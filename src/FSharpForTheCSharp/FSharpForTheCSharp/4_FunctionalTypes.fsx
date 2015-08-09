module FunctionalTypes

open System

// ============================
// Unit
// ============================
    
let sayHelloWorld () = printfn "Hello World"

let add x y =
    let result = x + y
    () // inexplicably returning unit

let add' x y =
    x + y |> ignore // inexplicably ignoring the result (ignore is a function that accepts T and returns unit)

let ignore x = ()


// ============================
// Tuples
// ============================

let point = 1, 2 // int * int
let x = fst point // get the first value
let y = snd point // get the second value

// fst and snd only work on "pairs" or tuples with only two vaues

// A tuple pattern lets you assign 
// explicit values from a tuple 
let x', y' = point

let anotherT = 1, "2", 3.0m // fst and snd won't work here.

let _, _, z = anotherT

// ============================
// Record Types
// ============================

// Simple record type
type Person =
    { FirstName : string; LastName : string }

//type Person2 = { FirstName : string; LastName : string }

let someone =
    {   FirstName = "Jeremy";
        LastName = "Abbott" }

// copy everything and update first name
let updateFirstName person firstName =
    { person with FirstName = firstName }

let updatedPerson = updateFirstName someone "John"

// Record type with a method on it
type pointRecord = { XCoord : int; YCoord : int}
                    override x.ToString() =
                        sprintf "x coord: %i; y coord: %i" x.XCoord x.YCoord
                    member x.CalculateDistance(otherCoord : pointRecord) =
                        let xDiff = otherCoord.XCoord - x.XCoord
                        let yDiff = otherCoord.YCoord - x.YCoord
                        let result =  ((xDiff * xDiff) + (yDiff * yDiff))
                        int (sqrt (float result))

// ============================
// Units of Measurement
// ============================

[<Measure>] type foot
[<Measure>] type ft = foot
[<Measure>] type sqft = foot ^ 2
[<Measure>] type meter
[<Measure>] type m = meter
[<Measure>] type mSqrd = m ^ 2

// convert from unitless to units
let measuredInFeet = 15.0 * 1.0<ft>
let unitLess = 15.0<ft> / 1.0<ft>
let squarefeet = 15.0<foot> * 16.0<foot> // note the return type ends up being <ft ^ 2> even though I defined sqft

let getArea (b : int<ft>) (h : int<ft>) : int<sqft> = b * h

// let areaInMismatch = getArea 15<m> 16<m>

let areaInSqft = getArea 15<ft> 16<ft>

let getArea' (b : int<'u>) (h : int<'u>) : int<'u ^ 2> = b * h

let areaInSomeUnits = getArea' 15<m> 16<m>

[<Measure>] type inch =
                static member perFoot = 12.0<inch/foot>

let inchesPerFoot = 3.0<foot> * inch.perFoot
    

[<Measure>] type farenheit
[<Measure>] type celsius

let fromFarenheitToCelsius (f : float<farenheit>) = ((float f - 32.0) * (5.0/9.0)) * 1.0<celsius>
let fromCelsiusToFarenheit (c : float<celsius>) = ((float c * (9.0/5.0)) + 32.0) * 1.0<farenheit>
    
// Type extensions 
type farenheit with static member toCelsius = fromFarenheitToCelsius
                    static member fromCelsius = fromCelsiusToFarenheit
    
type celsius with   static member toFarenheit = fromCelsiusToFarenheit
                    static member fromFarenheit = fromFarenheitToCelsius

let printFToC () =
    let brrr = farenheit.toCelsius 35.0<farenheit>
    printfn "%A" brrr

let printCToF () =
    let brrr = celsius.toFarenheit 4.0<celsius>
    printfn "%A" brrr
