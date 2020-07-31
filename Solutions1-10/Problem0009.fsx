let checkPythagoreanTriplet nums =
    match  nums with
    | (a,b,c) -> a*a + b*b = c*c

let numbers =
    seq {
        for a in [ 1 .. 1000 ] do
            for b in [ a .. 1000 ] do
                for c in [ b .. 1000 ] do
                    if a + b + c = 1000 then yield (a, b, c)
    }
let product nums =
    let (a,b,c) = nums
    a*b*c

let Problem9 =
    numbers |> Seq.filter checkPythagoreanTriplet |> Seq.head |> product