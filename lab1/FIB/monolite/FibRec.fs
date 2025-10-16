module FibRec 

open System

let fibRec targetDigits =
    if targetDigits <= 1 then 1
    else
        let limit = bigint.Pow(10I, targetDigits - 1)
        let rec loop a b index =
            if a >= limit then index
            else loop (a + b) a (index + 1)
        loop 1I 1I 2
