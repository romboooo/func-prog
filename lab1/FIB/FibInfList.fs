module FibInfList


let fibInfListCalc targetDigits =
    if targetDigits <= 1 then 1
    else
        let fibSequence = 
            (1I, 1I, 2) 
            |> Seq.unfold (fun (a, b, index) -> 
                Some((index, a), (b, a + b, index + 1)))
        
        let threshold = bigint.Pow(10I, targetDigits - 1)
        
        fibSequence
        |> Seq.find (fun (_, fibNum) -> fibNum >= threshold)
        |> fst