namespace ProjectEuler



module Problem0020 = 
    
    open System.Numerics
    let factorial (n:BigInteger) = [1I .. n] |> Seq.reduce(fun acc n -> acc*n)

    let Problem20 =
        (factorial 100I).ToString() |> Seq.map(fun c -> System.Int32.Parse (string c)) |> Seq.reduce(fun acc n -> acc + n)