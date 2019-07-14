open System
open System.Windows
open System.IO
open Helpers.Files

// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
type Model =
  { Count: int
    StepSize: int
    SelectedFolder: string
    Error: string
    Completion: int
    InstallerSize: string
    }

module Elm =
    let init installerSize () =
      { Count = 0
        StepSize = 1
        Completion = 0
        Error = null
        InstallerSize = installerSize
        SelectedFolder = null}

type Msg =
  | Increment
  | Decrement
  | SetStepSize of int
  | SelectFolder
  | Cancel
  | Install
  | Progress
  | ZipInstaller

module Updates =
    let map f =
        function
        | Ok x -> f x |> Ok
        | Error e -> Error e
    let bind f =
        function
        | Ok x -> f x
        | Error e -> Error e

    let parentIs ending x =
        let parent = Path.GetDirectoryName x
        if parent.EndsWith ending then Ok parent
        else Error <| sprintf "Parent should have been bin, but was %s" parent
    let selectFolder m =
        let dlg = new System.Windows.Forms.FolderBrowserDialog()
        if dlg.ShowDialog() = Forms.DialogResult.OK then
            if Directory.Exists dlg.SelectedPath && Directory.EnumerateFiles dlg.SelectedPath |> Seq.exists(fun _ -> true) |> not then
                {m with Error=null; SelectedFolder= dlg.SelectedPath}
            else {m with Error = sprintf "Error reading target directory '%s'" dlg.SelectedPath}
        else m
    let quit() = Application.Current.MainWindow.Close()
    let update msg m =
        match msg with
        | Increment -> { m with Count = m.Count + m.StepSize }
        | Decrement -> { m with Count = m.Count - m.StepSize }
        | SetStepSize x -> { m with StepSize = x }
        | SelectFolder -> selectFolder m
        | ZipInstaller ->
            if not System.Diagnostics.Debugger.IsAttached then
                { m with Error="Bad state for zip installer"}
            else
                let here = Environment.CurrentDirectory
                Ok here
                |> bind (parentIs "bin")
                |> bind (parentIs "HeroDesigner.Installer")
                |> map Path.GetDirectoryName
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
            let inputPath = Path.Combine(Environment.CurrentDirectory, HeroPackaging.packageFilename)
            if not <| File.Exists inputPath then
                {m with Error = sprintf "Unable to locate installer files at %s" inputPath}
            else
                let proceed completed =
                    let exePath = Path.Combine(m.SelectedFolder, "Hero Designer.exe")
                    if File.Exists exePath then
                        if completed then
                            MessageBox.Show("Installation completed") |> ignore
                        // add shortcut(s)
                        // launch app
                        System.Diagnostics.Process.Start(exePath) |> ignore<System.Diagnostics.Process>
                        if completed then
                            quit()
                        m
                    else
                        {m with Error= sprintf "Install finished, but application was not found at '%s'" exePath}
                let env = Environment.NewLine
                match Compression.decompress (FilePath inputPath) (DirPath m.SelectedFolder) with
                | Error(errors,successes) when successes > 0 ->
                    match MessageBox.Show("There were errors, attempt launch?"::(sprintf "%i files succeeded%s" successes env)::errors |> String.concat env,"Installation problem", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) with
                    | MessageBoxResult.Yes -> proceed false
                    | _ -> {m with Error= "Installation Cancelled"}
                | Error(errors, _) ->
                    MessageBox.Show("There were errors, no files succeeded to extract"::errors |> String.concat env, "Installation failed", MessageBoxButton.OK, MessageBoxImage.Error) |> ignore
                    {m with Error= "Installation failed"}

                | Ok _ -> proceed true
        | Progress ->
            if m.Completion < 100 then
                {m with Completion = m.Completion + 1}
            else m

module View =
    open Elmish.WPF

    let bindings model dispatch =
      [
        "SelectedFolder" |> Binding.oneWay (fun m -> m.SelectedFolder)
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
            let init =
                HeroPackaging.formatSize m.Meta.UncompressedSize
                |> Elm.init
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

        
