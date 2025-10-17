open LcmTailRec
open LcmRec
open LcmModuleSolution
open System.Diagnostics
open LcmInfList
open FibRec
open LcmSpecLoop
open FibTailRec
open FibModuleSolution
open FibInfList

let runPythonScript (scriptPath: string) : unit =
    Process.Start("python3", scriptPath).WaitForExit() |> ignore

[<EntryPoint>]

let main argv =
    let multipleRecResult = smallestMultipleRec 20
    printfn "НОК (обычная рекурсия): %d" multipleRecResult

    let multipleTailRecResult = smallestMultipleTailRec 20
    printfn "НОК (хвостовая рекурсия): %d" multipleTailRecResult

    let LcmModuleSolutionResult = Solution.findSmallestMultiple 20 
    printfn "НОК (модульная реализация + map): %d" LcmModuleSolutionResult

    let LcmInfListResult = smallestMultipleInfList 20
    printfn "НОК (inf seq): %d" LcmInfListResult

    let LcmSpecLoopResult = smallestMultipleSpecLoop 20
    printfn "НОК (cпец синтаксис для циклов): %d" LcmSpecLoopResult

    printfn "НОК (python): "
    runPythonScript "LCM/lcm.py" 

    let fibRecResult = fibRec 1000
    printfn "Фибоначчи (обычная рекурсия): %d" fibRecResult

    let fibTailRecResult = fibTailRec 1000
    printfn "Фибоначчи (хвостовая рекурсия): %A" fibTailRecResult

    let FibInfListResult = fibInfListCalc 1000
    printfn "Фибоначчи (inf seq): %A" FibInfListResult

    // let FibModuleSolutionResult = Calc.findFirstFibonacciWithDigits 1000
    // printfn "Фибоначчи (модульная реализация + map): %A" FibModuleSolutionResult

    printfn "Фибоначчи (python): "
    runPythonScript "FIB/fib.py"

    0