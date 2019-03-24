module Components.Header

open Fable.Helpers.React
open Fable.Helpers.React.Props

let view model dispatch =
    header [] [
        div [ ClassName "h-wrap" ] [
            h1 [ ClassName "title" ] [
                a [ Href "https://google.com"; Title "Back to Homepage" ] [ str "bits n milk" ]
            ]
            a [ ClassName "menu-icon"; Title "Open Bio"] [ span [ ClassName "lines"] [] ]
        ]
    ]
