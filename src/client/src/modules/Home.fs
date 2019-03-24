module Modules.Home

open Fable.Helpers.React

open Components

let view model dispatch =
    div [] [
        Header.view model dispatch
        Posts.view model dispatch
        Footer.view model dispatch
    ]

