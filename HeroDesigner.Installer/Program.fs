open System
open System.Windows
open System.IO
open Helpers
open Helpers.Files

// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
type Model =
  { Count: int
    StepSize: int
    SelectedFolder: DirPath option
    Error: string
    Completion: int
    InstallerSize: string
    }

module Elm =
    let init selectedFolderOpt installerSize () =
      { Count = 0
        StepSize = 1
        Completion = 0
        Error = null
        InstallerSize = installerSize
        SelectedFolder = selectedFolderOpt}

type Msg =
  | Increment
  | Decrement
  | SetStepSize of int
  | SelectFolder
  | Cancel
  | Install
  | Progress
  | ZipInstaller

module Impl =
    type UninstallResult =
        |NotInstalledHere
        // relocate in case install fails, we'll try to put things back
        //|Relocated of tempPath:DirPath
        |Removed
        // did not find exe, might be something else in this folder, do not install
        |InvalidContents
    type DecompressResult = |Complete |Incomplete
    let isOldInstallDir dp =
        [
            "Hero Designer.exe"
            "midsControls.dll"
        ] |> Seq.exists(FilePath >> containsFile dp)
    // only handles removing things for the new install
    let uninstall dp =
        if dirExists dp then
            if isOldInstallDir dp  then
                let targetdp = makeTempDir "Mids.old"
                moveDirContents (Set[".mxd"]) dp targetdp
                deleteDirectory dp
                //Relocated targetdp
                Removed
            elif getFiles dp |> Seq.exists(fun _ -> true) then
                InvalidContents
            else NotInstalledHere
        else NotInstalledHere
    let parentIs ending x =
        let parent = Path.GetDirectoryName x
        if parent.EndsWith ending then Ok parent
        else Error <| sprintf "Parent should have been bin, but was %s" parent
    let selectFolder () =
        let selectedPath =
            use dlg = new System.Windows.Forms.FolderBrowserDialog()
            if dlg.ShowDialog() = Forms.DialogResult.OK then
                Some dlg.SelectedPath
            else None
        selectedPath
        |> Option.map(
                function
                |DirectoryExists (DirPath path as dp) ->
                    if dirExists dp then
                        let isEmpty = getFiles dp |> Seq.exists(fun _ -> true) |> not 
                        if isEmpty || isOldInstallDir dp then
                            Ok dp
                        else Error <| sprintf "Error reading target directory '%s'" path
                    else Error <| sprintf "Error target directory does not exist '%s'" path
                |path -> Error <| sprintf "Error target directory does not exist '%s'" path
            )
    let decompress (FilePath archivePath) installpath:Result<DecompressResult, string> =
        let env = Environment.NewLine
        match Compression.decompress true (FilePath archivePath) installpath with
        | Error(errors,successes) when successes > 0 ->
            match MessageBox.Show("There were errors, attempt launch?"::(sprintf "%i files succeeded%s" successes env)::errors |> String.concat env,"Installation problem", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) with
            | MessageBoxResult.Yes -> Ok DecompressResult.Incomplete
            | _ -> Error "Installation Cancelled"
        | Error(errors, _) ->
            MessageBox.Show("There were errors, no files succeeded to extract"::errors |> String.concat env, "Installation failed", MessageBoxButton.OK, MessageBoxImage.Error) |> ignore
            Error "Installation failed"
        | Ok _ -> Ok DecompressResult.Complete
    let quit() = Application.Current.MainWindow.Close()
    let proceed installpath completed:Result<_,_> =
        let (FilePath exePath' as exePath) = combineFp installpath (FilePath "Hero Designer.exe")
        if fileExists exePath then
            if completed then
                MessageBox.Show("Installation completed") |> ignore
            // add shortcut(s)
            // launch app
            System.Diagnostics.Process.Start exePath' |> ignore<System.Diagnostics.Process>
            if completed then
                quit()
            Ok()
        else
            Error <| sprintf "Install finished, but application was not found at '%s'" exePath'
module Updates =
    let update msg m =
        match msg with
        | Increment -> { m with Count = m.Count + m.StepSize }
        | Decrement -> { m with Count = m.Count - m.StepSize }
        | SetStepSize x -> { m with StepSize = x }
        | SelectFolder ->
            Impl.selectFolder()
            |> Option.map(
                function
                |Ok dp -> {m with Error = null; SelectedFolder = Some dp}
                |Error e -> {m with Error = e; SelectedFolder = None}
            )
            |> Option.defaultValue m
        | ZipInstaller ->
            if not System.Diagnostics.Debugger.IsAttached then
                { m with Error="Bad state for zip installer"}
            else
                let here = Environment.CurrentDirectory
                here
                |> Impl.parentIs "bin"
                |> Result.bind (Impl.parentIs "HeroDesigner.Installer")
                |> Result.map Path.GetDirectoryName
                |> function
                    |Ok targetDir ->
                        let dtPart = DateTime.Today
                        let fn = Path.Combine(targetDir,sprintf "HeroDesignerInstaller.F%i.%02i.%02i.00.zip" dtPart.Year dtPart.Month dtPart.Day)
                        Compression.compress(FilePath fn,DirPath here) |> ignore
                        MessageBox.Show(sprintf "Compressed to %s" fn) |> ignore
                        System.Diagnostics.Process.Start(targetDir) |> ignore
                        m
                    |Error e ->
                        {m with Error=e}
        | Cancel ->
            Application.Current.Shutdown(0)
            m
        | Install ->
            match m.SelectedFolder with
            | None -> { m with Error = "No Path selected"}
            | Some installpath ->
                let inputPath = Path.Combine(Environment.CurrentDirectory, HeroPackaging.packageFilename)
                if not <| File.Exists inputPath then
                    {m with Error = sprintf "Unable to locate installer files at %s" inputPath}
                else
                    Impl.uninstall installpath
                    |> function
                        |Impl.NotInstalledHere -> Ok ()
                        |Impl.Removed -> Ok ()
                        //|Relocated tempPath -> Ok (Some tempPath)
                        |Impl.InvalidContents -> Error "Selected path does not look like an empty folder or previous installation of Mids"
                    |> Result.bind(fun () ->
                        Impl.decompress (FilePath inputPath) installpath
                        |> function
                            |Ok Impl.DecompressResult.Complete -> Impl.proceed installpath true
                            |Ok Impl.DecompressResult.Incomplete -> Impl.proceed installpath false
                            |Error e -> Error e
                        )
                    |> function
                        |Ok () -> { m with Error = null;SelectedFolder = None}
                        |Error e -> {m with Error = e}
                    |> id
        | Progress ->
            if m.Completion < 100 then
                {m with Completion = m.Completion + 1}
            else m

module View =
    open Elmish.WPF

    let bindings model dispatch =
      [
        "SelectedFolder" |> Binding.oneWay (fun m -> m.SelectedFolder |> Option.map(fun (DirPath dp) -> dp) |> Option.defaultValue String.Empty)
        "SelectFolder" |> Binding.cmd(fun _ -> SelectFolder)
        "Cancel" |> Binding.cmd (fun _ -> Cancel)
        "Install" |> Binding.cmd(fun _ -> Install)
        "ZipInstaller" |> Binding.cmd (fun _ -> ZipInstaller)
        "Progress" |> Binding.oneWay (fun m -> float m.Completion)
        "Error" |> Binding.oneWay (fun m -> m.Error)
        "InstallerSize" |> Binding.oneWay (fun m -> m.InstallerSize)
        "ShowZip" |> Binding.oneWay(fun _ -> if System.Diagnostics.Debugger.IsAttached then Visibility.Visible else Visibility.Collapsed)
      ]
    let getResourceByName name f =
        let ass = typeof<Msg>.Assembly
        let rns = ass.GetManifestResourceNames()
        use grs = ass.GetManifestResourceStream(name=name)
        f grs
    let getWindow() : System.Windows.Window =
        let ass = typeof<Msg>.Assembly
        let rns = ass.GetManifestResourceNames()
        let target = rns |> Seq.find(fun r -> r.EndsWith("Main.xaml"))
        let text =
            use grs = ass.GetManifestResourceStream(target)
            use sr = new StreamReader(grs)
            sr.ReadToEnd()
        let xr = System.Windows.Markup.XamlReader.Parse text :?> Window
        xr

open Elmish
[<EntryPoint;STAThread>]
let main argv =
    printfn "%A" argv
    match HeroPackaging.autoCreate() with
    | HeroPackaging.AutoCreateResult.Created m
    | HeroPackaging.AutoCreateResult.NotCreated m ->
        Ok m
    
    | HeroPackaging.CouldNotCreateOrFind e -> Error e
    |> function
        |Ok m ->
            let selectedFolder =
                Registry.getOpenCommand()
                |> Option.bind (before "\"%1\"")
                |> Option.map trim
                |> Option.map(Array.singleton '\"' |> trim1)
                |> Option.bind(fun x -> if File.Exists x then Some x else None)
                |> Option.bind getDirectoryName
            let init =
                HeroPackaging.formatSize m.Meta.UncompressedSize
                |> Elm.init selectedFolder
            let result =
                Program.mkSimple init Updates.update View.bindings
                //|> Program.runWindow (Main())
                |> Elmish.WPF.Program.runWindow (View.getWindow())
            printfn "Exit Code will be %i" result
            //Console.ReadLine() |> ignore
            result
        |Error e ->
            MessageBox.Show(e,"Instaler failed to initialize", MessageBoxButton.OK, MessageBoxImage.Error)
            |> ignore
            1

        
