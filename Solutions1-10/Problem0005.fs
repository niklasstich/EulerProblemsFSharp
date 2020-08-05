namespace ProjectEuler

module Problems =
    let Problem5 =
        let divisors = [ 1 .. 20 ]
        let isEvenlyDivisible divs num =
            divs |> Seq.forall (fun x -> num % x = 0)
        let numbers = Seq.unfold (fun x -> Some(x, x + 1)) 20

        let findSmallestCommonMultiple numbers =
            //Seq.map optimizes runtime because we only need to check multiples of 20 anyway
            numbers
            |> Seq.map (fun i -> i * 20)
            |> Seq.filter (fun i -> isEvenlyDivisible divisors i)
            |> Seq.head
        numbers |> findSmallestCommonMultiple
