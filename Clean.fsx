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
module Helpers =
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
let getProp {Matched.PropName=p} = p
let makeMatched =
    Seq.cast<Match>
    >> Seq.map(fun m -> {TypeName=m |> getGroupNValue "type";PropName= m |> getGroupNValue "prop";Raw=m.Value})
    >> List.ofSeq
module Regexes =
    module Impl =
        let groupCapture = sprintf "(%s)"
        let namedCapture name = sprintf "(?<%s>%s)" name
        let rematch name = sprintf "\k<%s>" name
    type RegexPlug =
        |Bare
        |Named of name:string

    let makeTypePattern =
        let core = @"\w[_\.\w]+"
        function
        |Bare -> core
        |Named name -> Impl.namedCapture name core

    // legal names (not accounting for keywords)
    let makeNamePattern =
        let core = @"\w[_\w]+"
        function
        |Bare -> core
        |Named name -> Impl.namedCapture name core

    let statementPattern = sprintf """^\s*%s;"""
    module Fields =
        let atpAttr = """\[AccessedThroughProperty\("(?<prop>\w+)"\)\]"""
        //let declaration =  
        let atpFieldRegex =
            let pattern = """^\s*\[AccessedThroughProperty\("(?<prop>\w+)"\)\]\r\n\s*(?<type>\w+) _\k<prop>;\r\n"""
            let r = Regex(pattern,RegexOptions.Multiline)
            (fun text ->
                r.Matches(text)
                |> makeMatched
            )
    module Lines =
        let openBraceLine = @"^\s*{\s*$"
        let closeBraceLine = @"^\s*}\s*$"


let groupNameEventNameStart = "evn"
let makeGroupNameForEventName i = sprintf "%s%i" groupNameEventNameStart i
let groupNameEventHStart = "evh"
let makeGroupNameForEventH i = sprintf "%s%i" groupNameEventHStart i
let ehTypePattern = @"(?:\w[.\w]+)?EventHandler"

