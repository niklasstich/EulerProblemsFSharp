namespace ProjectEuler

module Problem0017 =
    open System.Text

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
        | 4 -> "forty"
        | 5 -> "fifty"
        | 6 -> "sixty"
        | 7 -> "seventy"
        | 8 -> "eighty"
        | 9 -> "ninety"
        | _ -> failwith "invalid pattern"

    let hundredGroupToWord n =
        digitToWord n + " hundred"
    let thousandGroupToWord n =
        digitToWord n + " thousand"

    let numToWord n =
        //get number of thousands, hundreds, tens and single digit
        if (n = 0) then
            "zero"
        else
            let finalDigit = n % 10
            let tens = (n / 10) % 10
            let hundreds = (n / 100) % 10
            let thousands = (n / 1000) % 10

            let thousandsString =
                if (thousands <> 0) then digitToWord thousands + " thousand" else ""
            let hundredsString =
                if (hundreds <> 0) then digitToWord hundreds + " hundred" else ""
            let tensAndDigitString =
                if (tens <> 0) then
                    if (tens = 1)
                    then tenGroupToWord finalDigit
                    else tensToWord tens + " " + digitToWord finalDigit
                else if (finalDigit <> 0) then
                    digitToWord finalDigit
                else
                    ""

            let mutable stringBuilder = StringBuilder()
            stringBuilder <- stringBuilder.Append(thousandsString)
            if (thousandsString <> "" && hundredsString <> "")
            then stringBuilder <- stringBuilder.Append(" ")
            else ()
            stringBuilder <- stringBuilder.Append(hundredsString)
            if (hundredsString <> "" && tensAndDigitString <> "")
            then stringBuilder <- stringBuilder.Append(" and ")
            else ()
            stringBuilder <- stringBuilder.Append(tensAndDigitString)
            stringBuilder.ToString()

    let Problem17 =
        ([ 1 .. 1000 ]
         |> List.map numToWord
         |> Seq.fold (fun acc a -> acc + a) "").Replace(" ", "").Length
