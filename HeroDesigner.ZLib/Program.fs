module HeroDesigner.ZLib.Program
// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
let (|ParseInt|_|) x=
    match System.Int32.TryParse(s=x) with
    | true, i -> Some i
    | _ -> None

[<EntryPoint>]
let main argv = 
    let borderize = printfn "----------\r\n%s\r\n----------" 
    System.Diagnostics.Debugger.Launch() |> ignore
    System.Diagnostics.Debugger.Break()
    match argv |> List.ofArray with
    | "uncompress"::ParseInt inBytes::ParseInt len :: x::[] ->
        let input=HeroDesigner.ZLib.Helpers.hexStringToByteArray x
        if input.Length <> inBytes then
            #if DEBUG
            failwithf "input not read correctly"
            #endif
            eprintfn "input not read correctly expected length %i but was %i" inBytes input.Length
            -1
        else
            match PInvoke.decompress(input, len) with
            | Ok result ->
                let hexEncoded= HeroDesigner.ZLib.Helpers.byteArrayToHexString result
                borderize hexEncoded
                0
            |Error x -> x
    | "compress"::x::[] ->
        let input = System.Text.Encoding.UTF8.GetBytes x
        System.Diagnostics.Debugger.Launch() |> ignore
        match PInvoke.compress input with
        | Ok result ->
            borderize <| System.Text.Encoding.UTF8.GetString result
            0
        | Error x -> x
    | _ ->
        System.Diagnostics.Debugger.Launch() |> ignore
        printfn "%A" argv
        1 // return an integer exit code
