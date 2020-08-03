let digitToWord n =
    match n with
    | 0 -> ""
    | 1 -> "one"
    | 2 -> "two"
    | 3 -> "three"
    | 4 -> "four"
    | 5 -> "five"
    | 6 -> "six"
    | 7 -> "seven"
    | 8 -> "eight"
    | 9 -> "nine"
    | _ -> failwith "invalid pattern"
//this is for when the tens group is anything other than 1
let tenGroupToWord n =
    match n with
    | 0 -> "ten"
    | 1 -> "eleven"
    | 2 -> "twelve"
    | 3 -> "thirteen"
    | 4 -> "fourteen"
    | 5 -> "fifteen"
    | 6 -> "sixteen"
    | 7 -> "seventeen"
    | 8 -> "eighteen"
    | 9 -> "nineteen"
    | _ -> failwith "invalid pattern"
//this is for when the tens group is exactly 1
let tensToWord n =
    match n with
    | 2 -> "twenty"
    | 3 -> "thirty"
    | 4 -> "fourty"
    | 5 -> "fifty"
    | 6 -> "sixty"
    | 7 -> "seventy"
    | 8 -> "eighty"
    | 9 -> "ninety"
let hundredGroupToWord n =
    match n with
    |
let thousandGroupToWord n =
    0
let numToWord n =
    //get number of thousands, hundreds, tens and single digit
    let finalDigit = n % 10
    let tens = (n/10)%10
    let hundreds = (n/100)%10
    let thousands = (n/1000)%10
    match tens with
    | 1 -> 
    | _ -> 