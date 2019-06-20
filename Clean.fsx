open System
open System.IO
let root = __SOURCE_DIRECTORY__
let writeLines (fp:string) (text:string[]) = File.WriteAllLines(path=fp,contents=text)
Directory.GetFiles(root,"*.cs",SearchOption.AllDirectories)
|> Seq.iter(fun fp ->
    // a peek rather than reading the entire file into memory would be nice
    let text = File.ReadAllLines fp
    if text.[0] = "// Decompiled with JetBrains decompiler" then
        text
        |> Array.skipWhile(fun line ->
            line = "// Decompiled with JetBrains decompiler"
            || line.StartsWith "// Type: "
            || line.StartsWith "// Assembly: "
            || line.StartsWith "// MVID: "
            || line.StartsWith "// Assembly location:"
        )
        |> writeLines fp
)
