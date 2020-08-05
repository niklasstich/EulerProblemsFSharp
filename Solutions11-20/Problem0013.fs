namespace ProjectEuler

module Problem0013 =

    open System.IO
    open System.Numerics

    let Problem13 =
        let sum =
            File.ReadAllLines("Solutions11-20/Problem0013.txt")
            |> Seq.map (fun i -> BigInteger.Parse i)
            |> Seq.sum
        sum.ToString().ToCharArray()
        |> Seq.take 10
        |> Seq.toList
