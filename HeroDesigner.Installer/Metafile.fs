module Metafile
open Helpers.Serialization
open Helpers.Files

// a filename type may be better here but eh, let's stop here
let fn = FilePath "meta.json"
type Metadata = {UncompressedSize:int64}
let writeMeta dir (md:Metadata) =
    let fp = combineFp dir fn
    serialize md
    |> writeAllText fp

let readMeta dir =
    let fp = combineFp dir fn
    if fileExists fp then
        readAllText fp
        |> deserialize<Metadata>
        |> Ok
    else Error (sprintf "Metafile File not found at '%s'" <| getFullPath fp.raw)

let metaExists dir =
    combineFp dir fn
    |> fileExists

