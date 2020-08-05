namespace ProjectEuler

module Problems =
    open System

    let factors n =
        let limit = int (Math.Sqrt(float n))
        [ 2 .. limit ] |> Seq.filter (fun i -> n % i = 0)

    let isPrime n =
        factors n
        |> Seq.length = 0

    let Problem6 =
        //filter all numbers divisible by 2 (except 2 itself because it is indeed prime) for performance reasons
        let primes =
            Seq.unfold (fun x -> Some(x, x + 1)) 2
            |> Seq.filter (fun i -> i % 2 <> 0 || i = 2)
            |> Seq.filter isPrime
        primes |> Seq.item 10000
