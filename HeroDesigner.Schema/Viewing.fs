namespace HeroDesigner.Schema.Viewing

type IControl =
    abstract SetLocation: unit -> unit
    abstract Show: unit -> unit
    abstract Activate: unit -> unit
    abstract Hide: unit -> unit

