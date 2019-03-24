module Client

open Types
open Router

open Elmish
open Elmish.React
open Elmish.Browser
open Elmish.Browser.Navigation
open Elmish.Browser.UrlParser
open Elmish.ReactNative
open Fable.Import
open System

type Msg =
| LoginMessage of Modules.Login.Msg

type Model = { CurrentPage : Page ; Posts : Post list }

let root model dispatch =
  match model.CurrentPage with
  | Page.Home -> Modules.Home.view model.Posts
  | Page.Post id ->
    model.Posts
    |> Seq.tryFind (fun p -> p.Id = id)
    |> Option.map (fun p -> p |> Modules.Post.view)
    |> Option.defaultValue (Modules.Home.view model.Posts)
  | Page.Login -> Modules.Login.view model dispatch

let urlUpdate result model =
    match result with
    | Some page -> ({ model with CurrentPage = page }, [])
    | None ->
        Browser.console.error ("Error parsing url")
        (model, Navigation.modifyUrl (Router.toHash model.CurrentPage))

let private initalPosts = [
  { Id = 0 ; Title = "Welcome to Hikari for jekyll!" ; Description = "description" ; Body = "Body" ; CreatedAt = DateTime.Now ; UpdatedAt = DateTime.Now }
  { Id = 1 ; Title = "Welcome to Hikari for jekyll!" ; Description = "description" ; Body = "Body" ; CreatedAt = DateTime.Now ; UpdatedAt = DateTime.Now }
  { Id = 2 ; Title = "Welcome to Hikari for jekyll!" ; Description = "description" ; Body = "Body" ; CreatedAt = DateTime.Now ; UpdatedAt = DateTime.Now }
  { Id = 3 ; Title = "Welcome to Hikari for jekyll!" ; Description = "description" ; Body = "Body" ; CreatedAt = DateTime.Now ; UpdatedAt = DateTime.Now }
  { Id = 4 ; Title = "Welcome to Hikari for jekyll!" ; Description = "description" ; Body = "Body" ; CreatedAt = DateTime.Now ; UpdatedAt = DateTime.Now }
  { Id = 5 ; Title = "Welcome to Hikari for jekyll!" ; Description = "description" ; Body = "Body" ; CreatedAt = DateTime.Now ; UpdatedAt = DateTime.Now }
  { Id = 6 ; Title = "Welcome to Hikari for jekyll!" ; Description = "description" ; Body = "Body" ; CreatedAt = DateTime.Now ; UpdatedAt = DateTime.Now }
  { Id = 7 ; Title = "Welcome to Hikari for jekyll!" ; Description = "description" ; Body = "Body" ; CreatedAt = DateTime.Now ; UpdatedAt = DateTime.Now }
  { Id = 8 ; Title = "Welcome to Hikari for jekyll!" ; Description = "description" ; Body = "Body" ; CreatedAt = DateTime.Now ; UpdatedAt = DateTime.Now }
  { Id = 9 ; Title = "Welcome to Hikari for jekyll!" ; Description = "description" ; Body = "Body" ; CreatedAt = DateTime.Now ; UpdatedAt = DateTime.Now }
]

let init result =
  let (model, cmd) = urlUpdate result { CurrentPage = Home ; Posts = initalPosts }
  (model, cmd)

let update msg model = (model, [])

// App
Program.mkProgram init update root
|> Program.toNavigable (parseHash Router.pageParser) urlUpdate
|> Program.withReact "elmish-app"
|> Program.withConsoleTrace
|> Program.run