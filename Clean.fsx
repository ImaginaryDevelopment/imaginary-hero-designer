open System
open System.IO
open System.Text.RegularExpressions

let root = __SOURCE_DIRECTORY__
module Helpers =
    let writeLines (fp:string) (text:string[]) = File.WriteAllLines(path=fp,contents=text)
    let writeText (fp:string) (text:string) = File.WriteAllText(path=fp,contents=text)
    let withIndexes = Seq.mapi(fun i x -> i,x)
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

    let rMatch p x =
        let m = Regex.Match(input=x,pattern=p)
        if m.Success then Some m else None
    let rMatchm p x =
        let m = Regex.Match(input=x,pattern=p,options=RegexOptions.Multiline)
        if m.Success then Some m else None
    let rReplace p r x =
        Regex.Replace(x,pattern=p,replacement=r)
    let rReplacem p r x =
        Regex.Replace(x,pattern=p,replacement=r,options=RegexOptions.Multiline)
    let killWs =
        String.collect(string>> fun c -> if String.IsNullOrWhiteSpace c then " " else Regex.Escape c)
        >> rReplace @"\s+" @"\s+"
    let matchesM p x = Regex.Matches(x,pattern=p,options=RegexOptions.Multiline)

    module String =
        let contains d (x:string) = x.Contains(d)
    module Tuple2 =
        let swp (x,y) = (y,x)
    ()
open Helpers
let getAllCsFiles() = searchAllDirectories (root,"*.cs")
let isForm text = rMatchm @"^\s*(?:public)? class (?<name>\w+)\s*:\s*Form($|(?:\s.*$))" text

let cleanDecompilerComments () =
    searchAllDirectories (root, "*.cs")
    |> Seq.iter(fun fp ->
        // a peek rather than reading the entire file into memory would be nice
        let lines = File.ReadAllLines fp
        if lines.[0] = "// Decompiled with JetBrains decompiler" then
            lines
            |> Array.skipWhile(fun line ->
                line = "// Decompiled with JetBrains decompiler"
                || line.StartsWith "// Type: "
                || line.StartsWith "// Assembly: "
                || line.StartsWith "// MVID: "
                || line.StartsWith "// Assembly location:"
                || String.IsNullOrWhiteSpace line
            )
            |> writeLines fp
    )

