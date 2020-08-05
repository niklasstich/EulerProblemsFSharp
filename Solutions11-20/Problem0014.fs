namespace ProjectEuler

module Problems =
    let next n =
        if n % 2L = 0L then n / 2L else 3L * n + 1L

    let findSequenceLengthOfCollatz n =
        Seq.unfold (fun x ->
            if x = 1L then None else Some(x, next x)) n
        |> Seq.length

    let Problem14 =
        let nums = [ 1L .. 999999L ]
        nums
        |> Seq.map (fun i -> (findSequenceLengthOfCollatz i, i))
        |> Seq.maxBy (fun (length, _startnum) -> length)
