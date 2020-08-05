namespace ProjectEuler

module Problem0010 =
    open System

    let factors n =
        let limit = int64 (Math.Sqrt(float n))
        [ 2L .. limit ] |> Seq.filter (fun i -> n % i = 0L)

    let isPrime n =
        factors n
        |> Seq.length = 0

    let primes =
        Seq.unfold (fun x -> Some(x, x + 1L)) 2L
        |> Seq.filter (fun i -> i % 2L <> 0L || i = 2L)
        |> Seq.filter isPrime

    let Problem10 =
        primes
        |> Seq.takeWhile (fun i -> i < 2000000L)
        |> Seq.sum
