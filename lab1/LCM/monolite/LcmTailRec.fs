module LcmTailRec

let gcd (a: int64) (b: int64) =
    let rec loop a b =
        if b = 0L then a
        else loop b (a % b)
    loop (abs a) (abs b)

let lcm (a: int64) (b: int64) = 
    if a = 0L || b = 0L then 0L
    else abs (a * b) / gcd a b

let smallestMultipleTailRec n =
    let rec loop current x =
        if x > n then current
        else loop (lcm current (int64 x)) (x + 1)
    loop 1L 2