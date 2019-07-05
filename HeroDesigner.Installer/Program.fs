open System
open System.IO
open System.Windows

// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
type Model =
  { Count: int
    StepSize: int }
module Elm =
    let init () =
      { Count = 0
        StepSize = 1 }
type Msg =
  | Increment
  | Decrement
  | SetStepSize of int
module Updates =
    let update msg m =
        match msg with
        | Increment -> { m with Count = m.Count + m.StepSize }
        | Decrement -> { m with Count = m.Count - m.StepSize }
        | SetStepSize x -> { m with StepSize = x }
module View =
    open Elmish.WPF

    let bindings model dispatch =
      [
        "CounterValue" |> Binding.oneWay (fun m -> m.Count)
        "Increment" |> Binding.cmd (fun m -> Increment)
        "Decrement" |> Binding.cmd (fun m -> Decrement)
        "StepSize" |> Binding.twoWay ((fun m -> float m.StepSize),fun newVal m -> int newVal |> SetStepSize)
      ]
    let getWindow() : System.Windows.Window =
        let ass = typeof<Msg>.Assembly
        let rns = ass.GetManifestResourceNames()
        let target = rns.[0]
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
    let result =
        Program.mkSimple Elm.init Updates.update View.bindings
        //|> Program.runWindow (Main())
        |> Elmish.WPF.Program.runWindow (View.getWindow())
    printfn "Exit Code will be %i" result
    Console.ReadLine() |> ignore
    result
