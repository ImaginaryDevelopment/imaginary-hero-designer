namespace HeroDesigner.Schema
open System

type RawSaveResult = {Length:int;Hash:int}

type FHash = {
    Archetype:string
    Fullname:string
    Hash:int
    Length:int
}

type HistoryMap() =
    member val Level = -1 with get,set
    member val HID = -1 with get,set
    member val SID = -1 with get,set
    member val Text = String.Empty with get,set
