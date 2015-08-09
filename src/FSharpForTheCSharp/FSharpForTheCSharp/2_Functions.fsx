module Functions

open System

// f(x) = x + 2
let add2 x = x + 2

// Same function as above but with type annoations
// Why is it add2' ("add two prime")?
// Functions are values and are immutable (so no function overloading.
let add2' (x : int) int = x + 2

// Another function
// Mouse over function name to see that it
// b:float -> e:float -> float
// Compiler infers that inputs are floats since they're passed to a method that accepts floats
let power b e = Math.Pow(b, e)

// Type annotated version of power
let power' (b : float) (e : float)  float = Math.Pow(b, e)
