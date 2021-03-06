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
open System

type PageModel =
| Home of Home.Model
| Post of Post.Model
| Login of Login.Model
| NotFound

type Model = {
  User : UserData option
  PageModel :PageModel
}

type Msg =
| LoginMessage of Login.Msg

let update msg model =
  match (msg, model.PageModel) with
  | LoginMessage loginMessage, Login loginModel ->
    let (subModel, subCmd) = Login.update loginMessage loginModel
    ({ model with PageModel = Login subModel }, Cmd.map LoginMessage subCmd)
  | LoginMessage _, _ -> (model, Cmd.none)


let root model dispatch =
  match model.PageModel with
  | Home model -> Home.view model dispatch
  | Post model -> Post.view model dispatch
  | Login model -> Login.view model (LoginMessage >> dispatch)
  | NotFound -> NotFound.view()

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
  let handlePageUpdate page model =
    match page with
    | Page.Home -> ({ model with PageModel = Home { Posts = initialPosts } }, Cmd.none)
    | Page.Post id ->
      initialPosts
      |> List.tryItem(id)
      |> Option.map (fun p -> ({ model with PageModel = Post { Post = p } }, Cmd.none))
      |> Option.defaultValue ({ model with PageModel = NotFound }, Cmd.none)
    | Page.Login -> ({ model with PageModel = Login Login.Model.Empty }, Cmd.none)

  let urlUpdate result model =
    match result with
    | Some page -> handlePageUpdate page model
    | None -> ({ model with PageModel = NotFound }, Cmd.none)

  let init result = urlUpdate result ({ User = None ; PageModel = Home { Posts = initialPosts } })

Program.mkProgram App.init update root
|> Program.toNavigable (parseHash Router.pageParser) App.urlUpdate
|> Program.withReact "elmish-app"
|> Program.withConsoleTrace
|> Program.run