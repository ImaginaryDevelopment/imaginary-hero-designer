module Compression

open System.IO
open System.IO.Packaging
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

// https://github.com/icsharpcode/SharpZipLib/wiki/Zip-Samples#unpack-a-zip-with-full-control-over-the-operation
let decompress archivefn outfolder =
    let mutable zf:ZipFile= null
    try
        let fs = File.OpenRead archivefn
        zf <- new ZipFile(fs)
        zf
        |> Seq.cast<ZipEntry>
        |> Seq.iter(fun zipEntry ->
            let buffer = Array.zeroCreate 4096
            let zipStream = zf.GetInputStream zipEntry
            let fullZipToPath = Path.Combine(outfolder, zipEntry.Name)
            let dirname = Path.GetDirectoryName fullZipToPath
            if dirname.Length > 0 then Directory.CreateDirectory dirname |> ignore<DirectoryInfo>
            use sw = File.Create fullZipToPath
            StreamUtils.Copy(zipStream,sw,buffer)
            ()
        )
    finally
        if not <| isNull zf then
            zf.IsStreamOwner <- true
            zf.Close()
    ()
// https://github.com/icsharpcode/SharpZipLib/wiki/Zip-Samples#create-a-zip-with-full-control-over-contents
// why doesn't the offset change based on depth?
let compressFolder (path, zs:ZipOutputStream, folderoffset) =
    let rec compressfolder path =
        Directory.GetFiles path
        |> Seq.iter(fun fn ->
            let fi = FileInfo(fn)
            let entryname = fn.Substring folderoffset |> ZipEntry.CleanName
            let newentry = ZipEntry entryname
            newentry.DateTime <- fi.LastWriteTime
            newentry.Size <- fi.Length
            zs.PutNextEntry newentry
            let buffer = Array.zeroCreate 4096
            use sr = File.OpenRead fn
            StreamUtils.Copy(sr,zs,buffer)
            zs.CloseEntry()
        )
        Directory.GetDirectories path
        |> Seq.iter  compressfolder
    compressfolder path


let compress (outpath,foldername:string) =
    let fsOut = File.Create outpath
    use zs = new ZipOutputStream(fsOut)
    zs.SetLevel 4
    let folderoffset = foldername.Length + if foldername.EndsWith "\\" then 0 else 1
    compressFolder(foldername,zs, folderoffset)
    zs.IsStreamOwner <- true
    zs.Close()
