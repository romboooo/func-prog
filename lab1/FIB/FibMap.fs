module FibMap

let fibMapCalc targetDigits =
    if targetDigits <= 1 then
        1
    else
        let threshold = bigint.Pow(10I, targetDigits - 1)

        (0I, 1I, 1)
        |> Seq.unfold (fun (a, b, index) -> Some((index, b), (b, a + b, index + 1)))
        |> Seq.map (fun (index, fibNum) -> (index, fibNum, fibNum >= threshold))
        |> Seq.find (fun (_, _, isLargeEnough) -> isLargeEnough)
        |> fun (index, _, _) -> index
