namespace ProjectEuler

module Problems =
    open System.IO

    let input = File.ReadAllLines("Solutions11-20/Problem0011.txt")

    let nums =
        input
        |> Seq.map (fun line ->
            line.Split(' ')
            |> Seq.map int
            |> Seq.toArray)
        |> Seq.toArray

    let product nums = nums |> Seq.fold (fun acc n -> acc * n) 1

    let upProd x y =
        if y < 3 then
            0
        else
            product
                [ nums.[x].[y]
                  nums.[x].[y - 1]
                  nums.[x].[y - 2]
                  nums.[x].[y - 3] ]

    let leftProd x y =
        if x < 3 then
            0
        else
            product
                [ nums.[x].[y]
                  nums.[x - 1].[y]
                  nums.[x - 2].[y]
                  nums.[x - 3].[y] ]

    let leftUpProd x y =
        if x < 3 || y < 3 then
            0
        else
            product
                [ nums.[x].[y]
                  nums.[x - 1].[y - 1]
                  nums.[x - 2].[y - 2]
                  nums.[x - 3].[y - 3] ]

    let rightUpProd x y =
        if x >= 16 || y < 3 then
            0
        else
            product
                [ nums.[x].[y]
                  nums.[x + 1].[y - 1]
                  nums.[x + 2].[y - 2]
                  nums.[x + 3].[y - 3] ]

    let productsForCoord x y =
        seq {
            yield upProd x y
            yield leftProd x y
            yield leftUpProd x y
            yield rightUpProd x y
        }

    let Problem11 =
        let indexes =
            seq {
                for x in [ 0 .. 19 ] do
                    for y in [ 0 .. 19 ] do
                        yield (x, y)
            }
        indexes
        |> Seq.collect (fun (x, y) -> productsForCoord x y)
        |> Seq.max
