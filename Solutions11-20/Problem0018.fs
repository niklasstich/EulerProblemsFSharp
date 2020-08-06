namespace ProjectEuler

open System.IO

module Problem0018 =
    let numbers =
        File.ReadAllLines("Solutions11-20/Problem0018.txt")
        |> Seq.map(fun s -> s.Split(" ") |> Seq.map int |> Seq.toList)
        |> Seq.toList
    
    