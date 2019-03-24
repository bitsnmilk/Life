module Pages.Post

open Fable.Helpers.React
open Fable.Helpers.React.Props

open Types
open Components

type Model = { Post : Post }

let view model dispatch =
    div [ ClassName "site-wrapper" ] [
        Header.view()
        main [] [
            section [ ClassName "single-wrap"] [
                Post.view model.Post
            ]
        ]
        Footer.view()
    ]

