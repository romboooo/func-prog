module LcmRec

let rec gcd (a:int64) (b:int64) =
    if b = 0L then a
    else gcd b (a % b)

let lcm (a: int64) (b: int64) =
    a * b / gcd a b

let rec smallestMultipleRec n: int64  =
    if n = 1 then 1
    else lcm (smallestMultipleRec (n - 1)) n