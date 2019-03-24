module Modules.Login

open Fable.Helpers.React
open Fable.Helpers.React.Props

open Components

type Model = {
    Username : string
    Password : string } with
    static member Empty = { Username = "" ; Password = "" }

type Msg =
| ChangeUsername of string
| ChangePassword of string
| Login of Model


let view model dispatch =
    div [ ClassName "site-wrapper" ] [
        Header.view()
        main [] [
            section [ ClassName "single-wrap"] [
                fieldset [] [
                    p [] [
                        label [ Props.FormTarget "username" ] [ str "username" ]
                        input [ Id "username" ]
                    ]

                    p [] [
                        label [ Props.FormTarget "password" ] [ str "password" ]
                        input [ Id "username" ; Props.Type "password" ]
                    ]

                    p [ ClassName "buttons" ] [
                        button [ Props.Type "submit" ] [ str "Login" ]
                        a [ Href "/" ] [ str "Back to home" ]
                    ]
                ]
            ]
        ]
        Footer.view()
    ]

