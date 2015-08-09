module PatternMatching


// *********************************
// Basic expression pattern matching
// *********************************
let printMatchedExpression result =
    printfn "%s" result

// Default pattern matching syntax
let getCodeValue code =
    match code with
        | "A" -> "Awesome"
        | "B" -> "Best"
        | "C" -> "Common"
        | _ -> "Unknown Code Type" // Wild card pattern

    
// Short hand pattern matching syntax
let getCodeValue' =
    function
        | "A" -> "Awesome"
        | "B" -> "Best"
        | "C" -> "Common"
        | _ -> "Unknown Code Type" // Wild card pattern

// Short hand pattern matching syntax
let getCodeValue'' =
    function
        | "A" -> "Awesome"
        | "B" -> "Best"
        | "C" -> "Common"
        | c -> sprintf "Code: %s was input, but does not have a known value" c // Wild card pattern

let printBasicPatternMatchingExample () = 
    printMatchedExpression (getCodeValue "A")
    printMatchedExpression (getCodeValue "Z")

    printMatchedExpression (getCodeValue' "A")
    printMatchedExpression (getCodeValue' "Z")

    printMatchedExpression (getCodeValue'' "A")
    printMatchedExpression (getCodeValue'' "Z")

// *********************************
// Pattern matching against a tuple
// *********************************
let points = [0, 0; 1, 0; 0, 1; -2, 3] 
let locatePoint p =
    match p with
    | (0, 0) -> sprintf "%A is at the origin" p
    | (x, 0) when x >= 1  -> sprintf "%A is on the x-axis" p
    | (0, _) -> sprintf "%A is on the y-axis" p
    | (x, y) -> sprintf "%A is at x: %i, y: %i" p x y
    
let printTuplePatternMatchingExample () =
    points |> List.map locatePoint |> List.iter (fun s -> printfn "%s" s)

// *********************************
// Pattern matching against Record Types
// *********************************
type Model =
    | Six
    | SixPlus
    | Five
    | FiveS
type Phone = { Manufacturer : string; Model : Model; OperatingSystem : string; Storage : int }
let phones = [{ Manufacturer = "Apple"; Model = Model.Six; OperatingSystem = "iOS"; Storage = 64 };
                { Manufacturer = "Apple"; Model = Model.Six; OperatingSystem = "iOS"; Storage = 128 };
                { Manufacturer = "Apple"; Model = Model.SixPlus; OperatingSystem = "iOS"; Storage = 64 };
                { Manufacturer = "Apple"; Model = Model.Five; OperatingSystem = "iOS"; Storage = 64 }]
let isNewEnough =
    function
    | { Model = Model.SixPlus } -> true
    | { Model = Model.Six } -> true
    | _ -> false
let printRecordTypePatternMatching () =
    phones
    |> List.filter isNewEnough
    |> List.iter
        (fun p -> printfn "This phone is new enough - Manufacturer: %s, Storage: %i" p.Manufacturer p.Storage)    