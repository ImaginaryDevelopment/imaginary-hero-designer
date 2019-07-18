module Compression

open System.IO.Packaging

type Stream = System.IO.Stream

let copyInto (outstream : Stream,stream : Stream) =
    let bufferLen : int = 4096
    let buffer : byte array =
        if stream.Length < int64 bufferLen then
            Array.zeroCreate (int stream.Length)
        else Array.zeroCreate bufferLen
    let rec copy () =
        match stream.Read(buffer, 0, buffer.Length) with
        | count when count > 0 ->
            outstream.Write(buffer, 0, count)
            copy ()
        | _ -> ()
    copy ()

//// add or create
//// zip Path = path to the zip file to add a file to or create
//// fileToAdd = local path to the file to add
//// fileZipPath = what path the file should have inside the zip when added
//// see also https://weblogs.asp.net/albertpascual/creating-a-folder-inside-the-zip-file-with-system-io-packaging
//// or https://weblogs.asp.net/jongalloway/creating-zip-archives-in-net-without-an-external-library-like-sharpziplib?CommentPosted=true#commentmessage
//let addFileToZip zipPath fileToAdd fileZipPath =
//    use zip = System.IO.Packaging.Package.Open(path=zipPath, packageMode=FileMode.OpenOrCreate)
//    let destFilename= "." + fileZipPath  + "\\" + Path.GetFileName fileToAdd
//    let uri = PackUriHelper.CreatePartUri(System.Uri(destFilename, System.UriKind.Relative))
//    if zip.PartExists uri then
//        zip.DeletePart uri
//    let part = zip.CreatePart(uri, System.String.Empty, CompressionOption.Normal)
//    use fs = new FileStream(fileToAdd, FileMode.Open, FileAccess.Read)
//    use dest = part.GetStream()
//    copyInto(dest,fs)

open ICSharpCode.SharpZipLib.Core
open ICSharpCode.SharpZipLib.Zip
open Helpers.Files


// https://github.com/icsharpcode/SharpZipLib/wiki/Zip-Samples#unpack-a-zip-with-full-control-over-the-operation
let decompress deleteExisting archivefn outfolder =
    let mutable zf:ZipFile= null
    let buffer = Array.zeroCreate 4096
    let errors = ResizeArray()
    let success = ref 0
    try
        let fs = openRead archivefn
        zf <- new ZipFile(fs)
        zf
        |> Seq.cast<ZipEntry>
        |> Seq.iter(fun zipEntry ->
            try // allow some entries to fail but continue trying. =/
                let zipStream = zf.GetInputStream zipEntry

                let fullZipToPath = combineFp outfolder (FilePath zipEntry.Name)
                match fullZipToPath.raw |> getDirectoryName  with
                | None -> failwithf "Failed to read parent directory name of %s" fullZipToPath.raw
                | Some ((DirPath dirname) as dp) ->
                    if dirname.Length > 0 then createDirectory dp |> ignore
                    // will overwrite existing files
                    use fileOutStream = createFile fullZipToPath
                    StreamUtils.Copy(zipStream,fileOutStream,buffer)
                incr success
            with ex ->
                errors.Add <| sprintf "Failed to decompress %s into %s. %s" zipEntry.Name outfolder.raw ex.Message
        )
    finally
        if not <| isNull zf then
            zf.IsStreamOwner <- true
            zf.Close()
    if errors.Count > 0 then
        Error(List.ofSeq errors,!success)
    else Ok !success
// https://github.com/icsharpcode/SharpZipLib/wiki/Zip-Samples#create-a-zip-with-full-control-over-contents
// why doesn't the offset change based on depth?
//[<Struct>]
//type CompressionResult =
//    |UncompressedSize of int64
let compressFolder (zs:ZipOutputStream, folderoffset) =
    let rec compressfolder path : int64 =
        let totalFSz =
            getFiles path
            |> Seq.sumBy(fun fn ->
                let fi = getFileInfo fn
                let sz = fi.Length
                let entryname = fn.raw.Substring folderoffset |> ZipEntry.CleanName
                let newentry = ZipEntry entryname
                newentry.DateTime <- fi.LastWriteTime
                newentry.Size <- fi.Length
                zs.PutNextEntry newentry
                let buffer = Array.zeroCreate 4096
                use sr = openRead fn
                StreamUtils.Copy(sr,zs,buffer)
                zs.CloseEntry()
                sz
            )
        getDirectories path
        |> Seq.sumBy compressfolder
        |> (+) totalFSz
    fun dir ->
        let unc =compressfolder dir
        {Metafile.UncompressedSize=unc}


let compress (targetZipPath,src) =
    let foldername = match src with DirPath dp -> dp
    let fsOut = createFile targetZipPath
    use zs = new ZipOutputStream(fsOut)
    zs.SetLevel 4
    let folderoffset = foldername.Length + if foldername.EndsWith "\\" then 0 else 1
    let sz = compressFolder (zs, folderoffset) (DirPath foldername)
    zs.IsStreamOwner <- true
    zs.Close()
    sz
