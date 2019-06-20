open System
open System.IO
open System.Text.RegularExpressions

let root = __SOURCE_DIRECTORY__
module Helpers =
    let replace d r (x:string) = x.Replace(oldValue=d,newValue=r)
    let writeLines (fp:string) (text:string[]) = File.WriteAllLines(path=fp,contents=text)
    let withIndexes = Seq.mapi(fun i x -> i,x)
    let searchAllDirectories (path,pattern) = Directory.GetFiles(path,pattern,SearchOption.AllDirectories)
    let (|RMatch|_|) (r:Regex) x =
        let m = r.Match(input=x)
        if m.Success then Some m else None
    module Tuple2 =
        let swp (x,y) = (y,x)
    ()
open Helpers

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
// add designer (does not account for the possibility there is already a designer)

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
type ProjAccumulation = {FormNames:Set<string>;ResourceNames:Map<string,int>}
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