// go line by line looking for a prop match
let cleanProperties =
    let testRegexes =
        List.mapi(fun i patterns ->
            try
                patterns |> String.concat "\r\n" |> Regex
                |> ignore
            with _ ->
                printfn "failing on %i pattern" i
                reraise()
            patterns
        )
    let openBraceLine = Regexes.Lines.openBraceLine
    let closeBraceLine = Regexes.Lines.closeBraceLine
    let propStartPattern = @"^\s+(?<modifier>private |public |internal )?(?<type>\w[\w.<>]+)\s+(?<prop>\w+)$"
    let makeRepeatEventPattern count =
        if count < 2 then failwithf "bad make repeat pattern attempt"
        let range = [0.. count - 1]
        flushDump()
        [
            yield propStartPattern
            yield openBraceLine
            yield @"^\s*get\s*$"
            yield openBraceLine
            yield @"^\s*return this._\k<prop>;\s*$"
            yield closeBraceLine
            yield @"^\s+\[MethodImpl\(\w+\.\w+\)\]\s*$"
            yield @"^\s+(private )?set\s*$"
            yield openBraceLine
            yield! range |> Seq.map makeGroupNameForEventH |> Seq.map (sprintf "^\s+%s \w+ = new %s\(this.(?<%s>\w[\w_]+)\);\s*$" ehTypePattern ehTypePattern)
            yield @"^\s+if \(this._\k<prop> != null\)\s*$"
            yield openBraceLine
            yield! range |> Seq.map makeGroupNameForEventName |> Seq.map(sprintf @"^\s+this._\k<prop>\.(?<%s>\w+) -= \w+;\s*$")
            yield closeBraceLine
            yield @"^\s*this._\k<prop> = value;\s*$"
            yield @"^\s+if \(this._\k<prop> == null\)\s*$"
            yield @"^\s*return;\s*$"
            yield! range |> Seq.map makeGroupNameForEventName |> Seq.map(sprintf @"^\s+this._\k<prop>\.\k<%s> \+= \w+;\s*$")
            yield closeBraceLine
            yield closeBraceLine
        ]
    [
        [
            propStartPattern
            openBraceLine
            @"^\s*get\s*$"
            openBraceLine
            @"^\s*return this._\k<prop>;\s*$"
            closeBraceLine
            "^\s+\[MethodImpl\(\w+\.\w+\)\]\s+set\s*$"
            openBraceLine
            @"^\s*this._\k<prop> = value;\s*$"
            closeBraceLine
            closeBraceLine
        ]
        [
            propStartPattern
            openBraceLine
            @"^\s*get\s*$"
            openBraceLine
            @"^\s*return this._\k<prop>;\s*$"
            closeBraceLine
            @"^\s*set\s*$"
            openBraceLine
            @"^\s*this._\k<prop> = value;\s*$"
            closeBraceLine
            closeBraceLine
        ]
        // methodImpl same line as set keyword
        [
            propStartPattern
            openBraceLine
            @"^\s*get\s*$"
            openBraceLine
            @"^\s*return this._\k<prop>;\s*$"
            closeBraceLine
            @"^\s+\[MethodImpl\(\w+\.\w+\)\]\s+set\s*$"
            openBraceLine
            sprintf "^\s+%s \w+ = new %s\(this.(?<%s>\w[\w_]+)\);\s*$" ehTypePattern ehTypePattern (makeGroupNameForEventH 0)
            @"^\s+if \(this._\k<prop> != null\)\s*$"
            sprintf @"^\s+this._\k<prop>\.(?<%s>\w+) -= \w+;\s*$" (makeGroupNameForEventName 0)
            @"^\s*this._\k<prop> = value;\s*$"
            @"^\s+if \(this._\k<prop> == null\)\s*$"
            @"^\s*return;\s*$"
            sprintf @"^\s+this._\k<prop>\.\k<%s> \+= \w+;\s*$" (makeGroupNameForEventName 0)
            closeBraceLine
            closeBraceLine
        ]
        // methodImpl not same line as set keyword
        [
            propStartPattern
            openBraceLine
            @"^\s*get\s*$"
            openBraceLine
            @"^\s*return this._\k<prop>;\s*$"
            closeBraceLine
            @"^\s+\[MethodImpl\(\w+\.\w+\)\]\s*$"
            @"^\s+set\s*$"
            openBraceLine
            sprintf "^\s+%s \w+ = new %s\(this.(?<%s>\w[\w_]+)\);\s*$" ehTypePattern ehTypePattern (makeGroupNameForEventH 0)
            @"^\s+if \(this._\k<prop> != null\)\s*$"
            sprintf @"^\s+this._\k<prop>\.(?<%s>\w+) -= \w+;\s*$" (makeGroupNameForEventName 0)
            @"^\s*this._\k<prop> = value;\s*$"
            @"^\s+if \(this._\k<prop> == null\)\s*$"
            @"^\s*return;\s*$"
            sprintf @"^\s+this._\k<prop>\.\k<%s> \+= \w+;\s*$" (makeGroupNameForEventName 0)
            closeBraceLine
            closeBraceLine
        ]
        // methodImpl not same line as set keyword
        makeRepeatEventPattern 2
        makeRepeatEventPattern 3
        makeRepeatEventPattern 4
        makeRepeatEventPattern 6
        makeRepeatEventPattern 8
        makeRepeatEventPattern 9
    ]
    |> testRegexes
