module HeroPackaging
open System.IO
let packageFilename = "binaries.zip"
let createInstaller binaryFolderPath =
    let zipTargetPath = Path.Combine(System.Environment.CurrentDirectory,packageFilename)
    printfn "Zipping to %s" zipTargetPath
    if File.Exists zipTargetPath then
        File.Delete zipTargetPath
    Compression.compress(zipTargetPath,binaryFolderPath)
// delete all children AND self
let deleteDirectory p =
    let rec dd p =
        Directory.EnumerateDirectories p
        |> Seq.iter dd
        Directory.EnumerateFiles p
        |> Seq.iter File.Delete
        Directory.Delete p
    dd p
let autoCreate() =
    let path = "../../../Hero Designer/bin/Debug/"
    if File.Exists <| Path.Combine(path,"Hero Designer.exe") then
        let fp = Path.GetFullPath path
        printfn "Creating zip from %s" fp
        ()
        // clean up publish files/folder, not needed
        [
            "app.publish"
            "Hero Designer.application"
            "Hero Designer.exe.manifest"
        ]
        |> Seq.map (fun p -> Path.Combine(path,p))
        |> Seq.map Path.GetFullPath
        |> Seq.iter(fun p ->
            if File.Exists p then
                File.Delete p
            elif Directory.Exists p then
                deleteDirectory p
        )
        // clean up wildcard
        Directory.GetFiles(fp,"*.zip|*.xml")
        |> Seq.iter File.Delete
        createInstaller fp
        Some fp
    else None

let createAppShortcutToDesktop exepath linkName =
    let dp = System.Environment.GetFolderPath System.Environment.SpecialFolder.DesktopDirectory
    use sw = new StreamWriter(Path.Combine(dp,linkName + ".url"))
    sw.WriteLine("[InternetShortcut]")
    sw.WriteLine("URL=file:///" + exepath)
    sw.WriteLine("IconIndex=0")
    let icon = exepath.Replace('\\','/')
    sw.WriteLine("IconFile= " + icon)
    sw.Flush()
