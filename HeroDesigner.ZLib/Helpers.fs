module HeroDesigner.ZLib.Helpers

open System.Text
open System

let byteArrayToHexString (ba:byte[]) =
    let hex = StringBuilder(Array.length ba * 2)
    for b in ba do
        hex.AppendFormat("{0:x2}", b) |> ignore<StringBuilder>
    hex.ToString()
let hexStringToByteArray hex =
    let count = String.length hex
    let bytes = Array.zeroCreate <| count / 2
    for i in [0..2..count - 1] do
        bytes.[i / 2] <- Convert.ToByte(hex.Substring(i,2), 16)
    bytes