type GroupName = GroupName of string
type GroupValue = GroupValue of string
type RPattern = RPattern of string
type MatchZipGroupContainer = {Groupings:(GroupName*GroupValue) list;Matches:(string*Match) list}
let matchZip patterns lines =
    if List.length patterns < List.length lines then
        None
    else
        let zipped =
            patterns
            |> Seq.map RPattern
            |> Seq.zip lines
        (Some {Groupings=List.empty;Matches=List.empty},zipped)
        ||> Seq.fold(fun stateOpt (line,RPattern p) ->
            stateOpt
            |> Option.bind(fun {Groupings=gs;Matches=ms} ->
                let pattern =
                        (p,gs)
                        ||> Seq.fold(fun p (GroupName gn,GroupValue gv) ->
                            let result =
                                p
                                |> replace (sprintf "\k<%s>" gn) gv
                            //printfn "Replacing %s with %s resulted in pattern %s" gn gv result
                            result
                        )
                match rMatch pattern line with
                |Some m ->
                    //printfn "matched %s for prop starting line %i" line
                    // check for named groups
                    if m.Groups.Count > 0 then
                        ({Groupings=gs;Matches=(line,m)::ms},m.Groups |> Seq.cast<Group>)
                        ||> Seq.fold(fun mzgc g ->
                            if not <| String.IsNullOrWhiteSpace g.Name && not <| Regex.IsMatch(g.Name,"^\d+$") then
                                //printfn "Found Group name %s" g.Name
                                {Groupings=(GroupName g.Name,GroupValue g.Value)::mzgc.Groupings;Matches=mzgc.Matches}
                            else mzgc
                        )
                    else {Groupings=gs;Matches=(line,m)::ms}
                    |> Some
                |None ->
                    None
            )
        )

type ModifierType = |Internal |NotInternal
type EventName = EventName of string
type EventHandler = EventHandler of string
type MatchedProp = {Prop:string;Modifier:ModifierType;Type:string;PropStartLine:int;PropStopLine:int;Events:(EventName*EventHandler) list}
type Eventish = EName of string | EHandler of string
type Folder<'tState,'t> = 'tState -> 't -> 'tState
// int is an index, but not a line number index
type EventGroupPartial = (int*Eventish) list
type EventGroupState =(EventName*EventHandler) list* EventGroupPartial
type EventGroupFolder = Folder<EventGroupState,string*string>


// if we have enough remaining lines for all patterns to match
let mustHaveEnoughLinesForPatternsToMatch lines i patterns =
    if Array.length lines > i + List.length patterns then
        Some patterns
    else None

