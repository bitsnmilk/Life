module Domain

open System

type Post = {
    Id: int
    Title : string
    Description : string
    Body : string
    CreatedAt : DateTime
    UpdatedAt : DateTime
}

module Global =
  type Page =
    | Home

  let toHash page =
    match page with
    | Home -> "#home"

module Types =
  open Global

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

  let private initalPosts = [
    { Id = 0 ; Title = "Welcome to Hikari for jekyll!" ; Description = "description" ; Body = "Body" ; CreatedAt = DateTime.Now ; UpdatedAt = DateTime.Now }
    { Id = 0 ; Title = "Welcome to Hikari for jekyll!" ; Description = "description" ; Body = "Body" ; CreatedAt = DateTime.Now ; UpdatedAt = DateTime.Now }
    { Id = 0 ; Title = "Welcome to Hikari for jekyll!" ; Description = "description" ; Body = "Body" ; CreatedAt = DateTime.Now ; UpdatedAt = DateTime.Now }
    { Id = 0 ; Title = "Welcome to Hikari for jekyll!" ; Description = "description" ; Body = "Body" ; CreatedAt = DateTime.Now ; UpdatedAt = DateTime.Now }
    { Id = 0 ; Title = "Welcome to Hikari for jekyll!" ; Description = "description" ; Body = "Body" ; CreatedAt = DateTime.Now ; UpdatedAt = DateTime.Now }
    { Id = 0 ; Title = "Welcome to Hikari for jekyll!" ; Description = "description" ; Body = "Body" ; CreatedAt = DateTime.Now ; UpdatedAt = DateTime.Now }
    { Id = 0 ; Title = "Welcome to Hikari for jekyll!" ; Description = "description" ; Body = "Body" ; CreatedAt = DateTime.Now ; UpdatedAt = DateTime.Now }
    { Id = 0 ; Title = "Welcome to Hikari for jekyll!" ; Description = "description" ; Body = "Body" ; CreatedAt = DateTime.Now ; UpdatedAt = DateTime.Now }
    { Id = 0 ; Title = "Welcome to Hikari for jekyll!" ; Description = "description" ; Body = "Body" ; CreatedAt = DateTime.Now ; UpdatedAt = DateTime.Now }
    { Id = 0 ; Title = "Welcome to Hikari for jekyll!" ; Description = "description" ; Body = "Body" ; CreatedAt = DateTime.Now ; UpdatedAt = DateTime.Now }
  ]

  let init result =
    let (model, cmd) = urlUpdate result { CurrentPage = Home ; Posts = initalPosts }
    (model, cmd)

  let update msg model = (model, [])