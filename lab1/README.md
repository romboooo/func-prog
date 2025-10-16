# Functional Programming lab1

**Бурейко Роман р3215**


task1:
2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder. 
What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?

task2: 


Для каждой проблемы должно быть представлено несколько решений:
-монолитные реализации с использованием:
    -хвостовой рекурсии;
    -рекурсии (вариант с хвостовой рекурсией не является примером рекурсии);
-модульной реализации, где явно разделена генерация последовательности, фильтрация и свёртка (должны использоваться функции reduce/fold, filter и аналогичные);
-генерация последовательности при помощи отображения (map);
-работа со спец. синтаксисом для циклов (где применимо);
-работа с бесконечными списками для языков, поддерживающих ленивые коллекции или итераторы как часть языка (к примеру Haskell, Clojure);
-реализация на любом удобном для вас традиционном языке программирования для сравнения.

**task1:**

*Обычная рекурсия:*

```f#
module LcmRec

let rec gcd (a:int64) (b:int64) =
    if b = 0L then a
    else gcd b (a % b)

let lcm (a: int64) (b: int64) =
    a * b / gcd a b

let rec smallestMultipleRec n: int64  =
    if n = 1 then 1
    else lcm (smallestMultipleRec (n - 1)) n
```

*Хвостовая рекурсия:*

```f#
module LcmTailRec

let gcd (a: int64) (b: int64) =
    let rec loop a b =
        if b = 0L then a
        else loop b (a % b)
    loop (abs a) (abs b)

let lcm (a: int64) (b: int64) = 
    if a = 0L || b = 0L then 0L
    else abs (a * b) / gcd a b

let smallestMultipleTailRec n =
    let rec loop current x =
        if x > n then current
        else loop (lcm current (int64 x)) (x + 1)
    loop 1L 2
```

*Модульная реализация + map*
```f#
module LcmModuleSolution

module SequenceGenerator = 
    // let generateNumbersUpTo n =[1L..int64 n]
    // let generateCandidatesFrom start = 
    //     Seq.initInfinite (fun i -> start + i)
    let generateNumbersUpTo n = 
        [1..n] |> List.map int64
    let generateCandidatesFrom start = 
        Seq.initInfinite id |> Seq.map (fun i -> int64 start + int64 i)

module Filter = 
    let isDivisibleByAll divisors number = 
        divisors |> List.forall (fun d -> number % d = 0L)

module Fold = 
    let rec gcd (a: int64) (b: int64) =
        if b = 0L then a
        else  gcd b (a % b)

    let lcm (a: int64) (b: int64) = 
        if a = 0L || b = 0L then 0L
        else abs (a * b) / gcd a b

    let foldLCM (numbers: int64 list) = 
        numbers |> List.fold lcm 1

module Solution =
    let findSmallestMultiple n =   
        let divisors = SequenceGenerator.generateNumbersUpTo n
        Fold.foldLCM divisors
```

*Бесконечные коллекции*

```f#
module LcmInfList

let rec gcd (a:int64) (b:int64) =
    if b = 0L then a
    else gcd b (a % b)


let lcm  (a:int64) (b:int64) = 
    if a = 0L || b = 0L then 0L
    else a * b / gcd a b


let smallestMultipleInfList n =
    let targetLCM = 
        {1..n} 
        |> Seq.map int64  
        |> Seq.reduce lcm
    
    Seq.initInfinite (fun i -> (int64 i + 1L) * targetLCM)
    |> Seq.head
```

*Спец. синтаксис для циклов*

```f#
module LcmSpecLoop

let rec gcd (a: int64) (b: int64) =
    if b = 0L then a
    else gcd b (a % b)

let lcm (a: int64) (b: int64) = 
    if a = 0L || b = 0L then 0L
    else abs (a * b) / gcd a b

let smallestMultipleSpecLoop n =
    let numbers = 
        seq {
            for i in 1L..n do
                yield i
        }
    numbers |> Seq.fold lcm 1L
```

python:
```python
def gcd(a,b):
    while b != 0:
        a,b = b, a % b
    return a

def lcm(a,b):
    if a == 0 or b == 0:
        return 0
    return (a * b) // gcd(a,b)

result = 1
for i in range(1,21):
    result = lcm(result,i)

print(result)
```
