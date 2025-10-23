module LcmModuleSolution

module SequenceGenerator =
    // let generateNumbersUpTo n =[1L..int64 n]
    // let generateCandidatesFrom start =
    //     Seq.initInfinite (fun i -> start + i)
    let generateNumbersUpTo n = [ 1..n ] |> List.map int64

    let generateCandidatesFrom start =
        Seq.initInfinite id |> Seq.map (fun i -> int64 start + int64 i)

module Filter =
    let isDivisibleByAll divisors number =
        divisors |> List.forall (fun d -> number % d = 0L)

module Fold =
    let rec gcd (a: int64) (b: int64) = if b = 0L then a else gcd b (a % b)

    let lcm (a: int64) (b: int64) =
        if a = 0L || b = 0L then 0L else abs (a * b) / gcd a b

    let foldLCM (numbers: int64 list) = numbers |> List.fold lcm 1

module Solution =
    let findSmallestMultiple n =
        let divisors = SequenceGenerator.generateNumbersUpTo n
        Fold.foldLCM divisors