let getProperties focusOpt fp (lines:string[]) =

    //let lines = File.ReadAllLines target |> Array.truncate 68
    [0..lines.Length - 1]

    |> Seq.map(fun i ->
        cleanProperties
        |> Seq.choose (mustHaveEnoughLinesForPatternsToMatch lines i)
        |> Seq.choose(fun patterns ->
            // get the lines to zip to the patterns
            let lines = lines.[i.. i+patterns.Length] |> Seq.truncate patterns.Length |> List.ofSeq
            matchZip patterns lines
        )
        |> fun x -> x
        |> Seq.map(fun mzgc -> // ignore internal those become None
            let findGn n = mzgc.Groupings |> Seq.tryFind(fun (GroupName gn,_) -> gn = n)
            let findReqGn n =
                match findGn n with
                | Some (GroupName _,GroupValue v) -> v
                | None -> failwithf "Could not find required match group name %s in %s" n fp
            
            let prop = findReqGn "prop"
            let type' = findReqGn  "type"
            let modifier =
                findGn "modifier"
                |> Option.map(fun (GroupName _, GroupValue v) -> v)
                |> Option.defaultValue String.Empty
                |> String.trim
                |> function
                    |"internal" -> Internal
                    | _ -> NotInternal

            // assuming any other named groups are events
            let events =
                let others =
                    mzgc.Groupings
                    |> List.choose(
                        function
                        |GroupName "modifier", _
                        |GroupName "prop",_
                        |GroupName"type",_ -> None
                        |GroupName e,GroupValue v -> Some(e,v)
                        )
                let folder : EventGroupFolder =
                    fun (pairs:(EventName*EventHandler) list, partials:(int*Eventish) list) (n:string,v:string) ->
                        let findMate start fWrap fMatch =
                            let ni = n |> after start |> int
                            partials
                            |> List.filter(fst >> (=) ni)
                            |> List.tryHead
                            |> Option.map snd
                            |> function
                                |None ->
                                    let egp:EventGroupPartial =(ni,fWrap v)::partials
                                    (pairs,egp)
                                |Some eish ->
                                    let egp: EventGroupPartial =partials |> List.filter(fst >> (=) ni >> not)
                                    fMatch ni (eish,egp)


                        if n.StartsWith groupNameEventNameStart then
                            findMate groupNameEventNameStart (Eventish.EName) (fun ni eish ->
                                match eish with
                                |Eventish.EName _,_ -> // we've found another event name with the same index, fail?
                                    failwithf "Conflicted event names for %s in %s" (makeGroupNameForEventName ni) fp
                                |Eventish.EHandler eh,egp ->
                                    // add new pair, remove old partial
                                    let target:EventGroupState = (EventName.EventName v,EventHandler.EventHandler eh)::pairs,egp
                                    target
                            )
                            // if we've found a partial match, pair them, and remove from partials
                            // if not, add to partials
                        elif n.StartsWith groupNameEventHStart then
                            findMate groupNameEventHStart (Eventish.EHandler) (fun ni eish ->
                                match eish with
                                |Eventish.EHandler _,_ -> failwithf "Conflicted event handlers for %s in %s" (makeGroupNameForEventH ni) fp
                                |Eventish.EName en,egp ->
                                    let target :EventGroupState = (EventName.EventName en, EventHandler.EventHandler v)::pairs,egp
                                    target
                                    
                            )
                        else
                            failwithf "unexpected groupname %s" n

                ((List.empty,List.empty), others)
                ||> Seq.fold folder
                |> fun (x,y) ->
                    if y.Length > 0 then
                        failwithf "unmatched events %A in %s" y fp
                    x

            {Prop=prop;Modifier=modifier;Type=type';PropStartLine=i-1;PropStopLine=i+mzgc.Matches.Length;Events=events}
        )
        |> List.ofSeq
    )
    |> Seq.collect id
    |> List.ofSeq

let findInitialize fp text =
    let isStart = String.contains "void InitializeComponent()" 
    let declaration = text |> Array.findIndex isStart
    let start,spaces =
        text
        |> withIndexes
        |> Seq.tryFind(fun (i,x) -> i > declaration && isMatch Regexes.Lines.openBraceLine x)
        |> function
            |None -> failwithf "Could not find method start after %i in %s" declaration fp
            |Some (i,x) ->
                // all lines between start and this if there are any, should be whitespace
                if declaration + 1 <> i then // there are lines between starting brace and method declaration
                    // inspect those lines
                    text.[declaration+1..i - 1]
                    |> Array.iteri (fun j line ->
                        if not <| String.IsNullOrWhiteSpace line then
                            failwithf "Expected only whitespace between InitializeComponent() and '{', but found %s at %i" line (declaration+j)
                    )


                rMatch "^(\s+)" x
                |> function
                    | Some m -> i,m.Groups.[1].Value.Length
                    | None -> failwithf "method start did not match spaces at %i in %s" i fp
    let closeBracePattern = sprintf @"^\s{%i}\}" spaces
    text
    |> withIndexes
    |> Seq.skip start
    |> Seq.skipWhile(snd >> isMatch closeBracePattern >> not)
    |> Seq.tryHead
    |> function
        |None -> failwithf "method close not found in %s" fp
        // don't include the method call itself, we want the open bracket line
        |Some (i,_) -> start+1,i - 1

let mateFields fp (text:string[]) (properties:MatchedProp list) =
    properties
    |> List.map(fun mp ->
        let r = Regex (Regexes.statementPattern <| sprintf @"%s _%s" mp.Type mp.Prop)
        text
        |> withIndexes
        |> Seq.choose(Tuple2.mapSnd (rMatchr r) >> Tuple2.optionOfSnd)
        |> Seq.tryHead
        |> function
            |Some (i,m) ->
                if Regex.IsMatch(text.[i-1],Regexes.Fields.atpAttr) then
                    (i-1,i),mp
                else (i,i),mp
            | None ->
                failwithf "Found property without field %s in %s" mp.Prop fp
    )

// encapsulate revelant parts of individual changes
type ChangeType =
    |FieldChange of name:string*ftype:string*stop:int
    |PropRemoval of name:string*stop:int
    // make auto-prop
    |PropSimplification of name:string*modifier:ModifierType*ptype:string*stop:int


type PreparedChange =
    |Regular of ChangeType
    |Events of Map<string,(EventName*EventHandler) list>
type ChangeContainer = {Start:int;PreparedChange:PreparedChange}

module Planning =
    type Change =
        |RegularChange of ChangeType
        // index for this is in scope
        |EventHook of propName:string*(EventName*EventHandler) list
    let gatherForPlan focusOpt failEmpty target text =
        getProperties focusOpt target text
        |> dumpCount "properties to match"
        |> mateFields target text
        |> dumpCount "mated with fields"
        |> fun x -> if failEmpty then failifempty x else x
        |> fun mates ->
            focusOpt
            |> Option.iter(fun focus ->
                mates
                |> Seq.tryFind(snd >> fun m -> m.Prop = focus)
                |> Option.iter dump
            )
            let init =
                if mates |> Seq.exists(fun (_,mp) -> mp.Events |> List.exists(fun _ -> true)) then
                    findInitialize target text |> Some
                else None
            // order by index of changes needed
            mates
            |> Seq.map(fun ((fStart,fStop),mp) ->
                [
                    focusOpt
                    |> Option.iter(fun focus ->
                        if mp.Prop = focus then dump "Mates has it!"
                    )
                    let isInternal = match mp.Modifier with |Internal -> true | _ -> false
                    let fieldText = if isInternal then sprintf "_%s" mp.Prop else mp.Prop
                    yield fStart,RegularChange <| FieldChange(fieldText,mp.Type,fStop)
                    if not isInternal then
                        yield mp.PropStartLine,RegularChange <| PropRemoval(mp.Prop,mp.PropStopLine)
                    else yield mp.PropStartLine, RegularChange <| PropSimplification(mp.Prop, mp.Modifier, mp.Type, mp.PropStopLine)

                    match mp.Events,init with
                    | [],_ -> ()
                    | _,None -> failwithf "Init not found, trying to plan for %s in %s" mp.Prop target
                    | _, Some (_,stop)-> 
                        yield stop,EventHook(mp.Prop,mp.Events)
            ]
            )
            |> Seq.collect id
    // reorganize in order of change
    let organizePlan items =
        items
        |> Seq.fork (fun (i,c) -> match c with |RegularChange x-> Choice2Of2 (i,x) | EventHook (prop,x) -> Choice1Of2 (i,prop,x))
        |> fun (es,cs) ->
            let cs = cs |> List.map (Tuple2.mapSnd Regular)
            match es with
            | [] -> cs
            | (i,_,_)::_ ->
                match es |> Seq.map(fun (i,_,_) -> i) |> Seq.tryFind((<>) i) with
                |Some i' -> failwithf "event indexes did not all match %i,%i" i i'
                |None ->
                    let targets = es |> List.map(fun (_,prop,events) -> prop,events) |> Map.ofSeq
                    (i,Events (targets))::cs
        |> Seq.map(fun (i,x) -> {Start=i;PreparedChange=x})
        |> Seq.sortBy (fun x -> x.Start)
let planCleaning focusOpt failEmpty target =
    let text = File.ReadAllLines target
        // fold events together
    Planning.gatherForPlan focusOpt failEmpty target text
    |> fun x -> x
    |> Planning.organizePlan
    |> List.ofSeq
    |> printCount (sprintf "Actions for file %s" target)
    |> fun changes ->
        focusOpt
        |> Option.iter(fun focus ->
            changes
            |> List.choose(fun x ->
                match x.PreparedChange with
                |Regular (PropSimplification (n,_,_,_)) -> Some (n,"S")
                |Regular (PropRemoval(n,_)) -> Some (n,"R")
                |Regular (FieldChange _) -> None
                | _ -> None
            )
            |> List.tryFind(fst >> (=) focus)
            |> dump
            |> flushDump
        )
        changes
    |> function
        |[] -> None
        |x -> Some (target,text,x)

let target = @"C:\projects\CoHDesigner2\Hero Designer\frmMain.cs"
open System.Text
type Metrics = {LineCount:int;CharCount:int}
let clean (target:string,text:string[],changeList:ChangeContainer list) =
    let sb = System.Text.StringBuilder()
    let appendLine x = sb.AppendLine x |> ignore<StringBuilder>
    let addUpTo i j = [i..j] |> Seq.map(fun index -> text.[index]) |> Seq.iter appendLine
    let inClassIndent = "        "
    let inMethodIndent = "              "

    (0,changeList)
    ||> Seq.fold(fun i cc ->
        addUpTo i (cc.Start - 1)
        match cc.PreparedChange with
        | Events emap ->
            let appendLine = sprintf "%s%s" inMethodIndent >> appendLine
            appendLine "//adding events"
            // https://stackoverflow.com/questions/2427381/how-to-detect-that-c-sharp-windows-forms-code-is-executed-within-visual-studio
            appendLine """if(!System.Diagnostics.Debugger.IsAttached || !this.IsInDesignMode() || !System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToLowerInvariant().Contains("devenv"))"""
            appendLine "{"
            emap
            |> Map.toSeq
            |> Seq.iter(fun (propName,events) ->
                let appendLine = sprintf "    %s" >> appendLine
                let writeHook (EventName en, EventHandler eh) = appendLine <| sprintf "this.%s.%s += %s;" propName en eh
                match events with
                | [] -> ()
                | x :: [] -> writeHook x
                | events ->
                    appendLine String.Empty
                    appendLine <| sprintf "// %s events" propName
                    events
                    |> List.iter(fun (EventName en,EventHandler eh) ->
                        appendLine <| sprintf "this.%s.%s += %s;" propName en eh
                    )
                    appendLine String.Empty
            )
            appendLine "}"
            appendLine "// finished with events"
            cc.Start
        | Regular (FieldChange(name,t,stop)) ->
            appendLine <| sprintf "%s// Generated (%s) (%i,%i,%i)" inClassIndent name i cc.Start stop
            appendLine <| sprintf "%s%s %s;" inClassIndent t name
            stop + 1
        | Regular (PropRemoval (_,stop)) ->
            stop + 1
        | Regular(PropSimplification(name,m,t,stop)) ->
            let appendLine = sprintf "%s%s" inClassIndent >> appendLine
            appendLine <| sprintf "%s%s %s" (match m with |Internal -> "internal " | _ -> String.Empty) t name
            appendLine "{"
            appendLine <| sprintf "    get => _%s;" name
            appendLine <| sprintf "    private set => _%s = value;" name
            appendLine "}"
            stop + 1
    )
    |> function
        | i when i < text.Length - 1 -> 
            addUpTo i (text.Length - 1)
            //[i..text.Length - 1] |> Seq.iter(fun i -> sb.AppendLine text.[i] |> ignore<StringBuilder>)
        | _ -> ()
    printfn "Finished updates!"
    let nextText = string sb
    target,nextText, {LineCount=text.Length;CharCount= text |> Seq.map (Seq.length) |> Seq.sum}, {LineCount=String.splitLines nextText |> Seq.length;CharCount=nextText.Length}

let cleanTest () =
    planCleaning (Some "pnlGFX") true target |> Option.map (clean>>fun (t,next,mOld,mNew) ->
        dump mOld |> flushDump
        dump mNew |> flushDump
        writeText t next
    )

let cleanAll()=
    getAllCsFiles()
    |> Seq.choose (planCleaning None false)
    |> Seq.map (clean >> fun (t,txt,old,clean) ->
        printfn "Took %s from %i to %i" t old.LineCount clean.LineCount
        t,txt
    )
    |> Seq.iter (uncurry writeText)
cleanTest()


flushDump()
