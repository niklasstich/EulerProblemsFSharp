module ProjectEuler.Test.TestSolutions1_10

open NUnit.Framework
open NUnit.Framework
open NUnit.Framework.Internal
open ProjectEuler

[<TestFixture>]
[<Parallelizable(ParallelScope.All)>]
type TestClassSolutions() =
    
    [<Test>]
    member this.TestSolution1() =
        Assert.AreEqual(233168, Problem0001.Problem1)
        
    [<Test>]
    member this.TestSolution2() =
        Assert.AreEqual(4613732, Problem0002.Problem2)
        
    [<Test>]
    member this.TestSolution3() =
        Assert.AreEqual(6857, Problem0003.Problem3)

    [<Test>]
    member this.TestSolution4() =
        Assert.AreEqual(906609, Problem0004.Problem4)
        
    [<Test>]
    member this.TestSolution5() =
        Assert.AreEqual(232792560, Problem0005.Problem5)
        
    [<Test>]
    member this.TestSolution6() =
        Assert.AreEqual(25164150, Problem0006.Problem6)
        
    [<Test>]
    member this.TestSolution7() =
        Assert.AreEqual(104743, Problem0007.Problem7)
        
    [<Test>]
    member this.TestSolution8() =
        Assert.AreEqual(23514624000L, Problem0008.Problem8)
        
    [<Test>]
    member this.TestSolution9() =
        Assert.AreEqual(31875000, Problem0009.Problem9)
        
    [<Test>]
    member this.TestSolution10() =
        Assert.AreEqual(142913828922L, Problem0010.Problem10)