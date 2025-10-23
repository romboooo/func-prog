module FibTailRec

let fibTailRec digitCount =
    let rec tailRecFib n (a: bigint) (b: bigint) =
        if b.ToString().Length >= digitCount then
            n
        else
            tailRecFib (n + 1) b (a + b)

    tailRecFib 2 1I 1I
