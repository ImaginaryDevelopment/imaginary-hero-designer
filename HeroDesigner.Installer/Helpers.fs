module Helpers

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

    let combineFp (DirPath y) (FilePath fp) =
        Path.Combine(y,fp)
        |> FilePath

    let combineDp (DirPath rootier, DirPath child) = Path.Combine(rootier,child) |> DirPath
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
    let deleteFile (FilePath fp) = File.Delete fp
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
    let deleteDirectory (DirPath dp) = Directory.Delete dp
    let getFilesByPattern (DirPath dp) pattern = Directory.EnumerateFiles(dp,pattern) |> Seq.map FilePath

