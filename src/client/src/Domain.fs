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
    | Post of int

  let toHash page =
    match page with
    | Home -> "#home"
    | Post id -> sprintf "#post/%i" id

module Types =
  open Global

  type Msg = Nothing

  type Model = { CurrentPage : Page ; Posts : Post list }

module MyState =
  open Elmish.Browser.Navigation
  open Elmish.Browser.UrlParser
  open Fable.Import.Browser

  open Global
  open Types

  let pageParser : Parser<Page -> Page, Page> =
    oneOf [ map Home (s "home")
            map Post (s "post" </> i32) ]

  let urlUpdate result model =
    match result with
    | Some page -> ({ model with CurrentPage = page }, [])
    | None ->
        console.error ("Error parsing url")
        (model, Navigation.modifyUrl (toHash model.CurrentPage))

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