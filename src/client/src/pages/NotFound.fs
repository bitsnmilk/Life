module Pages.NotFound

open Fable.Helpers.React
open Fable.Helpers.React.Props

open Types
open Components


let view() =
    div [ ClassName "site-wrapper" ] [
        Header.view()
        main [] [
            section [ ClassName "single-wrap"] [
                str "404: Page not found"
            ]
        ]
        Footer.view()
    ]

