namespace ProjectEuler

module Problems =
    let checkPythagoreanTriplet nums =
        match nums with
        | (a, b, c) -> a * a + b * b = c * c

    let numbers =
        seq {
            for a in [ 1 .. 1000 ] do
                for b in [ a .. 1000 ] do
                    let c = 1000 - a - b
                    if c > 0 && c > b then yield (a, b, c)
        }

    let product nums =
        let (a, b, c) = nums
        a * b * c

    let Problem9 =
        numbers
        |> Seq.filter checkPythagoreanTriplet
        |> Seq.head
        |> product
