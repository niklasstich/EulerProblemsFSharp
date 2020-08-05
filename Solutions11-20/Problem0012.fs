namespace ProjectEuler

module Problem0012 =
    open System

    let triangleNumber n =
        [ 1L .. n ] |> Seq.sum

    let getFactors n =
        let limit =
            double n
            |> Math.Sqrt
            |> int64
        [ 1L .. limit ]
        |> Seq.filter (fun i -> n % i = 0L)
        |> Seq.collect (fun i ->
            [ i
              n / i ])

    let naturalNumbers: seq<int64> = Seq.unfold (fun i -> Some(i, i + 1L)) 1L

    let Problem12 =
        naturalNumbers
        |> Seq.map (fun i -> triangleNumber i)
        |> Seq.filter (fun i ->
            getFactors i
            |> Seq.length
            >= 500)
        |> Seq.head
