module FibModuleSolution

module SequenceGenerator =
    let generateFibonacciSequence () =
        Seq.unfold (fun (a, b, index) -> Some((index, a), (b, a + b, index + 1))) (1I, 1I, 1)

module Filter =
    let hasAtLeastNDigits n (number: bigint) =
        let rec countDigits num count =
            if num = 0I then
                max 1 count
            else
                countDigits (num / 10I) (count + 1)

        countDigits number 0 >= n

module Fold =
    let findFirst predicate sequence =
        sequence |> Seq.find (fun (_, value) -> predicate value) |> fst

module Calc =
    let findFirstFibonacciWithDigits digitCount =
        SequenceGenerator.generateFibonacciSequence ()
        |> Fold.findFirst (Filter.hasAtLeastNDigits digitCount)
