//First problem that gets a little more mathmatical.
//Lets first rotate the field by 180 degrees and refer to moves as either N or E (north or east)
//In a 20x20 grid we have to do 20 north moves and 20 east moves as we have to get from (0,0) to (20,20)
//The number of paths from (0,0) to (n,k) is (n+k over n), so its (20+20 over 20) (Binomial coefficient!!)
// Or 40!/(20!*(40-20)!) or 40!/(20!*20!)
namespace ProjectEuler

module Problems =
    open System.Numerics

    let factorial n =
        let rec loop i acc =
            match i with
            | i when i = 0I || i = 1I -> acc
            | _ -> loop (i - 1I) (acc * i)
        loop n 1I

    let Problem15 =
        factorial (BigInteger 40) / (factorial (BigInteger 20L) * factorial (BigInteger 20L))
