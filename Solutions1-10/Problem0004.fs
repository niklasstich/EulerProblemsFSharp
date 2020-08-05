namespace ProjectEuler

module Problem0004 =
    open System.Linq

    let Problem4 =
        let palindrome (n: int) =
            let chararray = n.ToString().ToCharArray()
            Array.rev chararray |> chararray.SequenceEqual

        let nums = [ 100 .. 999 ]
        let products = nums |> List.collect (fun x -> nums |> List.map (fun y -> x * y))
        products
        |> Seq.filter palindrome
        |> Seq.max
