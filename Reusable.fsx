open System
open System.IO
open System.Text.RegularExpressions

let root = __SOURCE_DIRECTORY__
let dump,flushDump =
    let mutable itemsToShow = List.empty
    (fun (x:obj) ->
        itemsToShow <- x :: itemsToShow
    ), (fun () ->
        if not <| List.isEmpty itemsToShow then
            itemsToShow
            |> List.map string
            |> String.concat "\r\n"
            |> System.Windows.Forms.MessageBox.Show
            |> ignore
            itemsToShow <- List.empty
    )
let curry f x y = f(x,y)
let uncurry f (a,b) = f a b
let failifempty x = if Seq.exists(fun _ -> true) x then x else failwithf "Empty not expected"
let equalsI (x:string) (y:string) = String.Equals(x,y,StringComparison.InvariantCultureIgnoreCase)
module Seq =
    let fork f x =
        ((List.empty,List.empty),x)
        ||> Seq.fold(fun (t1s,t2s)  x ->
            match f x with
            |Choice1Of2 v -> v::t1s,t2s
            |Choice2Of2 v -> t1s, v::t2s
        )
module String =
    let guardNonEmpty msg x =
        match x with 
        | null | "" -> failwithf "Null or empty string; %s" msg
        | _ -> ()
    let contains d (x:string) = x.Contains(d)
    let trim (x:string) = x.Trim()
    let splitLines (x:string) = x.Split([|"\r\n";"\n";"\r"|], StringSplitOptions.None)
module Option =
    let ofValueString =
        function
        | x when String.IsNullOrWhiteSpace x -> None
        | x -> Some x

let flip f x y = f y x
let writeLines (fp:string) (text:string[]) = File.WriteAllLines(path=fp,contents=text)
let transformValueOpt f x =
    Option.ofValueString x
    |> Option.bind f

let (|IndexOf|_|) d =
    String.guardNonEmpty "delimiter" d
    transformValueOpt (fun x ->
        let i = x.IndexOf d
        if i >= 0 then Some i
        else None
    )
let (|NonValueString|_|) =
    function
    |"" | null as x -> Some x
    | x when String.IsNullOrWhiteSpace x -> Some x
    | _ -> None

let tryAfter d =
   String.guardNonEmpty "delimiter" d
   transformValueOpt <|
       function
       | IndexOf d i as x -> Some x.[i + d.Length..]
       | _ -> None
let after d x =
    tryAfter d x
    |> function
        |Some v -> v
        |None -> failwithf "did not find %s in %s" d x

let inline printCount title x =
    Seq.length x
    |> printfn "%s %i" title
    x
let inline dumpCount title x =
    Seq.length x
    |> sprintf "%s %i\r\n" title
    |> dump
    x

let readLines (fp:string) = File.ReadAllLines fp
let writeText (fp:string) (text:string) = File.WriteAllText(path=fp,contents=text)
let inline withIndexes items = items |> Seq.mapi(fun i x -> i,x)
let searchAllDirectories (path,pattern) = Directory.GetFiles(path,pattern,SearchOption.AllDirectories)
let (|RMatch|_|) (r:Regex) x =
    let m = r.Match(input=x)
    if m.Success then Some m else None
let getGroupValue(x:int) (m:Match) = m.Groups.[x].Value
let getGroupNValue(x:string) (m:Match) = m.Groups.[x].Value
let trimEnd(x:string) = x.TrimEnd()
let replace d r (x:string) =
    try
        x.Replace(d,newValue=r)
    with _ ->
        printfn "failing: (%s,%s)" d r
        reraise()
let remove d x =
    replace d String.Empty x
  
let replace1 (d:string) r (x:string) =
    let start = x.IndexOf(d)
    let result = String.concat "" [x.[0..start - 1];r;x.[start+d.Length..] ]
//    (d,r,x,start,result).Dump("replaced 1")
    result

let rMatchr (r:Regex) x =
    let m = r.Match x
    if m.Success then Some m
    else None
let rMatch p x =
    try
        let m = Regex.Match(input=x,pattern=p)
        if m.Success then Some m else None
    with _ ->
        eprintfn "Failing on pattern %s" p
        reraise()

let rMatchm p x =
    let m = Regex.Match(input=x,pattern=p,options=RegexOptions.Multiline)
    if m.Success then Some m else None
let rReplace p r x =
    Regex.Replace(x,pattern=p,replacement=r)
let isMatch p x = Regex.IsMatch(x,p)
let rReplacem p r x =
    Regex.Replace(x,pattern=p,replacement=r,options=RegexOptions.Multiline)
let killWs =
    String.collect(string>> fun c -> if String.IsNullOrWhiteSpace c then " " else Regex.Escape c)
    >> rReplace @"\s+" @"\s+"
let matchesM p x = Regex.Matches(x,pattern=p,options=RegexOptions.Multiline)

module Tuple2 =
    let swp (x,y) = (y,x)
    let mapSnd f (x,y) = (x, f y)
    let optionOfSnd (x,y) = y |> Option.map(fun y -> x,y)
let getAllCsFiles() = searchAllDirectories (root,"*.cs")
let isForm text = rMatchm @"^\s*(?:public)? class (?<name>\w+)\s*:\s*Form($|(?:\s.*$))" text
let isNamedForm name text =
    rMatchm (sprintf @"^\s*(?:public)? class (%s)\s*:\s*Form($|(?:\s.*$))" name) text

let findParentCsProject path =
    let rec findParentCs path =
        match Path.GetDirectoryName path with
        | null -> None
        | parent ->
            Directory.GetFiles(path,"*.csproj")
            |> Seq.tryHead
            |> function
                |None -> findParentCs parent
                |Some p -> Some p
    if File.Exists path then
        Path.GetDirectoryName path
    else path
    |> findParentCs
type PathingRelation = {Source:string;TargetPath:string}
// for projects, source would be project dir or project path, either should work
let getRelativePath {Source=target;TargetPath=from} =
    let p1 = Uri(uriString=target)
    let p2 = Uri(uriString=from)
    let diff = p1.MakeRelativeUri(p2)
    diff.OriginalString
    |> replace "/" "\\"
