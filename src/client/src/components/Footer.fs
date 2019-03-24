module Components.Footer

open Domain
open Fable.Helpers.React
open Fable.Helpers.React.Props

let view model dispatch =
    header [] [
        div [ ClassName "h-wrap" ] [
            h1 [ ClassName "title" ] [
                a [ Href "https://google.com"; Title "Back to Homepage" ] [ str "Bits N Milk" ]
                a [ ClassName "menu-icon"; Title "Open Bio"] [ span [ ClassName "lines"] [] ]
            ]
        ]
    ]
