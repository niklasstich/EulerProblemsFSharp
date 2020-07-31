open System
open System.IO

let product nums = nums |> Seq.fold (fun accumulator num -> accumulator * num) 1L
let Problem8 =
    let input = File.ReadAllText "Solutions1-10/Problem0008.txt" |> Seq.toList |> Seq.map(fun i -> int64(string(i)))
    input |> Seq.windowed 13 |> Seq.map(fun i -> product i) |> Seq.max