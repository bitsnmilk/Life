module Components.Header

open Domain
open Fable.Helpers.React
open Fable.Helpers.React.Props

let view model dispatch =
    let homePageLink = Global.Page.Home |> Global.toHash
    header [] [
        div [ ClassName "h-wrap" ] [
            h1 [ ClassName "title" ] [
                a [ Href homePageLink ; Title "Back to Homepage" ] [ str "bits n milk" ]
            ]
            a [ ClassName "menu-icon"; Title "Open Bio"] [ span [ ClassName "lines"] [] ]
        ]
    ]
