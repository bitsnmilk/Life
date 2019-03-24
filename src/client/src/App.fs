module Client

open Pages
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


type Model =
| Home of Home.Model
| Post of Post.Model
| Login of Login.Model

type Msg =
| LoginMessage of Login.Msg

let update msg model =
  match (msg, model) with
  | LoginMessage loginMessage, Login loginModel ->
    let (subModel, subCmd) = Login.update loginMessage loginModel
    (Login subModel, Cmd.map LoginMessage subCmd)
  | LoginMessage _, _ -> (model, Cmd.none)


let root model dispatch =
  match model with
  | Home model -> Home.view model dispatch
  | Post model -> Post.view model dispatch
  | Login model -> Login.view model (LoginMessage >> dispatch)



let initialPosts = [
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

module App =
  let urlUpdate result model =
    match result with
    | Some Page.Home -> (Home { Posts = initialPosts }, Cmd.none)
    | Some (Page.Post id) -> (Post { Post = initialPosts.[id] }, Cmd.none)
    | Some Page.Login -> (Login Login.Model.Empty, Cmd.none)
    | None ->
        Browser.console.error ("Error parsing url")
        (model, Navigation.modifyUrl "#home")

  let init result =
    let (model, cmd) = urlUpdate result (Home { Posts = initialPosts })
    (model, cmd)


Program.mkProgram App.init update root
|> Program.toNavigable (parseHash Router.pageParser) App.urlUpdate
|> Program.withReact "elmish-app"
|> Program.withConsoleTrace
|> Program.run