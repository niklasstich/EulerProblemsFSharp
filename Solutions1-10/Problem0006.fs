namespace ProjectEuler

module Problem0006 =
    let sumOfSquares (numbers) =
        numbers
        |> Seq.map (fun i -> i * i)
        |> Seq.sum

    let squareOfSum (numbers) =
        let sum = numbers |> Seq.sum
        sum * sum

    let Problem6 =
        let numbers = [ 1 .. 100 ]
        squareOfSum numbers - sumOfSquares numbers
