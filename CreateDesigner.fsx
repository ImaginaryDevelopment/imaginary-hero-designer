#load "Reusable.fsx"
open Reusable
let createDesignerItemText relPath name =
    sprintf """    <Compile Include="%s">
      <DependentUpon>%s.cs</DependentUpon>
    </Compile>
"""
        relPath name

let createDesigner fullpath ns name init fields =
    let preamble ns name =
        sprintf """
    namespace %s
    {
        public partial class %s
        {
            /// <summary>
            /// Required designer variable.
            /// </summary>
            private System.ComponentModel.IContainer components = null;

            /// <summary>
            /// Clean up any resources being used.
            /// </summary>
            /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
            protected override void Dispose(bool disposing)
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }

            #region Windows Form Designer generated code

            /// <summary>
            /// Required method for Designer support - do not modify
            /// the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
                this.components = (System.ComponentModel.IContainer)new System.ComponentModel.Container();
    """
            ns name

    let postAmble init fields =
        sprintf """
    %s
            }
    %s

            #endregion
        }
    }"""
            init fields
    sprintf "%s%s" (preamble ns name) (postAmble init fields)
    |> writeText fullpath

type InitState =
    |NotFound
    |Done
    |Progressing of indent:int*startLine:int

type ExtractionResult = {RegularLinesRev:string list;InitLinesRev:string list}
type ExtractionState = {InitState:InitState;Result:ExtractionResult}

let extractInitialize title (lines:string[]) =
    let addInitLine line (r:ExtractionResult) = line::r.InitLinesRev
    let addRegLine line (r:ExtractionResult) = line::r.RegularLinesRev
    let lensRegLine line r = {r with RegularLinesRev= addRegLine line r}
    let lensInitLine line r = {r with InitLinesRev= addInitLine line r}
    let lensResult (r:ExtractionResult) (s:ExtractionState) : ExtractionState  = {s with Result=r}
    let lensInitLineS line (x:ExtractionState) : ExtractionState = x.Result |> lensInitLine line |> flip lensResult x
    let lensRegLineS line (x:ExtractionState) : ExtractionState = x.Result |> lensRegLine line |> flip lensResult x

    ({Result={RegularLinesRev=List.empty;InitLinesRev=List.empty};InitState=NotFound}, lines |> withIndexes)
    ||> Seq.fold(fun state (i,line) ->
        match state.InitState with
        | NotFound when line.Contains("void InitializeComponent(") ->
            if state.Result.InitLinesRev.Length > 0 then failwithf "Found init component at %i when %i line(s) already exist in %s" i state.Result.InitLinesRev.Length title
            {InitState=Progressing(line.Length - (line.TrimStart().Length),i);Result={state.Result with InitLinesRev=List.singleton line}}
        | NotFound 
        | Done -> lensRegLineS line state
        | Progressing (i,_) when line.Trim() = "}" && line.TrimEnd().Length - 1 = i ->
            {state with InitState=Done;Result=lensInitLine line state.Result}
        | Progressing _ ->
            lensInitLineS line state
    )
    |> fun x -> x.Result
    |> fun x ->
        let added = x.InitLinesRev.Length + x.RegularLinesRev.Length
        if added <> lines.Length then
            failwithf "Failed to pull apart %s: %i + %i = %i <> %i" title x.InitLinesRev.Length x.RegularLinesRev.Length added lines.Length
        x

open System.IO

let getDesignerlessForms () =
    getAllCsFiles()
    |> Seq.choose(fun fp ->
        let dp = Path.Combine(Path.GetDirectoryName fp,Path.GetFileNameWithoutExtension fp + ".Designer.cs")
        if 
            not <| fp.EndsWith(".Designer.cs")
            && not <| File.Exists dp
        then
            Some (fp,dp)
        else None
    )
    |> Seq.choose(fun (fp,dp) ->
        let text = readLines fp
        text |> Seq.tryFind(fun x -> x.Trim().Contains(": Form"))
        |> Option.map(fun _ ->
            fp,text,dp
        )
    )
()
let addDesignerItem pp relative name =
    let text = createDesignerItemText relative name
    ((List.empty,false),readLines pp |> withIndexes)
    ||> Seq.fold(fun (lines,added) (i,line) ->
        if added then (line::lines,true)
        elif line.Contains("<ItemGroup>") then
            text::line::lines,true
        else (line::lines,false)
    )
    |> fun (lines,added) ->
        if not added then failwithf "Could not add %s designer to %s" name pp
        lines
    |> List.rev
    |> String.concat "\r\n"
    |> writeText pp
getDesignerlessForms()
|> Seq.map(fun (fp, lines,dp) ->
    let name = Path.GetFileNameWithoutExtension fp
    match findParentCsProject fp with
    | None -> failwithf "Couldn't find parent cs project for %s" fp
    | Some pp ->
        let relative = getRelativePath {Source=pp;TargetPath=dp}
        if(relative.Contains(".cs\\")) || not <| File.Exists(Path.Combine(relative,fp)) then failwithf "Bad relative path made (%s,%s,%s)" relative pp fp
        printfn "Made relative %s" relative
        addDesignerItem pp relative name


    let x = extractInitialize fp lines
    (fp, x.RegularLinesRev |> List.rev),(dp,x.InitLinesRev |> List.rev)
)
|> Seq.iter(fun ((fp,lines),(dp,inits)) ->
    let name = Path.GetFileNameWithoutExtension fp |> Path.GetFileNameWithoutExtension
    createDesigner dp "Hero_Designer" name (String.concat "\r\n" inits) System.String.Empty
    writeText fp (String.concat "\r\n" lines)
)
//|> Seq.length
