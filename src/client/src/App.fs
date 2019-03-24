module Client
open Elmish.ReactNative

module Global =
  type Page =
    | Home

  let toHash page =
    match page with
    | Home -> "#home"

module Types =
  open Global
  open Domain

  type Msg = Nothing

  type Model = { CurrentPage : Page ; Posts : Post list}

module MyState =
  open Elmish.Browser.Navigation
  open Elmish.Browser.UrlParser
  open Fable.Import.Browser
  open Global
  open Types

  let pageParser : Parser<Page -> Page, Page> =
    oneOf [ map Home (s "home") ]

  let urlUpdate result model =
    match result with
    | Some page -> ({ model with CurrentPage = page }, [])
    | None ->
        console.error ("Error parsing url")
        (model, Navigation.modifyUrl (toHash model.CurrentPage))

  let init result =
    let (model, cmd) = urlUpdate result { CurrentPage = Home ; Posts = [] }
    (model, cmd)

  let update msg model = (model, [])

module View =
  let view (model : Types.Model) dispatch =
    match model.CurrentPage with
    |  Global.Page.Home -> Modules.Home.view model dispatch

open Elmish
open Elmish.Browser.Navigation
open Elmish.Browser.UrlParser
open Elmish.React
open MyState
open View

// App
Program.mkProgram init update view
|> Program.toNavigable (parseHash pageParser) urlUpdate
|> Program.withReact "elmish-app"
|> Program.withConsoleTrace
|> Program.run