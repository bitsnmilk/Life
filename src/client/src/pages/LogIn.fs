module Pages.Login

open Elmish
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Core.JsInterop

open Components

type Model = {
    Username : string
    Password : string } with
    static member Empty = { Username = "" ; Password = "" }

type Msg =
| ChangeUsername of string
| ChangePassword of string
| Login of Model

let update msg model =
    match msg with
    | ChangeUsername username -> ({ model with Username = username }, Cmd.none)
    | ChangePassword password -> ({ model with Password = password }, Cmd.none)
    | Login model -> (model, Cmd.none)


let view model dispatch =
    div [ ClassName "site-wrapper" ] [
        Header.view()
        main [] [
            section [ ClassName "single-wrap"] [
                fieldset [] [
                    p [] [
                        label [ Props.FormTarget "username" ] [ str "username" ]
                        input [ Id "username" ; OnChange (fun ev -> !!ev.target?value |> ChangeUsername |> dispatch) ]
                    ]

                    p [] [
                        label [ Props.FormTarget "password" ] [ str "password" ]
                        input [ Id "username" ; Props.Type "password" ; OnChange (fun ev -> !!ev.target?value |> ChangePassword |> dispatch) ]
                    ]

                    p [ ClassName "buttons" ] [
                        button [ Props.Type "submit" ; OnClick (fun _ -> model |> Login |> dispatch) ] [ str "Login" ]
                        a [ Href "/" ] [ str "Back to home" ]
                    ]
                ]
            ]
        ]
        Footer.view()
    ]

