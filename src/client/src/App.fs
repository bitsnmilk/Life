module Client

open Elmish.ReactNative
open Domain

module View =
  let view (model : Types.Model) dispatch =
    match model.CurrentPage with
    | Global.Page.Home -> Modules.Home.view model dispatch
    | Global.Page.Post id ->
      model.Posts
      |> Seq.tryFind (fun p -> p.Id = id)
      |> Option.map (fun p -> Modules.Post.view p dispatch)
      |> Option.defaultValue (Modules.Home.view model dispatch)

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