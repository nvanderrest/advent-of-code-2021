module Day01

open System.IO

let lines = File.ReadAllLines "input/day01.txt"

let depths = Seq.map int lines

let isIncreased (next, curr) = next > curr

let numberOfIncreases measurements =
    measurements
    |> Seq.zip (Seq.tail measurements)
    |> Seq.filter isIncreased
    |> Seq.length

let sumOfDepths =
    Seq.zip3 depths (Seq.skip 1 depths) (Seq.skip 2 depths)
    |> Seq.map (fun (x, y, z) -> x + y + z)

let xmas =
    printfn "Day 01: %i" (numberOfIncreases depths)
    printfn "Day 01: %i" (numberOfIncreases sumOfDepths)
