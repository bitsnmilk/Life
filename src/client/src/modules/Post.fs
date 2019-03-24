module Modules.Post

open Domain
open Domain.Types
open Fable.Helpers.React
open Fable.Helpers.React.Props

open Components

let view model dispatch =
    div [ ClassName "site-wrapper" ] [
        Header.view model dispatch
        main [] [
            section [ ClassName "single-wrap"] [
                Post.view model dispatch
            ]
        ]
        Footer.view model dispatch
    ]

