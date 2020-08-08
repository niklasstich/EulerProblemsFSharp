module ProjectEuler.Test.TestSolutions11_20

open NUnit.Framework
open NUnit.Framework
open NUnit.Framework.Internal
open ProjectEuler

[<TestFixture>]
[<Parallelizable(ParallelScope.All)>]
type TestClassSolutions() =
    
    [<Test>]
    member this.TestSolution11() =
        Assert.AreEqual(70600674, Problem0011.Problem11)
        
    [<Test>]
    member this.TestSolution12() =
        Assert.AreEqual(76576500, Problem0012.Problem12)
        
    [<Test>]
    member this.TestSolution13() =
        Assert.AreEqual(5537376230L, Problem0013.Problem13)
        
    [<Test>]
    member this.TestSolution14() =
        Assert.AreEqual((524,837799), Problem0014.Problem14)
        
    [<Test>]
    member this.TestSolution15() =
        Assert.AreEqual(137846528820I, Problem0015.Problem15)
        
    [<Test>]
    member this.TestSolution16() =
        Assert.AreEqual(1366, Problem0016.Problem16)
        
    [<Test>]
    member this.TestSolution17() =
        Assert.AreEqual(21124, Problem0017.Problem17)
        
    [<Test>]
    member this.TestSolution18() =
        Assert.AreEqual(1074, Problem0018.Problem18)
        
        