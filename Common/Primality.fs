namespace ProjectEuler.Common
module Primality =
    //We do a Miller Rabin test, borrowed from http://www.fssnip.net/2w/title/MillerRabin-primality-test
    open System
    open System.Numerics
    
    
    //Accepts a function that does multiply modulo and another function that does square modulo
    //as well as two numbers. Returns the result of the power modulo the m that was provided when creating the mul and sq functions
    let pow' mul sq x' n' =
        let rec f x n y =
            if n = 1I then
                mul x y
            else
                let (q,r) = BigInteger.DivRem(n, 2I)
                let x2 = sq x
                if r = 0I then
                    f x2 q y
                else
                    f x2 q (mul x y)
        f x' n' 1I
        
    
    //multiplies a and b and returns the result modulo m
    let multiplyMod (m:BigInteger) a b = (a*b)%m
    //squares a and returns the result modulo m
    let squareMod (m:BigInteger) a = (a*a)%m
    //Accepts a BigInt and returns a function that takes two numbers and returns the result modulo the BigInt that was specified
    let powerMod m = pow' (multiplyMod m) (squareMod m)
    //Takes a function f and returns a function that takes an initializer and gives a sequence where f is applied over and over
    let iterate f = Seq.unfold(fun x -> let fx = f x in Some(x,fx))
    
    //Tests if a is probable prime for the witness n
    let millerRabinPrimality n a =
        //For a given n, finds k and m so that 2^k*m=n
        let find2km n =
            let rec findInner k m =
                let (q,r) = BigInteger.DivRem(m, 2I)
                if r = 1I then
                    (k, m)
                else
                    findInner (k+1I) q
            findInner 0I n
        //new n is -1
        let n' = n - 1I
        //Function that takes a sequence and returns the first occurence where x is either 1 or n'
        let iter = Seq.tryPick(fun x -> if x = 1I then Some(false) elif x = n' then Some(true) else None)
        //For n', find k and m so that n' can be represented as 2^k*m = n'
        let (k,m) = find2km n'
        //b0 = a^m%n
        let b0 = powerMod n a m
        
        match (a,n) with
            | _ when a <= 1I && a >= n' -> //if a is seq than 1 and geq than n-1, we have to fail because a is not a valid witness for n 
                failwith (sprintf "Miller-Rabin primality: a is not a valid witness for n (%A for %A)" a n)
            | _ when b0 = 1I || b0 = n' -> true //if a^m%n is 1 or n-1, then n is probable prime for a
            | _ -> b0 //if that was not the case, we have to take the remainder of that modulo operation
                    |> iterate (squareMod n) //make a sequence of squareMod with n as modulo and with b0 as initializer 
                    |> Seq.take(int k) //take k elements
                    |> Seq.skip 1 //skip the first element
                    |> iter //apply iter (see above) which gives us the first element that it matches
                    |> Option.exists id //and return the result (false if x is 1, true if x is n-1)
                    
     
    //Takes a sequence of witnesses (should be random from [2 .. n-2]) and returns a function that checks if n is probable prime
    let isPrimeW witnesses = function
        | n when n < 2I -> false
        | n when n = 2I -> true
        | n when n = 3I -> true
        | n when n % 2I = 0I -> false
        | n -> witnesses |> Seq.forall(millerRabinPrimality n)
    
    let generateRandomBigInt (lowerLimit:BigInteger, upperLimit:BigInteger):BigInteger =
        let mutable res = 0I
        let mutable loop = true
        let rand = Random()
        while loop do 
            let length = BigInteger.Log(upperLimit, 2.0) |> Math.Ceiling
            let byteLength = length/8.0 |> Math.Ceiling |> int
            let data = Array.init byteLength (fun i -> 0uy)
            rand.NextBytes(data)
            res <- BigInteger(data)
            if res < upperLimit && res >= lowerLimit then
                loop <- false
            else ()
        res
    
    ///Should only be used for quite small integers, preferably under 200 or so.
    let simplePrimeTest (n:int):bool = 
        let primeTestByDivision n =
            let max = n/2
            [2 .. max] |> Seq.forall(fun i -> n%i<>0)
        match n with
        | n when n < 2 -> false
        | n when n = 2 || n = 3 -> true 
        | n when n % 2 = 0 -> false
        | n -> primeTestByDivision n
    
    let isPrime (n:BigInteger) =
        if n < 200I then
            simplePrimeTest (int n)
        else
            isPrimeW [generateRandomBigInt(2I, n-2I); generateRandomBigInt(2I, n-2I)] n