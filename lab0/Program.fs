open System

let rec factorial n =
    if n = 1 then 1 else n * factorial (n - 1)

let k = Console.ReadLine() |> int
printfn "factorial(%d) = %d" k (factorial k)
