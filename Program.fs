// Learn more about F# at http://fsharp.org
open System
open System.Linq
let Problem1 =
    let fizzbuzz len =
        0
        |> Seq.unfold (fun state ->
            if (state >= len) then None
            else if (state % 3 = 0 || state % 5 = 0) then Some(state, state + 1)
            else Some(0, state + 1))
    fizzbuzz 1000 |> Seq.sum

let Problem1_1 =
    [ 1 .. 999 ]
    |> List.filter (fun i -> i % 5 = 0 || i % 3 = 0)
    |> List.sum

let Problem2 =
    let fibonacciSeq = Seq.unfold (fun (current, next) -> Some(current, (next, current + next))) (0, 1)
    fibonacciSeq
    |> Seq.takeWhile (fun n -> n < 4000000)
    |> Seq.filter (fun n -> n % 2 = 0)
    |> Seq.sum

let Problem3 =
    let findFactors(n:int64) =
        let limit = Math.Sqrt(double(n)) |> int64
        [2L..limit] |> Seq.filter(fun i -> n%i=0L)
    
    let isPrime(n:int64) = findFactors(n) |> Seq.length = 0
    
    let findMaxPrimeFactor(n:int64) =
        findFactors(n)
        |> Seq.filter isPrime
        |> Seq.max
    findMaxPrimeFactor 600851475143L
        
let Problem4 =
    let palindrome(n:int) =
        let chararray = n.ToString().ToCharArray()
        Array.rev chararray |> chararray.SequenceEqual 
    let nums = [100..999]
    let products = nums |> List.collect (fun x -> nums |> List.map (fun y -> x*y))
    products |> Seq.filter palindrome |> Seq.max
    
let Problem5 =
    let divisors = [1 .. 20]
    let isEvenlyDivisible divs num =
        divs |> Seq.forall(fun x -> num%x=0)
    let numbers = Seq.unfold (fun x->Some(x, x+1)) 20
    let findSmallestCommonMultiple numbers =
        numbers |> Seq.filter (fun i -> isEvenlyDivisible divisors i) |> Seq.head
    numbers |> findSmallestCommonMultiple
    
    
    
    
[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    Console.Write Problem2
    0 // return an integer exit code
