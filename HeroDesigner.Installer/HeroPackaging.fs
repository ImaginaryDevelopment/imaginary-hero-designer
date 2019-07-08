module HeroPackaging
let packageFilename = "binaries.zip"
open Helpers.Files
let formatSize sz =
    let sizes = [ "B"; "KB"; "MB"; "GB"; "TB" ]
    let mutable order = 0
    // we're throwing away the fractions
    let mutable len = sz
    while(len >= 1024L && order < sizes.Length - 1) do
        order <- order + 1
        len <- len / 1024L
    System.String.Format("{0:0.##} {1}", len, sizes.[order])

let createInstaller binaryFolderPath zipTargetPath =
    printfn "Zipping to %A" zipTargetPath
    if fileExists zipTargetPath then
        deleteFile zipTargetPath
    let meta = Compression.compress(zipTargetPath,binaryFolderPath)
    Metafile.writeMeta(getFileDirectoryName zipTargetPath) meta
// delete all children AND self
let deleteDirectory p =
    let rec dd p =
        getDirectories p
        |> Seq.iter dd
        getFiles p
        |> Seq.iter deleteFile
        deleteDirectory p
    dd p
open Metafile
// create a fresh installer
// return the metadata
type BinaryZipInfo = {ZipFilePath:FilePath;Meta:Metadata}
type AutoCreateResult =
    |Created of BinaryZipInfo
    |NotCreated of BinaryZipInfo
    |CouldNotCreateOrFind of error:string

let autoCreate() =
    let path = DirPath "../../../Hero Designer/bin/Debug/"
    let fp = getFullDirPath path
    let zipTargetPath = combineFp(DirPath System.Environment.CurrentDirectory)(FilePath packageFilename)
    let created =
        if fileExists <| combineFp path (FilePath "Hero Designer.exe") then
            printfn "Creating zip from %s" fp.raw
            ()
            // clean up publish files/folder, not needed
            [
                "app.publish"
                "Hero Designer.application"
                "Hero Designer.exe.manifest"
            ]
            |> Seq.map (combineAny path)
            |> Seq.map getFullPath
            |> Seq.iter(
                function
                | FileExists fp -> deleteFile fp
                | DirectoryExists dp -> deleteDirectory dp
                | _ -> () // don't need to clean up what isn't there
            )
            // clean up wildcards
            [
                "*.zip"
                "*.xml"
            ]
            |> List.iter(fun wc ->
                getFilesByPattern fp wc
                |> Seq.iter deleteFile
            )
            createInstaller fp zipTargetPath
            true
        else false
    if not <| fileExists zipTargetPath then
        failwithf "Unable to locate binaries at '%s'" <| getFullPath zipTargetPath.raw
    match getDirectoryName zipTargetPath.raw with
    | None -> failwithf "Unable to read parent directory of '%s'" zipTargetPath.raw
    | Some metaDir ->
        Metafile.readMeta metaDir
        |> function
            | Ok m ->
                let md = {Meta = m; ZipFilePath = zipTargetPath }
                let result =
                    if created then
                        Created md
                    else AutoCreateResult.NotCreated md
                result
            | Error e ->
                CouldNotCreateOrFind e


type StreamWriter = System.IO.StreamWriter

let createAppShortcutToDesktop exepath linkName =
    let dp = System.Environment.GetFolderPath System.Environment.SpecialFolder.DesktopDirectory |> DirPath
    let path = combineFp dp (FilePath (linkName + ".url"))
    use sw = new StreamWriter(path.raw)
    sw.WriteLine("[InternetShortcut]")
    sw.WriteLine("URL=file:///" + exepath)
    sw.WriteLine("IconIndex=0")
    let icon = exepath.Replace('\\','/')
    sw.WriteLine("IconFile= " + icon)
    sw.Flush()
