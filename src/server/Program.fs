module Server

open Suave

let config = { defaultConfig with
                bindings = [ HttpBinding.createSimple HTTP "0.0.0.0" 8088 ] }

[<EntryPoint>]
let main argv =
    startWebServer config (Successful.OK "Hello world")
    0 // return an integer exit code
