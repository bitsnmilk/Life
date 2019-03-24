module Modules.Home

open Domain
open Domain.Types
open Fable.Helpers.React
open Fable.Helpers.React.Props

open Components

let view model  dispatch =
    div [ ClassName "site-wrapper" ] [
        Header.view model dispatch
        main [] [
            div [Id "home-page"] [
                Posts.view { Posts = model.Posts } dispatch
            ]
        ]
        Footer.view model dispatch
    ]

