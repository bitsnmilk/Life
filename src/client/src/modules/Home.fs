module Modules.Home

open Fable.Helpers.React
open Fable.Helpers.React.Props

open Components

let view model =
    div [ ClassName "site-wrapper" ] [
        Header.view()
        main [] [
            div [Id "home-page"] [
                Posts.view model
            ]
        ]
        Footer.view()
    ]

