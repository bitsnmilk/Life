module Pages.Home

open Components
open Types

open Fable.Helpers.React
open Fable.Helpers.React.Props


type Model = { Posts : Post list }

let view model dispatch =
    div [ ClassName "site-wrapper" ] [
        Header.view()
        main [] [
            div [Id "home-page"] [
                Posts.view model.Posts
            ]
        ]
        Footer.view()
    ]

