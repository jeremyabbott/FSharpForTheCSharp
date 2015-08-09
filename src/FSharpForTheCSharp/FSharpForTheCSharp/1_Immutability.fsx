module Immutability
// Bind the value 2 to the name "x"
let x = 2 // value x : int = 2
x = 3 // val it : bool = false
x = 2 // val it : bool = true
    
// The "equal" sign is used for bindings and for comparison
// Make something mutable
let mutable y = 2
y = 2 // val it : bool = true
y = 3 // val it : bool = false
y <- 3 // This is how you assign a value to a mutable binding
y = 3 // val it : bool = true
    
// What happens if I try to assign a new value to x?
// x <- 3 // UNCOMMENT THIS

// The empty parentheses indicate that this function accepts unit
let buildAList () =
    let rand = System.Random()
    // init expects a count for size
    // and an initilization function
    // 
    List.init 10 (fun _ -> rand.Next(100))

// mapAList partially applies the map function
// map function accepts a function and a list
let mapAList =
    List.map (fun i -> i * i)


// printAList partial applies the
// iter function from the List module
// iter accepts a function and a list
let printAList =
    List.iter (fun i -> printfn "%i" i) 

let myList = buildAList()

// Forward pipelining
// Forwards the result of a function to the last argument of another function.
myList |> printAList
myList |> mapAList |> printAList

// Functional Composition
let printMappedList = mapAList >> printAList

printMappedList (buildAList())