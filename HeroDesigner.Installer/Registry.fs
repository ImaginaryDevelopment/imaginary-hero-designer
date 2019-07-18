module Registry
open Microsoft.Win32
open Helpers.Files

type ExtAssociatedArgs = {Extension:string; RootClass:string;OpenWith:FilePath;FileDescription:string}

let getKeyStringValue name (k:RegistryKey) = k.GetValue name :?> string
let checkSubKeyValue (parentKey:RegistryKey, subkeyPath: string , keyCheckIfExists) =
    use subKey = parentKey.OpenSubKey(subkeyPath, writable= false)
    not <| isNull subKey && keyCheckIfExists subKey



// https://stackoverflow.com/questions/2681878/associate-file-extension-with-application
// example : getIsExtAssociated{Extension=".ucs"; Keyname="UCS_Editor_File";OpenWith=FilePath Application.ExecutablePath;FileDescription= "UCS File")
let getIsExtAssociated (eaa:ExtAssociatedArgs) =
    let baseKeyExists =
        use baseKey = Registry.ClassesRoot.OpenSubKey(eaa.Extension, writable= false)
        not <| isNull baseKey
        && getKeyStringValue "" baseKey = eaa.RootClass

    let hasCommands () =
        use openMethod = Registry.ClassesRoot.OpenSubKey(eaa.RootClass, writable= false)
        let hasOpen = not <| isNull openMethod && getKeyStringValue "" openMethod = eaa.FileDescription
        if not hasOpen then false
        else
            use shell = openMethod.OpenSubKey "Shell"
            let quoted = sprintf "\"%s\""
            let expected = sprintf "%s %s" (quoted eaa.OpenWith.raw) (quoted "%1")
            not <| isNull shell
            && checkSubKeyValue(shell, """edit\command""", fun k -> getKeyStringValue "" k = expected)
            && checkSubKeyValue(shell, """open\command""", fun k -> getKeyStringValue "" k = expected)
    let hasProgid () =
        use uc = Registry.CurrentUser.OpenSubKey(
                    sprintf """HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\FileExts\%s\UserChoice""" eaa.Extension,
                    writable= false)
        getKeyStringValue "Progid" uc = eaa.RootClass

    baseKeyExists
    && hasCommands()
    && hasProgid()


let FileKeyName = "Mids_Reborn_File"
let FileDescription = "Mids Reborn File";
// checks a path
let getIsAssociated fullExePath =
    getIsExtAssociated{Extension=".mxd";RootClass=FileKeyName; FileDescription= FileDescription;OpenWith=fullExePath }

let getOpenCommand () =
    Registry.ClassesRoot.OpenSubKey(FileKeyName, writable=false)
    |> Option.ofObj
    |> Option.bind(fun k -> k.OpenSubKey @"Shell\open\command" |> Option.ofObj)
    |> Option.map(getKeyStringValue System.String.Empty)
