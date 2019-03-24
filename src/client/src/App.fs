module Client

module Global =
  type Page =
    | Home
    | Counter
    | About

  let toHash page =
    match page with
    | About -> "#about"
    | Counter -> "#counter"
    | Home -> "#home"

module Types =
  open Global

  type Msg = Nothing

  type Model = { currentPage : Page }

module MyState =
  open Elmish.Browser.Navigation
  open Elmish.Browser.UrlParser
  open Fable.Import.Browser
  open Global
  open Types

  let pageParser : Parser<Page -> Page, Page> =
    oneOf [ map About (s "about")
            map Counter (s "counter")
            map Home (s "home") ]

  let urlUpdate result model =
    match result with
    | Some page -> ({ model with currentPage = page }, [])
    | None ->
        console.error ("Error parsing url")
        (model, Navigation.modifyUrl (toHash model.currentPage))

  let init result =
    let (model, cmd) = urlUpdate result { currentPage = Home }
    (model, cmd)

  let update msg model = (model, [])

module View =
  open Fable.Helpers.React

  let view model dispatch =
    div [] [
      h1 [] [str "Demo12234"]
    ]

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