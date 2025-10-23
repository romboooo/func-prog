# Functional Programming lab1

## Бурейко Роман р3315


# task1:
2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder. 
What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?

# task2: 

The Fibonacci sequence is defined by the recurrence relation:

Fₙ = Fₙ₋₁ + Fₙ₋₂, where F₁ = 1 and F₂ = 1

# First 12 terms:

| Term | Value |
|------|-------|
| F₁   | 1     |
| F₂   | 1     |
| F₃   | 2     |
| F₄   | 3     |
| F₅   | 5     |
| F₆   | 8     |
| F₇   | 13    |
| F₈   | 21    |
| F₉   | 34    |
| F₁₀  | 55    |
| F₁₁  | 89    |
| F₁₂  | 144   |

The 12th term (**F₁₂ = 144**) is the first term to contain **three digits**.

**What is the index of the first term in the Fibonacci sequence to contain 1000 digits?**

## Требования
Для каждой проблемы должно быть представлено несколько решений:

-монолитные реализации с использованием:
    -хвостовой рекурсии;
    -рекурсии (вариант с хвостовой рекурсией не является примером рекурсии);

-модульной реализации, где явно разделена генерация последовательности, фильтрация и свёртка (должны использоваться функции reduce/fold, filter и аналогичные);

-генерация последовательности при помощи отображения (map);

-работа со спец. синтаксисом для циклов (где применимо);

-работа с бесконечными списками для языков, поддерживающих ленивые коллекции или итераторы как часть языка (к примеру Haskell, Clojure);

-реализация на любом удобном для вас традиционном языке программирования для сравнения.

# task1:

*Обычная рекурсия:*

```f#
module LcmRec

let rec gcd (a: int64) (b: int64) = if b = 0L then a else gcd b (a % b)

let lcm (a: int64) (b: int64) = a * b / gcd a b

let rec smallestMultipleRec n : int64 =
    if n = 1 then 1 else lcm (smallestMultipleRec (n - 1)) n
```

*Хвостовая рекурсия:*

```f#
module LcmTailRec

let gcd (a: int64) (b: int64) =
    let rec loop a b = if b = 0L then a else loop b (a % b)
    loop (abs a) (abs b)

let lcm (a: int64) (b: int64) =
    if a = 0L || b = 0L then 0L else abs (a * b) / gcd a b

let smallestMultipleTailRec n =
    let rec loop current x =
        if x > n then
            current
        else
            loop (lcm current (int64 x)) (x + 1)

    loop 1L 2
```

*Модульная реализация + map*
```f#
module LcmModuleSolution

module SequenceGenerator =
    // let generateNumbersUpTo n =[1L..int64 n]
    // let generateCandidatesFrom start =
    //     Seq.initInfinite (fun i -> start + i)
    let generateNumbersUpTo n = [ 1..n ] |> List.map int64

    let generateCandidatesFrom start =
        Seq.initInfinite id |> Seq.map (fun i -> int64 start + int64 i)

module Filter =
    let isDivisibleByAll divisors number =
        divisors |> List.forall (fun d -> number % d = 0L)

module Fold =
    let rec gcd (a: int64) (b: int64) = if b = 0L then a else gcd b (a % b)

    let lcm (a: int64) (b: int64) =
        if a = 0L || b = 0L then 0L else abs (a * b) / gcd a b

    let foldLCM (numbers: int64 list) = numbers |> List.fold lcm 1

module Solution =
    let findSmallestMultiple n =
        let divisors = SequenceGenerator.generateNumbersUpTo n
        Fold.foldLCM divisors
```

*Бесконечные коллекции*

```f#
module LcmInfList

let rec gcd (a: int64) (b: int64) = if b = 0L then a else gcd b (a % b)


let lcm (a: int64) (b: int64) =
    if a = 0L || b = 0L then 0L else a * b / gcd a b


let smallestMultipleInfList n =
    Seq.initInfinite (fun i -> int64 i + 1L)
    |> Seq.take n
    |> Seq.map int64
    |> Seq.reduce lcm
```

*Спец. синтаксис для циклов*

```f#
module LcmSpecLoop

let rec gcd (a: int64) (b: int64) = if b = 0L then a else gcd b (a % b)

let lcm (a: int64) (b: int64) =
    if a = 0L || b = 0L then 0L else abs (a * b) / gcd a b

let smallestMultipleSpecLoop n =
    let numbers =
        seq {
            for i in 1L .. n do
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

# task2:

*Обычная рекурсия:*

```f#
module FibRec
open System

let fibRec targetDigits =
    if targetDigits <= 1 then
        1
    else
        let limit = bigint.Pow(10I, targetDigits - 1)

        let rec loop a b index =
            if a >= limit then index else loop (a + b) a (index + 1)

        loop 1I 1I 2
```

*Хвостовая рекурсия:*

```f#
module FibTailRec

let fibTailRec digitCount =
    let rec tailRecFib n (a: bigint) (b: bigint) =
        if b.ToString().Length >= digitCount then
            n
        else
            tailRecFib (n + 1) b (a + b)
    tailRecFib 2 1I 1I
```

*Бесконечные коллекции*
```f#
module FibInfList

let fibInfListCalc targetDigits =
    if targetDigits <= 1 then
        1
    else
        let fibSequence =
            (1I, 1I, 2)
            |> Seq.unfold (fun (prev, curr, index) -> Some((index, curr), (curr, prev + curr, index + 1)))

        let threshold = bigint.Pow(10I, targetDigits - 1)

        fibSequence |> Seq.find (fun (_, fibNum) -> fibNum >= threshold) |> fst
```

*Map*

```f#
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
```

*Модульное решение*

```f#
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
```


## Вывод:

После решения лабораторной работы 1, я ощутил базовое погружение в ФП и особенности языка f#. Поработал с такими базовыми вещами как хвостовая рекурсия и бесконечные коллекции, которые значительно расширили кругозор и оставили яркий след в моем сердце 
