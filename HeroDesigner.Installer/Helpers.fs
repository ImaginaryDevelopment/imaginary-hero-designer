module Helpers

let trim (x:string) = x.Trim()
let trim1 chars (x:string) = x.Trim(chars)
//let map f =
//    function
//    | Ok x -> f x |> Ok
//    | Error e -> Error e
//let bind f =
//    function
//    | Ok x -> f x
//    | Error e -> Error e
let (|Before|_|) (delimiter:string) =
    function
    | null | "" -> None
    | x ->
        match delimiter with
        | null
        | "" -> failwithf "delimiter was null or empty"
        | _ ->
            let i = x.IndexOf(delimiter)
            if i < 0 then None
            else Some x.[0..i - 1]
let before (delimiter:string) =
    function
    | Before delimiter x -> 
        Some x
    | _ -> None
module Serialization =
    open Newtonsoft.Json
    let serialize<'t>(x:'t) =
        JsonConvert.SerializeObject(x, Formatting.Indented)

    let deserialize<'t>(x:string) =
        JsonConvert.DeserializeObject<'t>(x)
module Files =
    open System.IO
    type DirPath = DirPath of string with
        member x.raw = match x with | DirPath v -> v
    type FilePath = FilePath of string with
        member x.raw = match x with |FilePath fp -> fp
    type ParentChildArgs<'t> = {Parent:DirPath;Child:'t}

    // either file or directory
    // File System Path
    // gives no guarantees, just shows intent
    //type FsPath = | FsPath of string |FsDirPath of DirPath | FsFilePath of FilePath with
    //    static member GetValue = function |FsPath x -> x | FsDirPath(DirPath dp) -> dp | FsFilePath (FilePath fp) -> fp

    let (|FileExists|_|) fp =
        if File.Exists fp then
            Some (FilePath fp)
        else None
    let (|DirectoryExists|_|) dp =
        if Directory.Exists dp then
            Some (DirPath dp)
        else None

    let writeAllText (FilePath path) text = File.WriteAllText(path=path,contents=text)

    let readAllText (FilePath path) = File.ReadAllText(path)

    let inline combineFp (DirPath y) (FilePath fp) =
        try
            Path.Combine(y,fp)
            |> FilePath
        with _ ->
            eprintfn "Failed to combine y: '%s' with fp: '%s'" y fp
            reraise()

    let combineDp {Parent=DirPath rootier;Child= DirPath child} = Path.Combine(rootier,child) |> DirPath
    let combineAny (DirPath parent) child = Path.Combine(parent,child)

    let getFileInfo (FilePath fp) = FileInfo fp
    let getLength (FilePath fp) = FileInfo(fp).Length
    let openRead (FilePath fp) = File.OpenRead fp
    let getFiles (DirPath dp) =
        Directory.EnumerateFiles dp
        |> Seq.map FilePath
    let getDirectories (DirPath dp) =
        Directory.EnumerateDirectories dp
        |> Seq.map DirPath

    let getFullPath x = Path.GetFullPath x
    let getFullDirPath (DirPath dp) = getFullPath dp |> DirPath
    let fileExists (FilePath fp) = File.Exists fp
    let dirExists (DirPath dp) = Directory.Exists dp
    let deleteFile (FilePath fp) = File.Delete fp
    let moveFile dpsrc dptarget fp =
        let (FilePath targetfp) = combineFp dptarget fp
        let (FilePath srcfp) = combineFp dpsrc fp
        File.Move(srcfp, targetfp)

    let containsFile dp fp = combineFp dp fp |> fileExists
    // works for either type, maybe don't wrap this one
    // returns null when you try to get GetDirName of the root dir
    let getDirectoryName x = Path.GetDirectoryName x |> function | null -> None | x -> Some (DirPath x)
    let getFileDirectoryName (FilePath fp) =
        getDirectoryName fp
        |> function
            |None -> failwithf "Getting the parent dirctory of a file should never fail, target path: '%s'" fp
            | Some x -> x
    let createDirectory (DirPath dp) = Directory.CreateDirectory dp
    let createFile (FilePath fp) = File.Create fp
    let deleteDirectory (DirPath dp) = Directory.Delete(dp,true)
    let getFilesRecursive (DirPath dp) =
        Directory.EnumerateFiles(dp, "*", SearchOption.AllDirectories)
        |> Seq.map FilePath
    let filterEndings excludedEndings  =
            Seq.filter(fun (FilePath fp) ->
                excludedEndings
                |> Set.exists(fp.EndsWith)
                |> not
            )
    let clearEmpties dp =
        let rec clear dp =
            getDirectories dp
            |> Seq.iter clear
            if Seq.isEmpty <| getDirectories dp && Seq.isEmpty <| getFiles dp then
                deleteDirectory dp
        getDirectories dp
        |> Seq.iter clear

    // remove all files and folders
    let clearDirectory excludedEndings dp =
        getFilesRecursive dp
        |> filterEndings excludedEndings
        |> Seq.iter deleteFile
        clearEmpties dp

    let getFilesByPattern (DirPath dp) pattern = Directory.EnumerateFiles(dp,pattern) |> Seq.map FilePath
    let makeTempDir (childname:string) =
        let dp = combineAny (DirPath <| Path.GetTempPath()) childname
        Directory.CreateDirectory dp |> ignore
        DirPath dp
    // get all files inside the directory and relocate them, returning where they went
    let moveDirContents excludedEndings srcdp targetdp =
        let rec move srcdp targetdp =
            if not <| dirExists targetdp then
                createDirectory targetdp |> ignore
            getFiles srcdp
            |> Seq.filter(fun (FilePath fp) ->
                excludedEndings
                |> Set.exists(fp.EndsWith)
                |> not
            )
            |> Seq.iter(moveFile srcdp targetdp)
            getDirectories srcdp
            |> Seq.iter(fun (DirPath srcdp' as srcdp) ->
                match getDirectoryName srcdp' |> Option.map (fun child -> combineDp {Parent=targetdp;Child=child}) with
                | None -> failwithf "Getting parent dir of %s failed" srcdp'
                | Some targetdp ->
                    move srcdp targetdp
            )
        move srcdp targetdp

