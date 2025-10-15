open LcmTailRec
open LcmRec
open LcmModuleSolution
open System.Diagnostics
open LcmInfList

let runPythonScript (scriptPath: string) : unit =
    Process.Start("python3", scriptPath).WaitForExit() |> ignore

[<EntryPoint>]

let main argv =
    let multipleTailRecResult = smallestMultipleTailRec 20
    let multipleRecResult = smallestMultipleRec 20
    let LcmModuleSolutionResult = Solution.findSmallestMultiple 20 
    let LcmInfListResult = smallestMultipleInfList 20
    printfn "НОК (хвостовая рекурсия): %d" multipleTailRecResult
    printfn "НОК (обычная рекурсия): %d" multipleRecResult
    printfn "НОК (модульная реализация + map): %d" LcmModuleSolutionResult
    printfn "НОК (inf sec): %d" LcmInfListResult
    printfn "НОК (python): "
    runPythonScript "LCM/lcm.py" 

    0