module LcmInfList

let rec gcd (a: int64) (b: int64) = if b = 0L then a else gcd b (a % b)


let lcm (a: int64) (b: int64) =
    if a = 0L || b = 0L then 0L else a * b / gcd a b


let smallestMultipleInfList n =
    Seq.initInfinite (fun i -> int64 i + 1L)
    |> Seq.take n
    |> Seq.map int64
    |> Seq.reduce lcm
