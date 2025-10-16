module FibModuleSolution

module SequenceGenerator = 
    let generateFibonacciSequence () =
        Seq.unfold (fun (a, b, index) -> 
            Some((index, a), (b, a + b, index + 1))) (1I, 1I, 1)

module Filter = 
    let hasAtLeastNDigits n (number: bigint) =
        let logValue = bigint.Log10(number) + 1.0
        logValue >= float n

module Fold =
    let findFirst predicate sequence =
        sequence
        |> Seq.fold (fun state (index, value) ->
            match state with
            | Some _ -> state
            | None -> if predicate value then Some index else None
        ) None
        |> Option.get

module Calc =
    let findFirstFibonacciWithDigits digitCount =
        SequenceGenerator.generateFibonacciSequence ()
        
        |> Fold.findFirst (Filter.hasAtLeastNDigits digitCount)