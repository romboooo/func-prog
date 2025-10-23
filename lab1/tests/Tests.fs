module Tests

open Xunit
open System

// ========== Fibonacci Tests ==========
module FibTestData =
    let testCases = [
        (1, 1)
        (2, 7)
        (3, 12)
        (10, 45)
    ]

type FibRecTests() =
    
    [<Fact>]
    member _.``FibRec with 1 digit returns 1``() =
        let result = FibRec.fibRec 1
        Assert.Equal(1, result)
    
    [<Fact>]
    member _.``FibRec with 2 digits returns 7``() =
        let result = FibRec.fibRec 2
        Assert.Equal(7, result)
    
    [<Fact>]
    member _.``FibRec with 3 digits returns 12``() =
        let result = FibRec.fibRec 3
        Assert.Equal(12, result)

type FibTailRecTests() =
    
    [<Fact>]
    member _.``FibTailRec with 1 digit returns 2``() =
        let result = FibTailRec.fibTailRec 1
        Assert.Equal(2, result)
    
    [<Fact>]
    member _.``FibTailRec with 2 digits returns 7``() =
        let result = FibTailRec.fibTailRec 2
        Assert.Equal(7, result)
    
    [<Fact>]
    member _.``FibTailRec with 3 digits returns 12``() =
        let result = FibTailRec.fibTailRec 3
        Assert.Equal(12, result)

type FibInfListTests() =
    
    [<Fact>]
    member _.``FibInfList with 1 digit returns 1``() =
        let result = FibInfList.fibInfListCalc 1
        Assert.Equal(1, result)
    
    [<Fact>]
    member _.``FibInfList with 2 digits returns 7``() =
        let result = FibInfList.fibInfListCalc 2
        Assert.Equal(7, result)

type FibMapTests() =
    
    [<Fact>]
    member _.``FibMap with 1 digit returns 1``() =
        let result = FibMap.fibMapCalc 1
        Assert.Equal(1, result)
    
    [<Fact>]
    member _.``FibMap with 2 digits returns 7``() =
        let result = FibMap.fibMapCalc 2
        Assert.Equal(7, result)

type FibModuleSolutionTests() =
    
    [<Fact>]
    member _.``FibModuleSolution with 1 digit returns 1``() =
        let result = FibModuleSolution.Calc.findFirstFibonacciWithDigits 1
        Assert.Equal(1, result)
    
    [<Fact>]
    member _.``FibModuleSolution with 2 digits returns 7``() =
        let result = FibModuleSolution.Calc.findFirstFibonacciWithDigits 2
        Assert.Equal(7, result)

// ========== LCM Tests ==========
module LCMTestData =
    let testCases = [
        (1, 1L)
        (5, 60L)
        (10, 2520L)
    ]

type LcmRecTests() =
    
    [<Fact>]
    member _.``LcmRec with n=1 returns 1``() =
        let result = LcmRec.smallestMultipleRec 1
        Assert.Equal(1L, result)
    
    [<Fact>]
    member _.``LcmRec with n=5 returns 60``() =
        let result = LcmRec.smallestMultipleRec 5
        Assert.Equal(60L, result)
    
    [<Fact>]
    member _.``LcmRec with n=10 returns 2520``() =
        let result = LcmRec.smallestMultipleRec 10
        Assert.Equal(2520L, result)

type LcmTailRecTests() =
    
    [<Fact>]
    member _.``LcmTailRec with n=1 returns 1``() =
        let result = LcmTailRec.smallestMultipleTailRec 1
        Assert.Equal(1L, result)
    
    [<Fact>]
    member _.``LcmTailRec with n=5 returns 60``() =
        let result = LcmTailRec.smallestMultipleTailRec 5
        Assert.Equal(60L, result)

type LcmInfListTests() =
    
    [<Fact>]
    member _.``LcmInfList with n=5 returns 60``() =
        let result = LcmInfList.smallestMultipleInfList 5
        Assert.Equal(60L, result)
    
    [<Fact>]
    member _.``LcmInfList with n=10 returns 2520``() =
        let result = LcmInfList.smallestMultipleInfList 10
        Assert.Equal(2520L, result)

type LcmModuleSolutionTests() =
    
    [<Fact>]
    member _.``LcmModuleSolution with n=5 returns 60``() =
        let result = LcmModuleSolution.Solution.findSmallestMultiple 5
        Assert.Equal(60L, result)
    
    [<Fact>]
    member _.``LcmModuleSolution with n=10 returns 2520``() =
        let result = LcmModuleSolution.Solution.findSmallestMultiple 10
        Assert.Equal(2520L, result)

type LcmSpecLoopTests() =
    
    [<Fact>]
    member _.``LcmSpecLoop with n=5 returns 60``() =
        let result = LcmSpecLoop.smallestMultipleSpecLoop 5
        Assert.Equal(60L, result)
    
    [<Fact>]
    member _.``LcmSpecLoop with n=10 returns 2520``() =
        let result = LcmSpecLoop.smallestMultipleSpecLoop 10
        Assert.Equal(2520L, result)

// ========== Consistency Tests ==========
type ConsistencyTests() =
    
    [<Fact>]
    member _.``All Fibonacci implementations return same result for 3 digits``() =
        let expected = 12
        Assert.Equal(expected, FibRec.fibRec 3)
        Assert.Equal(expected, FibTailRec.fibTailRec 3)
        Assert.Equal(expected, FibInfList.fibInfListCalc 3)
        Assert.Equal(expected, FibMap.fibMapCalc 3)
        Assert.Equal(expected, FibModuleSolution.Calc.findFirstFibonacciWithDigits 3)
    
    [<Fact>]
    member _.``All LCM implementations return same result for n=10``() =
        let expected = 2520L
        Assert.Equal(expected, LcmRec.smallestMultipleRec 10)
        Assert.Equal(expected, LcmTailRec.smallestMultipleTailRec 10)
        Assert.Equal(expected, LcmInfList.smallestMultipleInfList 10)
        Assert.Equal(expected, LcmModuleSolution.Solution.findSmallestMultiple 10)
        Assert.Equal(expected, LcmSpecLoop.smallestMultipleSpecLoop 10)
