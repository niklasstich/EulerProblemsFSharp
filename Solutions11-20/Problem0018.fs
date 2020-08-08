//Input is structured as a pyramid eg:
//1
//5 6
//7 3 2
//and so on
//Input has a height of h, and at level n has a width of n+1
//At level n, if on the previous level the chosen node is c, then on the current level only node c or c+1 can be chosen
//This also means that for every node N with level n and position c,
//there are two ways of getting to it, namely the nodes with level n-1 and c-1 or c,
//as long as N.c isnt 0 or n (or in other words, as long as its not one of the nodes on the far sides
//Totaling up the values:
//Calling the original triangle O, and the triangle of totals T, we can say
//T0,0 = O0,0
//T1,0 = T0,0 + O1,0; T1,1 = T0,0 + O1,1
//and for n>=2:
//Tn,0 = T(n-1),0 + On,0; Tn,c = max(T(n-1),(c-1) , T(n-1),c) + On,c); Tn,n = T(n-1) + On,n 

namespace ProjectEuler

open System.IO

module Problem0018 =
    //Construct pyramid datastructure, list of lists of ints
    let numbers =
        File.ReadAllLines("Solutions11-20/Problem0018.txt")
        |> Seq.map(fun s -> s.Split(" ") |> Seq.map int |> Seq.toList)
        |> Seq.toList
    
    //Create all the possible combinations as outlined above
    //If n is zero, we are at the top of the pyramid and return an empty list of empty lists, because we have to return an empty list for every list element we get passed
    //If the list we get passed is empty, we return an empty list
    //Else, build a concatinated list of the above row and concatenate all the values
    let rec combinations n list =
        match n, list with
        | 0, _ -> [[]]
        | _, [] -> []
        | k, (x::xs) -> List.map((@) [x]) (combinations (k-1) xs) @ (combinations k xs)
    
    let getNewTotal row (total:int list) =
        let head = total.Head
        let tail = List.item (total.Length-1) total
        let body = total |> Seq.windowed 2 |> Seq.map (fun l -> Seq.max l) |> Seq.toList
        List.map2 (+) row (List.concat [[head]; body; [tail]])
        
    let rec traverse (raw:int list list) total n =
        let row = raw.[n]
        let newTotal = getNewTotal row total
        
        if n < (raw.Length-1) then
            traverse raw newTotal (n+1)
        else 
        newTotal
    let Problem18 = List.max (traverse numbers [75] 1)