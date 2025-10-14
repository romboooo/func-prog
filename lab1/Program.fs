open LcmTailRec
open LcmRec
open LcmModuleSolution

[<EntryPoint>]
let main argv =
    let multipleTailRecResult = smallestMultipleTailRec 20
    let multipleRecResult = smallestMultipleRec 20
    let LcmModuleSolutionResult = Solution.findSmallestMultiple 20 
    printfn "Наименьшее число (хвостовая рекурсия): %d" multipleTailRecResult
    printfn "Наименьшее число (обычная рекурсия): %d" multipleRecResult
    printfn "Наименьшее число (модульная реализация): %d" LcmModuleSolutionResult
    0