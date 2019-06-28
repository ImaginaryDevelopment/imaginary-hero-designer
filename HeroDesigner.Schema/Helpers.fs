module HeroDesigner.Schema.Helpers

    module Array =
        let removeIndex i = Array.mapi(fun i x -> (i,x)) >> Array.filter(fst >> (<>) i) >> Array.map snd
    module DUs =
        let getLength<'t> = FSharp.Reflection.FSharpType.GetUnionCases(typeof<'t>).Length
    module Enums =
        let getLength<'t,'t2 when 't: enum<'t2>>() = System.Enum.GetValues(typeof<'t>).Length
        let unsafeGetLength<'t>() = System.Enum.GetValues(typeof<'t>).Length
    // we haven't discovered if we need Enums, or a DU yet, handle either
    module DEnums =
        let getLength<'t> =
            let t = typeof<'t>
            if FSharp.Reflection.FSharpType.IsUnion t then
                DUs.getLength<'t>
            elif typeof<'t>.IsEnum then
                Enums.unsafeGetLength<'t>()
            else failwithf "Expected Enum or DU but was %s" t.Name

