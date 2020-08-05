namespace ProjectEuler

module Problem0003 =
    open System

    let Problem3 =
        let findFactors (n: int64) =
            let limit = Math.Sqrt(double (n)) |> int64
            [ 2L .. limit ] |> Seq.filter (fun i -> n % i = 0L)

        let isPrime (n: int64) =
            findFactors (n)
            |> Seq.length = 0

        let findMaxPrimeFactor (n: int64) =
            findFactors (n)
            |> Seq.filter isPrime
            |> Seq.max
        findMaxPrimeFactor 600851475143L
