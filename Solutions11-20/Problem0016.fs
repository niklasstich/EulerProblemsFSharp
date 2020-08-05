//Sum digits of 2^1000

namespace ProjectEuler

module Problems =

    open System.Numerics

    let Problem16 =
        let factor = pown (2I) 1000
        factor.ToString()
        |> Seq.map (fun i -> int (i.ToString()))
        |> Seq.sum