// attach resource to form(does not account for the possibility there is already a designer)
type ProjAccumulation = {FormNames:Set<string>;ResourceNames:Map<string,int>}
let attachResources () =
    let foldLines f (previousLinesRev:string list,x:'t) (i:int,line:string):string list * 't =
        let nextLines,x = f (i,line) x 
        (nextLines@previousLinesRev,x)

    let addFormDependencies (projectfilePath:string,resMap:Map<int,string>, lines:string[]) =
        let folder =
            foldLines(fun (i,line) resMap ->
                if Map.containsKey i resMap then
                    [
                        "    </EmbeddedResource>"
                        sprintf "      <DependentUpon>%s.cs</DependentUpon>" resMap.[i]
                        line |> replace " />" ">"
                    ], resMap |> Map.remove i
                else [line], resMap
            )
        ((List.empty,resMap),lines |> withIndexes)
        ||> Seq.fold folder
        |> fun (linesRev,mapRemainders) ->
            if not mapRemainders.IsEmpty then
                failwithf "Had unmatched items %A" mapRemainders
            else linesRev |> List.rev
        |> Array.ofList
        |> writeLines projectfilePath
    searchAllDirectories(root,"*.csproj")
    |> Seq.iter(fun pfp ->
        let lines = File.ReadAllLines pfp
        let rCompile = Regex("<Compile Include=\"(\w+).cs\">")
        let rResource = Regex("<EmbeddedResource\s+Include=\"(\w+).resx\"\s*/>")
        if lines |> Seq.exists(fun line -> line.Contains "<SubType>Form</SubType>") then
            ({FormNames=Set.empty;ResourceNames=Map.empty},lines |> withIndexes)
            ||> Seq.fold(fun pa (i,line) ->
                match line with
                |RMatch rCompile m ->
                    let formName = m.Groups.[1].Value
                    {pa with FormNames=pa.FormNames|> Set.add formName}
                |RMatch rResource m ->
                    let resName = m.Groups.[1].Value
                    {pa with ResourceNames= pa.ResourceNames |> Map.add resName i}
                | _ -> pa
            )
            |> fun x ->
                let rnKeys = Map.toSeq x.ResourceNames |> Seq.map fst |> Set.ofSeq
                let unmatched = rnKeys |> Set.difference x.FormNames
                if unmatched.Count > 0 then
                    // warning not error, but there's no wprintfn
                    eprintfn "Unmatched items:%A" unmatched
                x.FormNames |> Seq.truncate 3 |> List.ofSeq |> printfn "Some Forms:%A"
                x.ResourceNames |> Map.toSeq |> Seq.map fst |> Seq.truncate 3 |> List.ofSeq |> printfn "Some RNs:%A"
                printfn "Found %i forms and %i resources with (%i unmatched) in %s" x.FormNames.Count x.ResourceNames.Count unmatched.Count pfp
                // find items that do match to process
                // a map of what the two had in common to the resource line number
                let commonMap =
                    let shared = Set.union x.FormNames rnKeys
                    x.ResourceNames
                    |> Map.filter(fun k _ -> shared.Contains k)
                    |> Map.toSeq
                    |> Seq.map Tuple2.swp
                    |> Map.ofSeq
                addFormDependencies(pfp,commonMap,lines)
            |> ignore

)
// remove form properties by pattern
type Matched = {TypeName:string;PropName:string;Raw:string}
let getProp {PropName=p} = p
let makeMatched =
    Seq.cast<Match>
    >> Seq.map(fun m -> {TypeName=m |> getGroupNValue "type";PropName=m |> getGroupNValue "prop";Raw=m.Value})
    >> List.ofSeq

let atpFieldRegex =
    let pattern = """^\s*\[AccessedThroughProperty\("(?<prop>\w+)"\)\]\r\n\s*(?<type>\w+) _\k<prop>;\r\n"""
    let r = Regex(pattern,RegexOptions.Multiline)
    (fun text ->
        r.Matches(text)
        |> makeMatched
    )
let makePropPattern getter setter =
    let methodImplPattern ="\[MethodImpl\(MethodImplOptions.Synchronized\)\]"
    sprintf "^\s*(?:private)?\s*(?<type>\w[\w.]+) (?<prop>\w+)\r\n\s*{\s*get\s*{\s*%s\s*}\s*%s\s*set\s*{\s*%s\s*}\s*}" getter methodImplPattern setter
let joinFieldsToProps (fm:Matched list) (pm:Matched list) =
    query{
        for f in fm do
        join p in pm on (f.PropName = p.PropName)
        select(f.PropName,(f,p))
    }
    |> Map.ofSeq

let (|PatternMatches|_|) propPattern text =
    let pm = Regex.Matches(text,propPattern, RegexOptions.Multiline)
    pm.Count |> printfn "Found %i matches"
    if pm.Count > 0 then
        let fm = atpFieldRegex(text)
        if fm.Length > 0 then
            let map = pm |> makeMatched |> joinFieldsToProps fm
            if map.Count > 0 then
                Some (map, text)
            else None
        else None
    else None

let cleanFormProperties (fp,text)=
    //let propPattern getter setter = sprintf "^\s*(?<type>\w[\w.]+) (?<prop>\w+)\r\n\s*{\s*get\s*{\s*%s\s*}\s*%s\s*set\s*%s\s*}\s*}" getter methodImplPattern setter
    let pattern = makePropPattern "return this._\k<prop>;" "this._\k<prop> = value;"
    printfn "pattern: %s" pattern
    text
    // kill all the private noise
    |> rReplace "^(\s*)private (?!set)(.*)$" "$1 $2"
    // kill all the internal virtual noise
    |> rReplace "^(\s*)internal virtual (?!set)(.*)" "$1 $2"
    |> fun x ->
        if x <> text then
            printfn "Found something to change!"
            writeText fp text
        x
    |> function
    | PatternMatches pattern (map,text) ->
        (text,map |> Map.toSeq)
        ||> Seq.fold(fun text (prop,(f,p)) ->
            if f.TypeName <> p.TypeName then failwithf "Bad match! (%s,%s)" f.TypeName p.TypeName
            text
            |> remove p.Raw
            |> replace f.Raw (sprintf "        %s %s;\r\n" f.TypeName prop)
        )
        |> writeText fp
        printfn "Found %i matches to map" map.Count
        map.Count > 0
    | _ -> false
()
let cleanAllFormProperties () =
    getAllCsFiles()
    |> Seq.choose(fun fp ->
        let text = File.ReadAllText fp
        match isForm text with
        |Some _ -> Some (fp,text)
        | _ -> None
    )
    |> Seq.filter cleanFormProperties
    |> Seq.map fst
    |> Seq.length
    |> printfn "Cleaned %i files"

//getAllCsFiles()
//|> Seq.choose(fun fp ->
//    printfn "Checking file %s" fp
//    let text = File.ReadAllText fp
//    match isForm text with
//    |Some _ -> Some (fp,text)
//    | _ -> None
//)
//|> Seq.map fst
//|> List.ofSeq
//|> List.length
//|> printfn "Found %i form files"
//cleanProperties testTarget
//atpFieldRegex.Matches(File.ReadAllText testTarget).Count
cleanAllFormProperties ()
//let testTarget = @"C:\projects\CoHDesigner2\Hero Designer\frmMain.cs"

