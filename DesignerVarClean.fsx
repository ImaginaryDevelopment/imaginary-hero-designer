// clean up point = and size = patterns
open System
open System.IO
open System.Text.RegularExpressions

let root = __SOURCE_DIRECTORY__

let searchAllDirectories (path,pattern) = Directory.GetFiles(path,pattern,SearchOption.AllDirectories)
let getAllCsFiles() = searchAllDirectories (root,"*.cs")
let writeLines (fp:string) (text:string[]) = File.WriteAllLines(path=fp,contents=text)
//let writeAllLines x = File.WriteAllLines(target,x)
let getGValue (i:int) (m:Match) = m.Groups.[i].Value
let trim (x:string) = x.Trim()

let (|RMatch|_|) (r:Regex) line =
    let m = r.Match(line)
    if m.Success then Some m
    else None
let contains d (x:string) = x.Contains(d)
let (|Contains|_|) d line = if contains d line then Some line else None
type Fileish = {FullPath:string;Lines:string[]}
[<NoComparison>]
type TransformationType =
    |Relative of (Fileish -> int*string -> string)
    |Simple of (int*string -> string)
let transformFile target f =
    let text = File.ReadAllLines target
    let f=
        match f with
        |Relative f -> f {FullPath=target;Lines=text}
        |Simple f -> f
    text
    |> Array.mapi(fun i line -> f (i,line))
    |> writeLines target
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
let transformPointVar fileish =
    let rPointPattern = Regex @"(\s+)(?:Point )?point = (new Point\(.*\);)\s*"
    let rPointdPattern = Regex @"^(.* = )point;\s*$"
    // store last line replacement
    let mutable previousMatch = None
    let gv2 m =getGValue 2 m
    fun (i,line) ->
        match previousMatch,line with
        | None,RMatch rPointPattern m ->
            previousMatch <- Some (i,m)
            String.Empty
        | None,(RMatch rPointdPattern _ as line) -> line
        | None, line -> line
        | Some(prevI,_),_ when i - prevI <> 1 ->
            failwithf "Have previous without match at %i -> %i" (prevI+1) (i+1)
        | Some(_,mSz), RMatch rPointdPattern m ->
            previousMatch <- None
            sprintf "%s%s" (getGValue 1 m) (gv2 mSz)
        | Some(_,m), line when fileish.FullPath.Contains("frmMain.cs") ->
            previousMatch <- None
            sprintf "%s\r\n%s" m.Value line
        | _ -> failwithf "Unaccounted for combination at %i in %s" i fileish.FullPath


let mutable linesProcessed = 0
let transformSizeVar fileish =
    let rSizePattern = Regex(@"^(\s+)(?:Size )?size = (new Size\(.*\);)\s*$", RegexOptions.Multiline)
    let rSizedPattern = Regex @"^(.* = )size;\s*$"
    // store last line replacement
    let mutable previousMatch = None
    let gv2 m = getGValue 2 m
    let mutable started = -1
    let getIsStarted () = started >= 0
    let mutable finished = false
    let rStart = Regex @"^(\s+)(private )?void InitializeComponent\(\s*\)"
    let rClose = Regex @"^(\s+)}\s*$"
    fun (i,line) ->
        linesProcessed <- linesProcessed + 1
        match previousMatch,line with
        | None, RMatch rStart m when getIsStarted() = false ->
            started <- (getGValue 1 m).Length
            line
        | _, _ when getIsStarted() = false -> line
        | None, RMatch rClose m when getIsStarted() && finished = false && (getGValue 1 m).Length = started ->
            finished <- true
            line
        | _, _ when finished -> line
        | None,RMatch rSizePattern m when getIsStarted() && finished = false ->
            previousMatch <- Some (i,m)
            printfn "Found a size setter on %i in %s" i fileish.FullPath
            String.Empty
        | None,(RMatch rSizedPattern _ as line) ->
            failwithf "Found sized but had nothing stored at %i %s" (i+1) (line.Trim())
        | None, x when x.TrimStart().StartsWith("size = ") -> failwithf "pattern did not match at %i in %s (started=%A,finished=%b) '%s'" i fileish.FullPath started finished (trim x)
        | None, line -> line
        | Some(prevI,_),_ when i - prevI <> 1 ->
            failwithf "Have previous without match at %i -> %i" (prevI+1) (i+1)
        | Some(_,mSz), RMatch rSizedPattern m ->
            previousMatch <- None
            sprintf "%s%s" (getGValue 1 m) (gv2 mSz)
        | Some(_,m), line when fileish.FullPath.Contains("frmMain.cs") ->
            previousMatch <- None
            sprintf "%s\r\n%s" m.Value line
        | _ -> failwithf "Unaccounted for combination at %i in %s" i fileish.FullPath
let _ = 
    getAllCsFiles()
    //|> Seq.filter(fun x -> x.EndsWith("frmCompare.cs"))
    |> Seq.iter(
        fun target ->
            //printfn "Starting transform on %s" target
            //transformFile (Simple <| commentRange (3707,4200))
            transformFile target (Relative transformSizeVar)
            transformFile target (Relative transformPointVar)
    )
printfn "processed %i lines" linesProcessed
