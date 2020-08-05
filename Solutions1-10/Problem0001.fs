namespace ProjectEuler

module Problems =
    let Problem1 =
        let fizzbuzz len =
            Seq.unfold (fun state ->
                if (state >= len) then None
                else if (state % 3 = 0 || state % 5 = 0) then Some(state, state + 1)
                else Some(0, state + 1)) 0
        fizzbuzz 1000 |> Seq.sum

    let Problem1_1 =
        [ 1 .. 999 ]
        |> List.filter (fun i -> i % 5 = 0 || i % 3 = 0)
        |> List.sum
