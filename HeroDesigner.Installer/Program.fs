open System
open System.IO
open System.Windows

// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
type Model =
  { Count: int
    StepSize: int
    SelectedFolder: string
    Error: string
    Completion: int
    }

module Elm =
    let init () =
      { Count = 0
        StepSize = 1
        Completion = 0
        Error = null
        SelectedFolder = null}

type Msg =
  | Increment
  | Decrement
  | SetStepSize of int
  | SelectFolder
  | Cancel
  | Install
  | Progress

module Updates =
    let selectFolder m =
        let dlg = new System.Windows.Forms.FolderBrowserDialog()
        if dlg.ShowDialog() = Forms.DialogResult.OK then
            if Directory.Exists dlg.SelectedPath && Directory.EnumerateFiles dlg.SelectedPath |> Seq.exists(fun _ -> true) |> not then
                {m with Error=null; SelectedFolder= dlg.SelectedPath}
            else {m with Error = sprintf "Error reading target directory '%s'" dlg.SelectedPath}
        else m
    let update msg m =
        match msg with
        | Increment -> { m with Count = m.Count + m.StepSize }
        | Decrement -> { m with Count = m.Count - m.StepSize }
        | SetStepSize x -> { m with StepSize = x }
        | SelectFolder -> selectFolder m
        | Cancel ->
            Application.Current.MainWindow.Close()
            m
        | Install ->
            ()
            m
        | Progress ->
            if m.Completion < 100 then
                {m with Completion = m.Completion + 1}
            else m

module View =
    open Elmish.WPF

    let bindings model dispatch =
      [
        //"CounterValue" |> Binding.oneWay (fun m -> m.Count)
        //"Increment" |> Binding.cmd (fun m -> Increment)
        //"Decrement" |> Binding.cmd (fun m -> Decrement)
        //"StepSize" |> Binding.twoWay ((fun m -> float m.StepSize),fun newVal m -> int newVal |> SetStepSize)
        "SelectedFolder" |> Binding.oneWay (fun m -> m.SelectedFolder)
        "SelectFolder" |> Binding.cmd(fun _ -> SelectFolder)
        "Cancel" |> Binding.cmd (fun _ -> Cancel)
        "Install" |> Binding.cmd(fun _ -> Install)
        "Progress" |> Binding.oneWay (fun m -> float m.Completion)
        "Error" |> Binding.oneWay (fun m -> m.Error)
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
    //let getGradient() =
    //    getResourceByName "HeroDesigner.Installer.Gradient.png" (fun grs ->
    //        BitMap
    //    )

open Elmish
[<EntryPoint;STAThread>]
let main argv =
    printfn "%A" argv
    let result =
        Program.mkSimple Elm.init Updates.update View.bindings
        //|> Program.runWindow (Main())
        |> Elmish.WPF.Program.runWindow (View.getWindow())
    printfn "Exit Code will be %i" result
    //Console.ReadLine() |> ignore
    result
