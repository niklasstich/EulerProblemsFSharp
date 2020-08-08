//1 Jan 1900 = Monday
//Months in Days:
//01, 04, 06, 09, 11 = 30 Days
//03, 05, 07, 08, 10, 12 = 31 Days
//02 = 28 Days, 29 Days in leap years
//How many sundays on the first of a month from 1901/01/01 - 2000/12/31

namespace ProjectEuler



module Problem0019 =
    
    open System
    //These 2 functions are nice and work, but we don't need them when using the .NET provided DateTime
    let isLeapYear n =
        n%4=0&&(not(n%100=0)||n%400=0)
    let monthAndYearToDays month year =
        let leapYear = isLeapYear year
        match month, leapYear with
        | 1, _ | 4, _ | 6, _ | 9, _ | 11, _
            -> 30
        | 3, _ | 5, _ | 7, _ | 8, _ | 10, _ | 12, _
            -> 31
        | 2, true -> 29
        | 2, false -> 28
        | _, _ -> failwith "invalid month"

    let Problem19 =
        [1901 .. 2000] //for every year from 1901 to 2000, and for every month from 1 to 12 (cartesian product), get a DateTime object for the first day of that year and month combination
        |> Seq.collect (fun year -> [1 .. 12] |> List.map(fun month -> DateTime(year,month,1)))
        |> Seq.filter (fun date -> date.DayOfWeek = DayOfWeek.Sunday) //Merely filter out only the sundays...
        |> Seq.length //...and count them