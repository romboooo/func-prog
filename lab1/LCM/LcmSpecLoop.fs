module LcmSpecLoop

let rec gcd (a: int64) (b: int64) =
    if b = 0L then a
    else gcd b (a % b)

let lcm (a: int64) (b: int64) = 
    if a = 0L || b = 0L then 0L
    else abs (a * b) / gcd a b