module Modules.Post

open Fable.Helpers.React
open Fable.Helpers.React.Props

open Components

let view model =
    div [ ClassName "site-wrapper" ] [
        Header.view()
        main [] [
            section [ ClassName "single-wrap"] [
                Post.view model
            ]
        ]
        Footer.view()
    ]

