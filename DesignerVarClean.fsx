open System
open System.IO
open System.Text.RegularExpressions

let target = @"C:\projects\CoHDesigner2\Hero Designer\frmMain.cs"
let minI,maxI = 2681,4203
let writeAllLines x = File.WriteAllLines(target,x)
let getGValue (i:int) (m:Match) = m.Groups.[i].Value

let (|RMatch|_|) (r:Regex) line =
    let m = r.Match(line)
    if m.Success then Some m
    else None
    
let contains d (x:string) = x.Contains(d)
let (|Contains|_|) d line = if contains d line then Some line else None
[<NoComparison>]
type TransformationType =
    |Relative of (string[] -> int*string -> string)
    |Simple of (int*string -> string)
let transformFile f =
    let text = File.ReadAllLines target
    let f=
        match f with
        |Relative f -> f text
        |Simple f -> f
    text
    |> Array.mapi(fun i line ->
        if i >= minI && i <= maxI then
            f (i,line)
        else line
    )
    |> writeAllLines
let rCommented = sprintf @"^(\s+)%s(.*)$" (Regex.Escape(@"//"))|> Regex
let (|Commentline|_|) =
    function
    | x when String.IsNullOrWhiteSpace x -> None
    | x when x.TrimStart().StartsWith("//") -> Some x
    | _ -> None
    
let toggleComment =
    let rLine = sprintf @"^(\s+)(.*)$" |> Regex
    function
    | RMatch rCommented m ->
        let getGValue x = getGValue x m
        sprintf "%s%s" (getGValue 1) (getGValue 2)
        |> Choice1Of2
    | RMatch rLine m ->
        let getGValue x = getGValue x m
        sprintf @"%s//%s" (getGValue 1) (getGValue 2)
        |> Choice1Of2
    | line -> Choice2Of2 line

let toggleWordComment word =
    function
    | _,Contains word line ->
        match toggleComment line with
        |Choice1Of2 line -> line
        |Choice2Of2 l -> failwithf "Contained value, but regexes didn't match:%s" l
    | _,line -> line

let commentRange (minI,maxI) (i,x) =
    if minI <=i && i <= maxI then
        toggleComment x
        |> function
            |Choice1Of2 line -> line
            |Choice2Of2 "" -> String.Empty
            |Choice2Of2 l -> failwithf "no regex matched:%s" l
            
    else x
    
//transformFile (Simple <| commentRange (3707,4200))
let transformPointVar _ =
    let rPointPattern = Regex @"(\s+)(?:Point )?point = (new Point\(.*\);)\s*"
    let rPointdPattern = Regex @"^(.* = )point;\s*$"
    // store last line replacement
    let mutable previousMatch = None
    fun (i,line) ->
        match previousMatch,line with
        | None,RMatch rPointPattern m ->
            previousMatch <- Some (i,getGValue 2 m)
            String.Empty
        | None,(RMatch rPointdPattern _ as line) ->
            failwithf "Found pointd but had nothing stored at %i %s" (i+1) (line.Trim())
        | None, line -> line
        | Some(prevI,_),_ when i - prevI <> 1 ->
            failwithf "Have previous without match at %i -> %i" (prevI+1) (i+1)
        | Some(_,pointTxt), RMatch rPointdPattern m ->
            previousMatch <- None
            sprintf "%s%s" (getGValue 1 m) (pointTxt)
        | _ -> failwithf "Unaccounted for combination"
let transformSizeVar _ =
    let rSizePattern = Regex @"(\s+)(?:Size )?size = (new Size\(.*\);)\s*"
    let rSizedPattern = Regex @"^(.* = )size;\s*$"
    // store last line replacement
    let mutable previousMatch = None
    fun (i,line) ->
        match previousMatch,line with
        | None,RMatch rSizePattern m ->
            previousMatch <- Some (i,getGValue 2 m)
            String.Empty
        | None,(RMatch rSizedPattern _ as line) ->
            failwithf "Found sized but had nothing stored at %i %s" (i+1) (line.Trim())
        | None, line -> line
        | Some(prevI,_),_ when i - prevI <> 1 ->
            failwithf "Have previous without match at %i -> %i" (prevI+1) (i+1)
        | Some(_,sizeTxt), RMatch rSizedPattern m ->
            previousMatch <- None
            sprintf "%s%s" (getGValue 1 m) (sizeTxt)
        | _ -> failwithf "Unaccounted for combination"
let _ = 
    fun () ->
        transformFile (Simple <| commentRange (3707,4200))
        transformFile (Relative transformSizeVar)
        transformFile (Relative transformPointVar)
