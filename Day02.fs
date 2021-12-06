module Day02

open System.IO

type Command =
    | Forward of int
    | Down of int
    | Up of int

let parseCommand (str : string) =
    match str.Split ' ' with
    | [|"forward"; y|] -> Forward (int y)
    | [|"down"; y|] -> Down (int y)
    | [|"up"; y|] -> Up (int y)
    | _ -> invalidArg str "Invalid command"

let commands =
    File.ReadAllLines("input/day02.txt")
    |> Seq.map parseCommand

// Part 1

type Position = { Horizontal : int; Depth : int }

let move position command =
    match command with
    | Up x -> { position with Depth = position.Depth - x }
    | Down x -> { position with Depth = position.Depth + x }
    | Forward x -> { position with Horizontal = position.Horizontal + x }

let initialPosition = { Horizontal = 0; Depth = 0 }
let finalPosition = Seq.fold move initialPosition commands

let answerOne = finalPosition.Horizontal * finalPosition.Depth

// Part 2

type PositionWithAim = { Horizontal : int; Depth : int; Aim : int }

let aimAndMove position command =
    match command with
    | Up x -> { position with Aim = position.Aim - x }
    | Down x -> { position with Aim = position.Aim + x }
    | Forward x -> { position with Horizontal = position.Horizontal + x; Depth = position.Depth + position.Aim * x }

let initialPositionWithAim = { Horizontal = 0; Depth = 0; Aim = 0 }
let finalPositionWithAim = Seq.fold aimAndMove initialPositionWithAim commands

let answerTwo = finalPositionWithAim.Horizontal * finalPositionWithAim.Depth

let xmas =
    printfn "Final position (Pt. 1) = %i" answerOne
    printfn "Final position (Pt. 2) = %i" answerTwo
