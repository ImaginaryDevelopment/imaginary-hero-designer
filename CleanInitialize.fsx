open System.Text.RegularExpressions
#load "Reusable.fsx"
open Reusable

let target = @"D:\Projects\imaginary-hero-designer\Hero Designer\Forms\frmMain.Designer.cs"

type InitSearchState =
    |NotStarted
    |Started of methodIndent:int
    |ConstructionsCompleted of methodIndent:int * currentvar:string option
    |Done

// if we are in the init, we'll have Some i where i is the indent level to match with the }
type State = {Iss:InitSearchState;Lines:string list}
let initR = Regex @"void\s+InitializeComponent"
let varR = Regex @"^(\s+)// (\w+)$"
let assignR = Regex @"^(\s+)this\.(\w+)\.\w+"
let closeR = Regex @"^(\s*)}\s*$"
let stopR = Regex @"^(\s*)this\.Controls\.Add"
let finishConstruction = Regex @"^(\s+)this.SuspendLayout\(\);\s*$"
({Iss=NotStarted;Lines=List.empty},readLines target |> withIndexes)
||> Seq.fold(fun x (li,line) ->
    let copyLine () = line::x.Lines
    let addHeader i name =
        let indent = String.replicate (i+4) " "
        [ sprintf "%s// " indent;sprintf "%s// %s"indent name;sprintf "%s// " indent]
    let justCopyLine() = {x with Lines=copyLine()}
    match x.Iss, line with
    | NotStarted, RMatch initR _ ->
        {x with Lines=copyLine();Iss=line |> Seq.takeWhile System.Char.IsWhiteSpace |> Seq.length |> Started}
    | NotStarted, _ -> justCopyLine()
    // remove extra empty lines inside the init
    | Started _, NonValueString _ -> x
    // finishing before construction completed
    | Started i, RMatch closeR m when m.Groups.[1].Length = i -> {Iss=Done;Lines=copyLine()}
    | Started i, RMatch finishConstruction _ -> {Lines=copyLine();Iss=ConstructionsCompleted(i,None)}
    | Started _, _ -> justCopyLine()
    | Done, _ -> justCopyLine()
    | ConstructionsCompleted _, RMatch stopR _ -> {Lines=copyLine();Iss=Done}
    | ConstructionsCompleted _, NonValueString _ -> x
    // matches when we already have a comment var section
    | ConstructionsCompleted(i,_), RMatch varR m ->
        let v = getGroupValue 2 m
        printfn "Found a var! %s on %i" v li
        {Lines=copyLine();Iss=ConstructionsCompleted(i,Some v)}
    | ConstructionsCompleted(i,None), RMatch assignR m ->
        let v = getGroupValue 2 m
        printfn "Adding header for %s on %i" v li
        {Lines=line::(addHeader i v)@x.Lines;Iss=ConstructionsCompleted(i,Some v)}
    | ConstructionsCompleted(_,Some n), RMatch assignR m when n = getGroupValue 2 m -> justCopyLine()
    | ConstructionsCompleted(i,Some _), RMatch assignR m ->
        let v = getGroupValue 2 m
        printfn "Adding header for %s on %i" v li
        {Lines=line::(addHeader i v)@x.Lines;Iss=ConstructionsCompleted(i,Some v)}
    | ConstructionsCompleted _, _ ->
        justCopyLine()
)
|> fun x -> x.Lines
|> List.rev
|> Array.ofList
|> writeLines target
